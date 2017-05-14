(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .controller('AccountRightListController', AccountRightListController);

    /* @ngInject */
    function AccountRightListController($state, $filter, $mdDialog, accountService, accountRightService, triAuthorization) {
        var vm = this;
        vm.init = init;
        vm.addRight = addRight;
        vm.editRight = editRight;
        vm.accountChange = accountChange;

        init();

        function init() {

            accountService.getAccounts(triAuthorization.getUserId()).then(function (res) {
                vm.accounts = res;
            });
        }

        function accountChange() {
            accountRightService.getAccountRights(vm.accountRight.accountId).then(function (res) {
                vm.accountRights = res;
            });
        }

        function addRight($event) {
            $mdDialog.show({
                    templateUrl: 'app/budget/pages/accountRight/right.tmpl.html',
                    targetEvent: $event,
                    controller: 'AccountRightController',
                    controllerAs: 'vm',
                    parent: angular.element(document.body),
                    locals: {
                        accountRight: vm.accountRight
                    }
                })
                .then(function (response) {
                    accountChange();
                });
        }

        function editRight($event, accountRight) {
            $mdDialog.show({
                    templateUrl: 'app/budget/pages/accountRight/right.tmpl.html',
                    targetEvent: $event,
                    controller: 'AccountRightController',
                    controllerAs: 'vm',
                    parent: angular.element(document.body),
                    locals: {
                        accountRight: accountRight
                    }
                })
                .then(function (response) {                    
                    accountChange();
                });
        }

    }

})();
