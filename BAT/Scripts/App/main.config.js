; (function () {
    'use strict';

    angular.module('batApp')
      .config(function ($routeProvider) {
          $routeProvider.when('/',
            {
                templateUrl: '../../templates/home.html',
                reloadOnSearch: false
            }
          );
          $routeProvider.when('/createaccount',
            {
                templateUrl: '../../templates/createaccount.html',
                controller: 'LoginController',
                controllerAs: 'new',
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