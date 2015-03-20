; (function () {
    'use strict';

    angular.module('batApp')
    .factory('timeFactory', function ($rootScope, FIREBASE_URL, $http, $location) {

        function _sessionUrl(id) {
            if (id) {
                return FIREBASE_URL + 'users/' + $rootScope.user.uid +
                '/sessionData/' + id + '.json?auth=' + $rootScope.user.token;
            } else {
                return FIREBASE_URL + 'users/' + $rootScope.user.uid +
                '/sessionData.json?auth=' + $rootScope.user.token;
            }
        }

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