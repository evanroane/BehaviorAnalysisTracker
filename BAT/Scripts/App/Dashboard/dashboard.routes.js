; (function () {
    'use strict';

    angular.module('batApp')
      .config(function ($routeProvider) {
          $routeProvider.when('/newsession',
            {
                templateUrl: 'views/dashboard/newsession.html',
                controller: 'ShowCodeSetController',
                controllerAs: 'viewCodeSet',
                private: true,
                reloadOnSearch: false
            }
          );
          $routeProvider.when('/previoussessiondata',
            {
                templateUrl: 'views/dashboard/previoussessiondata.html',
                controller: 'SessionDataController',
                controllerAs: 'dataSets',
                private: true,
                reloadOnSearch: false
            }
          );
          $routeProvider.when('/rawsessiondata/:id',
            {
                templateUrl: 'views/dashboard/rawsessiondata.html',
                controller: 'AnalyzeDataController',
                controllerAs: 'dataSet',
                private: true,
                reloadOnSearch: false
            }
          );
          $routeProvider.when('/download/:id',
            {
                templateUrl: 'views/dashboard/download.html',
                controller: 'AnalyzeDataController',
                controllerAs: 'dataSet',
                private: true,
                reloadOnSearch: false
            }
          );
          $routeProvider.when('/sessiondatasummary/:id',
            {
                templateUrl: 'views/dashboard/sessiondatasummary.html',
                controller: 'AnalyzeDataController',
                controllerAs: 'dataSet',
                private: true,
                reloadOnSearch: false
            }
          );
          $routeProvider.when('/managecodesets',
            {
                templateUrl: 'views/dashboard/managecodesets.html',
                controller: 'ShowCodeSetController',
                controllerAs: 'viewCodeSet',
                private: true,
                reloadOnSearch: false
            }
          );
          $routeProvider.when('/newcodeset',
            {
                templateUrl: 'views/dashboard/newcodeset.html',
                controller: 'CodeSetController',
                controllerAs: 'codeSet',
                private: true,
                reloadOnSearch: false
            }
          );
          $routeProvider.when('/codeset/:id/edit',
          {
              templateUrl: 'views/dashboard/editcodeset.html',
              controller: 'EditCodeSetController',
              controllerAs: 'codeSet',
              private: true,
              reloadOnSearch: false
          }
          );
          $routeProvider.when('/codeset/:id',
            {
                templateUrl: 'views/dashboard/session.html',
                controller: 'TimeController',
                controllerAs: 'time',
                private: true,
                reloadOnSearch: false
            }
          );
          $routeProvider.when('/sessiondata/:id/edit',
            {
                templateUrl: 'views/dashboard/editsessiondata.html',
                controller: 'EditSessionDataController',
                controllerAs: 'edit',
                private: true,
                reloadOnSearch: false
            }
          );

      })
}());