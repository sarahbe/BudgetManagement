(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .controller('TransactionController', TransactionController);

    /* @ngInject */
    function TransactionController($state, $stateParams, transactionService,transaction, lookupService, triAuthorization, accountService, appNotifyService) {
        var vm = this;
        vm.saveTransaction = saveTransaction;
        vm.transactionTypeChange = transactionTypeChange;
        vm.init = init;
        vm.transaction = transaction;

        init();

        function init() {
            if ($stateParams.transaction.id)
                vm.transaction = $stateParams.transaction;
            else {
                vm.transaction = {};
                vm.transaction.transactionTypeId = 1;
            }

            accountService.getAccounts(triAuthorization.getUserId()).then(function (res) {
                vm.accounts = res;
            });

            fillCategories()
        }

        function fillCategories() {
            lookupService.getCategories(vm.transaction.transactionTypeId, triAuthorization.getUserId()).then(function (res) {
                vm.categories = res;
            });
        }
        function fillAccounts() {
            lookupService.getAccounts(triAuthorization.getUserId()).then(function (res) {
                vm.accounts = res;
            });
        }

        function saveTransaction() {
            vm.transaction.userId = triAuthorization.getUserId();
            transactionService.saveTransaction(vm.transaction).then(function (res) {
                appNotifyService.success("Saved Successfully");
                //after save we will go to dashboard
                $state.go('triangular.admin-default.transaction-list');
            });
        }

        function transactionTypeChange() {
            vm.transaction.transactionTypeId = vm.isIncome ? 2 : 1;
            fillCategories();
        }
    }

})();
