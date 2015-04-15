; (function () {
    'use strict';

    angular.module('batApp')
      .config(['$httpProvider', function ($httpProvider) {
          $httpProvider.defaults.headers.post = {"Content-Type": "application/json"};
      }])
      .config(function ($routeProvider) {
          $routeProvider.when('/',
            {
                templateUrl: '../../templates/home.html',
                controller: 'MainController',
                reloadOnSearch: false
            }
          );
          
          $routeProvider.when('/login',
            {
                templateUrl: '/Account/Login',
                controller: 'MainController',
                reloadOnSearch: false
            }
          );

          $routeProvider.when('/logout',
            {
                templateUrl: '../../templates/logout.html',
                controller: 'MainController',
                reloadOnSearch: false
            }
          );

          $routeProvider.when('/register',
            {
                templateUrl: '/Account/Register',
                controller: 'MainController',
                //controllerAs: 'new',
                reloadOnSearch: false
            }
          );
          $routeProvider.when('/mydashboard',
            {
                templateUrl: '../../templates/mydashboard.html',
                reloadOnSearch: false
            }
          );
      })
}());