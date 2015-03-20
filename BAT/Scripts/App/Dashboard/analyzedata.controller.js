; (function () {
    'use strict';

    angular.module('batApp')
    .controller('AnalyzeDataController', function ($scope, $routeParams, sessionDataFactory) {
        var vm = this;
        var id = $routeParams.id;

        sessionDataFactory.getSessionData(id, function (data) {
            vm.sessionData = data;
            $scope.startDate = moment(vm.sessionData.startDate)
              .format("dddd, MMMM Do YYYY, h:mm:ss a");
            $scope.endDate = moment(vm.sessionData.endDate)
              .format("dddd, MMMM Do YYYY, h:mm:ss a");
        });

        vm.csvMaker = function () {
            var s = vm.sessionData.summary;
            var d = vm.sessionData.behaviorInstances;
            var CSV = "";
            CSV += 'Session Summary' + ',,\r\n,,\n';
            CSV += 'Name:,' + vm.sessionData.name + ',\r\n';
            CSV += 'Description:,' + vm.sessionData.description + ',\r\n';
            CSV += 'Code Set:,' + vm.sessionData.codeSetName + ',\r\n';
            CSV += 'Started:,' + '"' + $scope.startDate + '"' + ',\r\n';
            CSV += 'Ended:,' + '"' + $scope.endDate + '"' + ',\r\n';
            CSV += 'Duration in Seconds:,' + vm.sessionData.duration + ',\r\n,,\n';

            CSV += 'Summary Data:' + ',,\r\n';
            CSV += 'Behavior,Frequency,RPM\r\n'
            s.forEach(function (i) {
                var row = "";
                row += i.name + ',' + i.frequency + ',' + i.rpm;
                CSV += row + '\r\n';
            });

            CSV += ',,\r\n' + 'Raw Data:' + ',,\r\n';
            CSV += 'Behavior,Seconds' + ',\r\n';
            d.forEach(function (i) {
                var row = "";
                row += i.name + ',' + i.time;
                CSV += row + ',\r\n';
            });

            var fileName = 'Report_';
            fileName += vm.sessionData.name.replace(/ /g, "_");
            var uri = "data:text/csv;charset=utf-8," + encodeURI(CSV);

            var link = document.createElement("a");
            link.href = uri;
            link.style = "visibility:hidden";
            link.download = fileName + ".csv";

            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
        };

    })
}());