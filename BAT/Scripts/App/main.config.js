; (function () {
    'use strict';

    angular.module('batApp')
      .config(function ($routeProvider) {
          $routeProvider.when('/',
            {
                templateUrl: 'views/home.html',
                reloadOnSearch: false
            }
          );
          $routeProvider.when('/createaccount',
            {
                templateUrl: 'views/createaccount.html',
                controller: 'LoginController',
                controllerAs: 'new',
                reloadOnSearch: false
            }
          );
          $routeProvider.when('/mydashboard',
            {
                templateUrl: 'views/mydashboard.html',
                reloadOnSearch: false
            }
          );
      })
}());