; (function () {
    'use strict';

    angular.module('batApp')
      .controller('MainController', function ($rootScope, $scope, FIREBASE_URL) {

          $rootScope.$on('$routeChangeStart', function () {
              $rootScope.loading = true;
          });

          $rootScope.$on('$routeChangeSuccess', function () {
              $rootScope.loading = false;
          });
      });

}());