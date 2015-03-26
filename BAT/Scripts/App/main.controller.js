; (function () {
    'use strict';
    angular.module('batApp')
      .controller('MainController', function ($http, $rootScope, $scope) {
          alert("controller");
          
          $rootScope.$on('$routeChangeStart', function () {
              $rootScope.loading = true;
          });
          $rootScope.$on('$routeChangeSuccess', function () {
              $rootScope.loading = false;
          });

          $rootScope.isLoggedIn = false;

          $http.get("api/userid")
            .then(function (result) {
                //success
                if (result !== null) {
                    $rootScope.isLoggedIn = true;
                    $rootScope.userID = result.data;
                    console.log($rootScope.userID);
                    alert('aaaaa');
                } else {
                    $rootScope.isLoggedIn = false;
                }
                
            },
            function () {
            console.log("no user");
            })
          
      });
}());