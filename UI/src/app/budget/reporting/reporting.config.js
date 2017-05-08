(function() {
    'use strict';

    angular
        .module('app.lokantapp.reporting')
        .config(moduleConfig);

    /* @ngInject */
    function moduleConfig($translatePartialLoaderProvider,$compileProvider, $stateProvider, triMenuProvider) {
        $translatePartialLoaderProvider.addPart('app/lokantapp/reporting');
        $compileProvider.preAssignBindingsEnabled(true);

        $stateProvider.state('triangular.admin-default.report-sales-products', {
            url: '/report-sales-products',
            templateUrl: 'app/lokantapp/reporting/report-sales-products/report-sales-products.tmpl.html',
            controller: 'ReportSalesProductsController',
            controllerAs: 'vm',

            resolve: {
                apis: function(appService) {
                    return appService.getApis();
                }
            },
            module: 'ProductOperations'

        }).state('triangular.admin-default.report-order-operations', {
            url: '/report-order-operations',
            templateUrl: 'app/lokantapp/reporting/report-order-operations/report-order-operations.tmpl.html',
            controller: 'ReportOrderOperationsController',
            controllerAs: 'vm',

            resolve: {
                apis: function (appService) {
                    return appService.getApis();
                }
            },
            module: 'ProductOperations'

        }).state('triangular.admin-default.report-stock-products-quantity', {
            url: '/report-stock-products-quantity',
            templateUrl: 'app/lokantapp/reporting/report-stock-products-quantity/report-stock-products-quantity.tmpl.html',
            controller: 'ReportStockProductsQuantityController',
            controllerAs: 'vm',

            resolve: {
                apis: function (appService) {
                    return appService.getApis();
                }
            },
            module: 'ProductOperations'

        }).state('triangular.admin-default.settlement', {
            url: '/settlement',
            templateUrl: 'app/lokantapp/reporting/settlement/settlement.tmpl.html',
            controller: 'SettlementController',
            controllerAs: 'vm',

            resolve: {
                apis: function (appService) {
                    return appService.getApis();
                }
            },
            module: 'ProductOperations'

        });


        
        triMenuProvider.addMenu({
            name: 'RAPORLAR',
            icon: 'zmdi zmdi-chart',
            type: 'dropdown',
            priority: 3.2,
            children: [{
                name: 'Ürün Satış Raporu',
                type: 'link',
                icon: 'zmdi zmdi-money-box',
                state: 'triangular.admin-default.report-sales-products'
            }
            , {
                name: 'Adisyonlar ve Ödemeler',
                type: 'link',
                icon: 'zmdi zmdi-money-box',
                state: 'triangular.admin-default.report-order-operations'
            },
            {
                name: 'Günlük Yönetim İşlemleri',
                type: 'link',
                icon: 'zmdi zmdi-money-box',
                state: 'triangular.admin-default.settlement'
            },
             {
                name: 'Stok Durum Raporu',
                type: 'link',
                icon: 'zmdi zmdi-assignment',
                state: 'triangular.admin-default.report-stock-products-quantity'
            }
            ]
        });

    }
})();