(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .controller('AccountController', AccountController);

    /* @ngInject */
    function AccountController($state, $filter, account) {
        vm.account = account; 
    }

})();
