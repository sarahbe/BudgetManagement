(function() {
    'use strict';

    angular
        .module('app.budget.authentication')
        .controller('ForgotController', ForgotController);

    /* @ngInject */
    function ForgotController($scope, $state, $mdToast, $filter, $http, triSettings, API_CONFIG, authenticationService, appNotifyService) {
        var vm = this;
        vm.triSettings = triSettings;
        vm.user = {
            email: ''
        };
        vm.resetClick = resetClick;
        vm.emailPattern = /^[_a-z0-9]+(\.[_a-z0-9]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$/;

        ////////////////

        function resetClick() {

            authenticationService.forgot(vm.user).then(function(result) {

       
                    $state.go('authentication.forgotsuccess');
              

            });
        }
    }
})();
