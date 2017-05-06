(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .controller('TransactionController', TransactionController);

    /* @ngInject */
    function TransactionController($state, $filter) {
        var vm = this;
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
    }

})();
