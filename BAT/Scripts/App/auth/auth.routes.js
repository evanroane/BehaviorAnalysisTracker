; (function () {
    angular.module('batApp')
      .config(function ($routeProvider) {
          $routeProvider
            .when('/login',
            {
                templateUrl: 'views/login.html',
                controller: 'LoginController',
                controllerAs: 'login',
                reloadOnSearch: false,
                resolve: {
                    data: function (authFactory) {
                        authFactory.disallowLogin();
                    }
                }
            })
            .when('/logout', {
                templateUrl: 'views/logout.html',
                controller: 'LogoutController',
                controllerAs: 'logout',
                private: false,
                reloadOnSearch: false
            })
            .when('/changepassword', {
                templateUrl: 'views/changepassword.html',
                controller: 'ChangePasswordController',
                controllerAs: 'changepw',
                private: false,
                reloadOnSearch: false
            })

      })
      .run(function ($rootScope, authFactory) {
          $rootScope.$on('$routeChangeStart', function (event, nextRoute, priorRoute) {
              if (nextRoute.$$route && nextRoute.$$route.private) {
                  authFactory.requireLogin();
              }
          })
      })
}());