; (function () {
    'use strict';

    angular.module('batApp')
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
                //controllerAs: 'new',
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