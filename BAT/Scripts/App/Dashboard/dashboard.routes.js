; (function () {
    'use strict';

    angular.module('batApp')
      .config(function ($routeProvider) {

          //Code Sets:
          $routeProvider.when('/managecodesets',
            {
                templateUrl: '../../../templates/dashboard/managecodesets.html',
                controller: 'ShowCodeSetController',
                controllerAs: 'viewCodeSet',
                private: true,
                reloadOnSearch: false
            }
          );
          $routeProvider.when('/codeset/:id/edit',
          {
              templateUrl: '../../../templates/dashboard/editcodeset.html',
              controller: 'EditCodeSetController',
              controllerAs: 'codeSet',
              private: true,
              reloadOnSearch: false
          }
          );
          $routeProvider.when('/codeset/:id',
            {
                templateUrl: '../../../templates/dashboard/session.html',
                controller: 'TimeController',
                controllerAs: 'time',
                private: true,
                reloadOnSearch: false
            }
          );
          $routeProvider.when('/newcodeset',
            {
                templateUrl: '../../../templates/dashboard/newcodeset.html',
                controller: 'CodeSetController',
                controllerAs: 'codeSet',
                private: true,
                reloadOnSearch: false
            }
          );

          //Create Session
          $routeProvider.when('/newsession',
            {
                templateUrl: '../../../templates/dashboard/newsession.html',
                controller: 'ShowCodeSetController',
                controllerAs: 'viewCodeSet',
                private: true,
                reloadOnSearch: false
            }
          );

          //Previous Session Data:
          $routeProvider.when('/previoussessiondata',
            {
                templateUrl: '../../../templates/dashboard/previoussessiondata.html',
                controller: 'SessionDataController',
                controllerAs: 'dataSets',
                private: true,
                reloadOnSearch: false
            }
          );
          $routeProvider.when('/rawsessiondata/:id',
            {
                templateUrl: '../../../templates/dashboard/rawsessiondata.html',
                controller: 'AnalyzeDataController',
                controllerAs: 'dataSet',
                private: true,
                reloadOnSearch: false
            }
          );
          $routeProvider.when('/download/:id',
            {
                templateUrl: '../../../templates/dashboard/download.html',
                controller: 'AnalyzeDataController',
                controllerAs: 'dataSet',
                private: true,
                reloadOnSearch: false
            }
          );
          $routeProvider.when('/sessiondatasummary/:id',
            {
                templateUrl: '../../../templates/dashboard/sessiondatasummary.html',
                controller: 'AnalyzeDataController',
                controllerAs: 'dataSet',
                private: true,
                reloadOnSearch: false
            }
          );

          $routeProvider.when('/sessiondata/:id/edit',
            {
                templateUrl: '../../../templates/dashboard/editsessiondata.html',
                controller: 'EditSessionDataController',
                controllerAs: 'edit',
                private: true,
                reloadOnSearch: false
            }
          );

          //Inter-Observer Agreement:
      })
}());