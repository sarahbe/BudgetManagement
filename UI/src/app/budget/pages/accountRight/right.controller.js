﻿(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .controller('AccountRightController', AccountRightController);

    /* @ngInject */
    function AccountRightController($state, $filter, $mdDialog, accountRightService,accountRight, lookupService,  triAuthorization) {
        var vm = this;
        vm.init = init;
        vm.saveAccountRight = saveAccountRight;
        vm.deleteAccountRight = deleteAccountRight;
        vm.accountRight = accountRight;
        vm.cancel = cancel;
        init();

        function init() {
         
        }

        function saveAccountRight(){
          
            accountRightService.saveAccountRight(vm.accountRight).then(function (res) {
                vm.accountRight = null;
                 $mdDialog.hide(res);
                 
            });
        }

        function deleteAccountRight(){
            vm.accountRight.userId = triAuthorization.getUserId();
            accountRightService.deleteAccountRight(vm.accountRight).then(function (res) {
                vm.accountRight = null;
                 $mdDialog.hide(res);
                 
            });
        }

        function cancel()
        {
            $mdDialog.hide();
        }

    }

})();
