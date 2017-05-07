(function() {
    'use strict';

    angular
        .module('app.budget.authentication')
        .controller('ConfirmController', ConfirmController);

    /* @ngInject */
    function ConfirmController($state, $mdToast, $filter, triSettings, $stateParams, authenticationService, appNotifyService) {
        var vm = this;
        vm.gotToLoginClick = gotToLoginClick;
        vm.confirmMethod = confirmMethod;
        vm.isConfirmed = false;
        vm.user = {
            userId: '',
            code: ''
        };
        vm.triSettings = triSettings;

        vm.confirmMethod();
        ////////////////

      
        function gotToLoginClick() {
            // user logged in ok so goto the dashboard
          //  $state.go('triangular.admin-default.dashboard-general');
        }
        
        // controller to handle login check
        function confirmMethod() {
          
            vm.user.userId = $stateParams.userId;
            vm.user.code = $stateParams.code;

            if (vm.user.userId == undefined || vm.user.code==undefined) {
                $state.go('404');
            }

            authenticationService.confirm(vm.user).then(function (result) {
                vm.isConfirmed = true;
                appNotifyService.success('E-posta  adresiniz onaylanmıştır...');
 
            });
            $state.go('authentication.login');

        }
        
    }
})();