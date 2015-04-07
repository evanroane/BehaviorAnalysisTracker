; (function () {
    'use strict';

    angular.module('batApp')
        .controller('ReadCodeSetController', function ($rootScope, $scope, $routeParams, codeSetFactory) {
            var vm = this;
            var id = $routeParams.id;

            codeSetFactory.getAllCodeSets(function (data) {
                $scope.codeSets = data;
            });

            vm.removeCodeSet = function (codeSetId) {
                codeSetFactory.deleteCodeSet(codeSetId, function () {
                    delete vm.codeSet[codeSetId];
                });
            };
        })

        .controller('CodeSetController', function ($rootScope, $scope, $location, codeSetFactory, SharedState) {
        var vm = this;
        SharedState.initialize($scope, "activeDropdown");

        $scope.codeSetData = {
            CodeSetName: "",
            CodeSetDescription: "",
            CodeSetOwner: $rootScope.userID
        };



        vm.addNewCodeSet = function() {
            var inputs = $scope.codeSetData;
            codeSetFactory.createCodeSet(inputs, function(data) {
                $location.path('/managecodesets');
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
    });

}());