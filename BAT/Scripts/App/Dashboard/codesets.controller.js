; (function () {
    'use strict';

    angular.module('batApp')
    .controller('CodeSetController', function ($scope, $location, codeSetFactory, SharedState) {
        var vm = this;

        SharedState.initialize($scope, "activeDropdown");

        $scope.codeSetData = {
            codeSetId: "",
            description: "",
            inputs: [
              {
                  name: "",
                  color: "btn-primary"
              }
            ]
        };

        $scope.addNewInput = function () {
            //var newInputNum = $scope.codeSetData.inputs.length + 1;
            $scope.codeSetData.inputs.push(
              {
                  "name": "",
                  "color": "btn-primary"
              }
            );
        };

        $scope.deleteInput = function (index) {
            if ($scope.codeSetData.inputs.length > 1) {
                $scope.codeSetData.inputs.splice(index, 1);
            }
            else {
                console.log("you can't have less than one");
            }
        };

        vm.addNewCodeSet = function () {
            var inputs = $scope.codeSetData;
            codeSetFactory.createCodeSet(inputs, function (data) {
                $location.path('/managecodesets');
            });
        };
    })

    .controller('ShowCodeSetController', function ($scope, $routeParams, codeSetFactory) {
        var vm = this;
        var id = $routeParams.id;

        codeSetFactory.getAllCodeSets(function (data) {
            vm.codeSet = data;
        });

        vm.removeCodeSet = function (codeSetId) {
            codeSetFactory.deleteCodeSet(codeSetId, function () {
                delete vm.codeSet[codeSetId];
            });
        };

    })

    .controller('EditCodeSetController', function ($scope, $routeParams, codeSetFactory) {
        var vm = this;
        var id = $routeParams.id;

        codeSetFactory.getCodeSet(id, function (data) {
            vm.codeSetData = data;
            $scope.codeSetData = vm.codeSetData;
            $scope.inputs = vm.codeSetData.inputs;
        });

        vm.addNewCodeSet = function () {
            codeSetFactory.editCodeSet(id, $scope.codeSetData);
        };

        $scope.addNewInput = function () {
            var input = {
                "name": "",
                "color": "btn-primary"
            }
            $scope.inputs.push(input);
        };

        $scope.deleteInput = function (index) {
            if ($scope.inputs.length > 1) {
                $scope.inputs.splice(index, 1);
            }
            else {
                console.log("you can't have less than one");
            }
        };
    })

}());