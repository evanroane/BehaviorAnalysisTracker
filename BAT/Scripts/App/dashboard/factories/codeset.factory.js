; (function () {
    'use strict';

    angular.module('batApp')
    .factory('codeSetFactory', function ($rootScope, $http, $location) {

    //GET
        function getCodeSet(id, cb) {
            $http.get("api/codeset/id/" + id)
            .success(function(data) {
                cb(data);
            })
            .error(function(err) {
                console.log(err);
            });
        }
        function getAllCodeSets(cb) {
            $http.get("api/codeset/" + $rootScope.userID)
            .success(function(data) {
                cb(data);
            })
            .error(function(err) {
                console.log(err);
            });
        }

    //POST
        function createCodeSet(CodeSet, cb) {
            $http.post("api/codeset/post", CodeSet)
            .success(function (codeSetData) {
                cb(codeSetData);
                console.log('code set sent to server');
            })
            .error(function (err) {
                console.log(err);
            });
        }

    //PUT
        function editCodeSet(id, codeSetId) {
            $http.put(_batUrl(id), codeSetId)
            .success(function (data) {
                $location.path('/managecodesets');
            })
            .error(function (err) {
                console.log(err);
            });
        }

        //DELETE
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