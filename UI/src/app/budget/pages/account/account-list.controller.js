(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .controller('AccountListController', AccountListController);

    /* @ngInject */
    function AccountListController($state, $filter, $mdDialog) {
        var vm = this;
        vm.newAccount = newAccount;
        vm.editAccount = editAccount;

        vm.accounts = [{
                description: 'Nakit',
                limit: '1000'
            },
            {
                description: 'Kredi Kartı',
                limit: '250'
            }
        ];

        function newAccount($event) {
             $mdDialog.show({
                    templateUrl: 'app/budget/pages/account/account.tmpl.html',
                    targetEvent: $event,
                    controller: 'AccountController',
                    controllerAs: 'vm',
                    parent: angular.element(document.body),
                    locals: {                        
                    }
                })
                .then(function (response) {                        
                });
        }

        function editAccount($event, account) {
             $mdDialog.show({
                    templateUrl: 'app/budget/pages/account/account.tmpl.html',
                    targetEvent: $event,
                    controller: 'AccountController',
                    controllerAs: 'vm',
                    parent: angular.element(document.body),
                    locals: {               
                        account: angular.copy(account)         
                    }
                })
                .then(function (response) {                        
                });
        }
    }

})();
