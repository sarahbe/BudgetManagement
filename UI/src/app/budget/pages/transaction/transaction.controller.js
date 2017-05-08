﻿(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .controller('TransactionController', TransactionController);

    /* @ngInject */
    function TransactionController($state, transactionService, lookupService,triAuthorization,  accountService, appNotifyService) {
        var vm = this;
        vm.saveTransaction = saveTransaction;
        vm.transactionTypeChange = transactionTypeChange;
        vm.init = init;

        init();

        function init() {
            vm.transaction = {};
            vm.transaction.transactionTypeId = 1;
            
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

        function saveTransaction() {
            transactionService.saveTransaction(vm.transaction).then(function (res) {
                appNotifyService.success("Saved Successfully");
                //after save we will go to dashboard
                $state.go('triangular.admin-default.dashboard-general');
            });
        }

        function transactionTypeChange() {
            vm.transaction.transactionTypeId = vm.isIncome ? 1 : 2;
            fillCategories();
        }
    }

})();
