; (function () {
    angular.module('batApp')

      .controller('ChangePasswordController', function ($rootScope, $scope, $location, authFactory) {
          var vm = this;
          vm.changePassword = function () {
              authFactory.changePassword(vm.oldPassword, vm.newPassword, function () {

                  $location.path('/mydashboard');
                  $scope.$apply();
              })
          };
      })

      .controller('LoginController', function (authFactory, $scope, $location) {
          var vm = this;

          vm.login = function () {
              authFactory.login(vm.email, vm.password, function () {
                  authFactory.requireLogin();
                  $location.path('/mydashboard');
                  $scope.$apply();
              });
          };

          vm.createAccount = function () {
              authFactory.register(vm.email, vm.password, function () {
                  vm.login();
              });
          };

          vm.forgotPassword = function () {
              authFactory.resetPassword(vm.email);
          };
      })

      .controller('LogoutController', function ($scope, $location, authFactory) {
          var vm = this;
          vm.logout = function () {
              authFactory.logout(function () {
                  $scope.$apply();
              });
          }
      })
}());