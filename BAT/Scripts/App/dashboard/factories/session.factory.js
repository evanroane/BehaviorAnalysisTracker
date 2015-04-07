; (function () {
    'use strict';

    angular.module('batApp')
    .factory('sessionDataFactory', function ($rootScope, $http, $location) {

        function getSessionData(id, cb) {
            $http.get(_sessionUrl(id))
            .success(function (data) {
                cb(data);
            })
            .error(function (err) {
                console.log(err);
            });
        }

        function deleteSessionData(sessionDataId, cb) {
            $http.delete(_sessionUrl(sessionDataId))
            .success(function () {
                cb();
                console.log('session data deleted')
            })
            .error(function (err) {
                console.log(err);
            });
        }

        function editSessionData(id, sessionDataId) {
            $http.put(_sessionUrl(id), sessionDataId)
            .success(function (data) {
                $location.path('/previoussessiondata');
            })
            .error(function (err) {
                console.log(err);
            });
        }

        return {
            getSessionData: getSessionData,
            deleteSessionData: deleteSessionData,
            editSessionData: editSessionData
        };
    });
}());