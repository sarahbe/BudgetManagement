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
                controllerAs: 'vm',
                module: 'public'
            }).state('triangular.admin-default.transaction-list', {
                url: '/pages/transactionlist',
                templateUrl: 'app/budget/pages/transaction/transaction-list.tmpl.html',
                controller: 'TransactionListController',
                controllerAs: 'vm',
                module: 'public'
            }).state('triangular.admin-default.transaction', {
                url: '/pages/transaction',
                templateUrl: 'app/budget/pages/transaction/transaction.tmpl.html',
                controller: 'TransactionController',
                controllerAs: 'vm',
                params: {
                    transaction: {}
                },
                module: 'public'
            }).state('triangular.admin-default.account-list', {
                url: '/pages/accountlist',
                templateUrl: 'app/budget/pages/account/account-list.tmpl.html',
                controller: 'AccountListController',
                controllerAs: 'vm',
                module: 'public'
            }).state('triangular.admin-default.account', {
                url: '/pages/account',
                templateUrl: 'app/budget/pages/account/account.tmpl.html',
                controller: 'AccountController',
                controllerAs: 'vm',
                params: {
                    account: {}
                },
                module: 'public'
                 }).state('triangular.admin-default.category-list', {
                url: '/pages/categorylist',
                templateUrl: 'app/budget/pages/category/category-list.tmpl.html',
                controller: 'CategoryListController',
                controllerAs: 'vm',
                module: 'public'
            }).state('triangular.admin-default.category', {
                url: '/pages/category',
                templateUrl: 'app/budget/pages/category/category.tmpl.html',
                controller: 'CategoryController',
                controllerAs: 'vm',
                params: {
                    category: {}
                },
                module: 'public'
            }).state('triangular.admin-default.reports', {
                url: '/pages/reports',
                templateUrl: 'app/budget/pages/reports/reports.tmpl.html',
                controller: 'ReportListController',
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
            state: 'triangular.admin-default.transaction-list',
            type: 'link',
            priority: 1.2
        });

        triMenuProvider.addMenu({
            name: 'Account',
            icon: 'zmdi zmdi-account',
            state: 'triangular.admin-default.account-list',
            type: 'link',
            priority: 1.3
        });

        
        triMenuProvider.addMenu({
            name: 'Category',
            icon: 'fa fa-bookmark-o',
            state: 'triangular.admin-default.category-list',
            type: 'link',
            priority: 1.4
        });

        triMenuProvider.addMenu({
            name: 'Reports',
            icon: 'fa fa-bar-chart-o',
            state: 'triangular.admin-default.reports',
            type: 'link',
            priority: 1.5
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