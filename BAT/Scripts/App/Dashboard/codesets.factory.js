; (function () {
    'use strict';

    angular.module('batApp')
    .factory('codeSetFactory', function ($rootScope, FIREBASE_URL, $http, $location) {

        function _batUrl(id) {
            if (id) {
                return FIREBASE_URL + 'users/' + $rootScope.user.uid +
                '/codeSets/' + id + '.json?auth=' + $rootScope.user.token;
            } else {
                return FIREBASE_URL + 'users/' + $rootScope.user.uid +
                '/codeSets.json?auth=' + $rootScope.user.token;
            }
        }

        function createCodeSet(codeSet, cb) {
            $http.post(_batUrl(), codeSet)
            .success(function (data) {
                console.log('code set sent to FB');
                cb(data);
            })
            .error(function (err) {
                console.log(err);
            });
        }

        function getCodeSet(id, cb) {
            $http.get(_batUrl(id))
            .success(function (data) {
                cb(data);
            })
            .error(function (err) {
                console.log(err);
            });
        }

        function getAllCodeSets(cb) {
            $http.get(_batUrl())
            .success(function (data) {
                cb(data);
            })
            .error(function (err) {
                console.log(err);
            });
        }

        function editCodeSet(id, codeSetId) {
            $http.put(_batUrl(id), codeSetId)
            .success(function (data) {
                $location.path('/managecodesets');
            })
            .error(function (err) {
                console.log(err);
            });
        }

        function deleteCodeSet(codeSetId, cb) {
            $http.delete(_batUrl(codeSetId))
            .success(function () {
                cb();
                console.log('code set deleted')
            })
            .error(function (err) {
                console.log(err);
            });
        }

        return {
            createCodeSet: createCodeSet,
            getCodeSet: getCodeSet,
            editCodeSet: editCodeSet,
            deleteCodeSet: deleteCodeSet,
            getAllCodeSets: getAllCodeSets
        };

    })
}());