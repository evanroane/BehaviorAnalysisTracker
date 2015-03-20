; (function () {
    'use strict';

    angular.module('batApp')
    .factory('sessionDataFactory', function ($rootScope, FIREBASE_URL, $http, $location) {

        function _sessionUrl(id) {
            if (id) {
                return FIREBASE_URL + 'users/' + $rootScope.user.uid +
                '/sessionData/' + id + '.json?auth=' + $rootScope.user.token;
            } else {
                return FIREBASE_URL + 'users/' + $rootScope.user.uid +
                '/sessionData.json?auth=' + $rootScope.user.token;
            }
        }

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