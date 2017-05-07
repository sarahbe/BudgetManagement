(function() {
    'use strict';

    angular
        .module('app.budget.authentication')
        .controller('ForgotSuccessController', ForgotSuccessController);

    /* @ngInject */
    function ForgotSuccessController($scope, $state, $mdToast, $filter, $http, triSettings, API_CONFIG, authenticationService, appNotifyService) {
        var vm = this;
        vm.triSettings = triSettings;
        vm.user = {
            email: ''
        };
        vm.resetClick = resetClick;
 
        ////////////////

        function resetClick() {

    
        }
    }
})();
