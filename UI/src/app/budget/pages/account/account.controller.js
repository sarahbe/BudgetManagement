(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .controller('AccountController', AccountController);

    /* @ngInject */
    function AccountController($state, $filter, $mdDialog, accountService, lookupService,  triAuthorization) {
        var vm = this;
        vm.init = init;
        vm.saveAccount = saveAccount;

        init();

        function init() {
            accountService.getAccountTypes().then(function (res) {
                vm.accountTypes = res;
            });

            accountService.getCurrencies().then(function (res) {
                vm.currencies = res;
            });
        }

        function saveAccount(){
            vm.account.userId = triAuthorization.getUserId();
            accountService.saveAccount(vm.account).then(function (res) {

                 $mdDialog.hide(res);
                 
            });
        }

    }

})();
