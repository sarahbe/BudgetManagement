(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .controller('AccountListController', AccountListController);

    /* @ngInject */
    function AccountListController($state, $filter, $mdDialog, accountService, triAuthorization) {
        var vm = this;
        vm.init = init;
        vm.newAccount = newAccount;
        vm.editAccount = editAccount;

        init();
       
       function init(){
            accountService.getAccounts(triAuthorization.getUserId()).then(function(res){
                vm.accounts = res;
            });
       }

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
