(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .controller('DashboardGeneralController', DashboardGeneralController);

    /* @ngInject */
    function DashboardGeneralController($state, $filter) {
        var vm = this;
        vm.name = "sarah";
    }
})();
