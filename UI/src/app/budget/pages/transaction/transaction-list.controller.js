(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .controller('TransactionListController', TransactionListController);

    /* @ngInject */
    function TransactionListController($state, transactionService,triAuthorization, appNotifyService) {
        var vm = this;        
        vm.init = init;
        vm.editTransaction = editTransaction;

        init();

        function init() {
             transactionService.getTransactions(triAuthorization.getUserId()).then(function(res){
                vm.transactions = res;
            });
        }      


        function editTransaction($event, transaction){
            $state.go('triangular.admin-default.transaction',{'transaction': transaction });
        }

    }

})();
