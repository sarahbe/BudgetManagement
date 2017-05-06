(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .config(moduleConfig);

    /* @ngInject */
    function moduleConfig($translatePartialLoaderProvider, $stateProvider, triMenuProvider) {
        $translatePartialLoaderProvider.addPart('app/budget/pages');

        $stateProvider
        .state('triangular.admin-default.dashboard-general', {
            url: '/pages/dashboard',
            templateUrl: 'app/budget/pages/dashboard/dashboard-general.tmpl.html',
            controller: 'DashboardGeneralController',            
            controllerAs: 'vm'
        }).state('triangular.admin-default.transaction', {
            url: '/pages/transaction',
            templateUrl: 'app/budget/pages/transaction/transaction.tmpl.html',
            controller: 'TransactionController',            
            controllerAs: 'vm'
        }).state('triangular.admin-default.account', {
            url: '/pages/account',
            templateUrl: 'app/budget/pages/account/account.tmpl.html',
            controller: 'AccountController',            
            controllerAs: 'vm'
        });      
        
        triMenuProvider.addMenu({
            name: 'MENU.PAGES.DASHBOARD',
            icon: 'zmdi zmdi-home',
            state: 'triangular.admin-default.dashboard-general',
            type: 'link',
            priority: 1.1

        });

        triMenuProvider.addMenu({
            name: 'Transaction',
            icon: 'zmdi zmdi-money',
            state: 'triangular.admin-default.transaction',
            type: 'link',
            priority: 1.2
        });
        
          triMenuProvider.addMenu({
            name: 'Account',
            icon: 'zmdi zmdi-account',
            state: 'triangular.admin-default.account',
            type: 'link',
            priority: 1.3
        });
        // triMenuProvider.addMenu({
        //     name: 'Admin',
        //     icon: 'zmdi zmdi-home',
        //     state: 'triangular.super-admin.admin-dashboard',
        //     type: 'link',
        //     priority: 1.2
        // });
        
        
        //SubMenu      
          triMenuProvider.addMenu({
           name: 'SETTINGS',
           icon: 'zmdi zmdi-settings',
           state: 'triangular.admin-default.addorupdate',           
           type: 'link',
           priority: 1.1,
           position: "bottom"
        });

    }
})();