; (function () {
    'use strict';

    angular.module('batApp')
    .controller('TimeController', function ($scope, $routeParams, $location, codeSetFactory, timeFactory) {

        var vm = this;
        var id = $routeParams.id;
        var startTime,
          endTime,
          timer,
          inputNames;
        var timerRunning = !true;

        $scope.summaryArray = [];
        $scope.behaviorInstances = [];
        $scope.dataEventCounter = 0;
        $scope.sessionLabel = "";
        $scope.sessionDesc = "";

        codeSetFactory.getCodeSet(id, function (data) {
            vm.codeSetData = data;
            $scope.inputs = vm.codeSetData.inputs
        });

        vm.displayTimer = function () {
            var secondsSinceBegin = moment.duration(Date.now() - startTime).asSeconds();
            var formatAsTimer = moment()
            .hour(0)
            .minute(0)
            .second(secondsSinceBegin)
            .format('HH:mm:ss');
            var timerContainer = document.getElementById("time-container");
            timerContainer.removeChild(timerContainer.firstChild);
            timerContainer.appendChild(document.createTextNode(formatAsTimer));
        };

        vm.startTimer = function () {
            if (timerRunning === true) {
                console.log("Timer is already started");
            } else {
                startTime = Date.now();
                timer = setInterval(function () { vm.displayTimer() }, 1000);
                timerRunning = true;
                return timerRunning;
            }
        };

        vm.stopTimer = function () {
            if (timerRunning === false) {
                console.log("You can't stop a timer that isn't running");
            } else {
                endTime = Date.now();
                timerRunning = false;
                clearInterval(timer);
                console.log('The Timer Has Been Stopped');
                return timerRunning;
            }
        };

        vm.dataEvent = function (eventName, buttonId) {
            if (timerRunning === false) {
                console.log("Not going to happen");
            } else {
                var now = new Date();
                var eventTime = Math.floor((now - startTime) / 1000);
                var dataEventCounter = $scope.dataEventCounter;
                var eventData = {
                    "x": dataEventCounter + 1,
                    "name": eventName,
                    "time": eventTime
                }
                $scope.behaviorInstances.push(eventData);
                $scope.dataEventCounter++;
                console.log(eventData);
            }
        };

        vm.makeSessionSummary = function () {
            vm.getInputNames();
            vm.runSummaryLoop();
        };

        vm.getInputNames = function () {
            var inputs = $scope.inputs;
            inputNames = _.map(inputs, _.iteratee("name"));
        };

        vm.round = function (value, decimals) {
            return Number(Math.round(value + 'e' + decimals) + 'e-' + decimals);
        }

        vm.logArrayElements = function (element, index, array) {
            var name = element;
            var duration = endTime - startTime;
            var frequency = _.where($scope.behaviorInstances, { "name": element }).length;
            var rpm = vm.round((frequency / duration) * 60, 2);
            var summaryItem = {
                "name": element,
                "frequency": frequency,
                "rpm": rpm
            };
            $scope.summaryArray.push(summaryItem);
        };

        vm.runSummaryLoop = function () {
            inputNames.forEach(vm.logArrayElements);
        };

        vm.saveSession = function (codeSetId, desc) {
            if (timerRunning === false) {
                vm.makeSessionSummary();
                var duration = moment.duration(endTime - startTime).asSeconds();
                var behaviorInstances = $scope.behaviorInstances;
                var name = $scope.sessionLabel;
                var desc = $scope.sessionDesc;
                var summaryArray = $scope.summaryArray;
                var sessionRecord = {
                    "startDate": startTime,
                    "endDate": endTime,
                    "duration": duration,
                    "name": name,
                    "description": desc,
                    "codeSetName": codeSetId,
                    "behaviorInstances": behaviorInstances,
                    "summary": summaryArray
                };
                timeFactory.saveSessionData(sessionRecord, function (data) {
                    $location.path('/previoussessiondata');
                });
            } else {
                console.log("only when the timer is not running")
            }
        };

    });
}());