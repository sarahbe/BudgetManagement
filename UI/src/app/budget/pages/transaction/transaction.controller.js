(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .controller('TransactionController', TransactionController);

    /* @ngInject */
    function TransactionController($state, $filter, transactionService, appNotifyService) {
        var vm = this;
        vm.saveTransaction = saveTransaction;

        vm.categories = [
            {id: 1,
            description: 'sarah'},
            {id: 2,
            description: 'sarah2'}
        ];

          vm.accounts = [
            {id: 1,
            description: 'Cash'},
            {id: 2,
            description: 'CreditCard'}
        ];

        function saveTransaction() {
            transactionService.saveTransaction(vm.transaction).then(function(res){
                appNotifyService.success("Kaydet başarılı");
                $state.go('triangular.admin-default.dashboard-general');
            });
        }
    }

})();
