; (function () {
    'use strict';

    angular.module('batApp')
    .factory('timeFactory', function ($rootScope, $http, $location) {

        function saveSessionData(sessionData, cb) {
            $http.post(_sessionUrl(), sessionData)
            .success(function (data) {
                console.log('session data set sent to FB');
                cb(data);
            })
            .error(function (err) {
                console.log(err);
            });
        }

        return {
            saveSessionData: saveSessionData
        };

    })
}());