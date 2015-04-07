; (function () {
    'use strict';

    angular.module('batApp')
    .controller('SessionDataController', function ($scope, $routeParams, sessionDataFactory, SharedState) {
        var vm = this;
        var id = $routeParams.id;

        SharedState.initialize($scope, "activeDropdown");

        sessionDataFactory.getSessionData(id, function (data) {
            vm.sessionData = data;
            $scope.startDate = moment(vm.sessionData.startDate)
            .format("dddd, MMMM Do YYYY, h:mm:ss a");
            $scope.endDate = moment(vm.sessionData.endDate)
            .format("dddd, MMMM Do YYYY, h:mm:ss a");

        });

        vm.deleteDataSet = function (sessionDataId) {
            sessionDataFactory.deleteSessionData(sessionDataId, function () {
                delete vm.sessionData[sessionDataId];
            });
        };
    })

    .controller('EditSessionDataController', function ($scope, $routeParams, sessionDataFactory) {
        var vm = this;
        var id = $routeParams.id;

        sessionDataFactory.getSessionData(id, function (data) {
            vm.sessionData = data;
        });

        vm.addDataSet = function () {
            sessionDataFactory.editSessionData(id, vm.sessionData);
        };

    });
}());