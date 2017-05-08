(function () {
    'use strict';

    angular
        .module('app.lokantapp.reporting')
        .factory('reportingService', reportingService);

    /* @ngInject */
    function reportingService($state, appService, $q, triAuthenticationService, apiSettings, triAuthorization) {
        // Service
        return {
           
            getTopSalesByProduct: getTopSalesByProduct,
            getSumTopSales: getSumTopSales,
            getTopSalesByCategory: getTopSalesByCategory,
            getTopSalesByArea: getTopSalesByArea,
            getOrderOperations: getOrderOperations,
            getOrderViewModel: getOrderViewModel,
            getPaymentTypesByTotalOrder: getPaymentTypesByTotalOrder,
            getPaymentTypesByOrderType: getPaymentTypesByOrderType,
            getStockQuantytyByProduct: getStockQuantytyByProduct,


        };
    

    function getStockQuantytyByProduct() {

            var deffered = $q.defer();

            appService.postData(apiSettings.config.Apis.API_REPORTING_GET_STOCK_QUANTITY_BY_PRODUCT.Address, {}).then(function (response) {

                deffered.resolve(response);

            });

            return deffered.promise;
        };

        function getPaymentTypesByTotalOrder(request) {

            var deffered = $q.defer();

            appService.postData(apiSettings.config.Apis.API_REPORTING_GET_PAYMENT_TYPE_BY_TOTAL_ORDER.Address, request).then(function (response) {

                deffered.resolve(response);

            });

            return deffered.promise;
        };

         function getPaymentTypesByOrderType(request) {

            var deffered = $q.defer();

            appService.postData('api/reporting/GetPaymentTypesByOrderType', request).then(function (response) {

                deffered.resolve(response);

            });

            return deffered.promise;
        };
        
        function getOrderViewModel(request) {

            var deffered = $q.defer();

            appService.postData(apiSettings.config.Apis.API_REPORTING_GET_ORDER_VIEW_MODEL.Address, request).then(function (response) {

                deffered.resolve(response);

            });

            return deffered.promise;
        };

        function getSumTopSales(request) {

            var deffered = $q.defer();

            appService.postData(apiSettings.config.Apis.API_REPORTING_GET_SUM_TOP_SALES.Address, request).then(function (response) {

                deffered.resolve(response);

            });

            return deffered.promise;
        }

        function getTopSalesByProduct(request) {

            var deffered = $q.defer();
         
            appService.postData(apiSettings.config.Apis.API_REPORTING_GET_TOP_SALES_BY_PRODUCT.Address, request).then(function (response) {

                deffered.resolve(response);

            });

            return deffered.promise;
        };
        function getTopSalesByCategory(request) {

            var deffered = $q.defer();

            appService.postData(apiSettings.config.Apis.API_REPORTING_GET_TOP_SALES_BY_CATEGORY.Address, request).then(function (response) {

                deffered.resolve(response);

            });

            return deffered.promise;
        };

        function getTopSalesByArea(request) {

            var deffered = $q.defer();

            appService.postData('api/reporting/GetTopSalesByArea', request).then(function (response) {

                deffered.resolve(response);

            });

            return deffered.promise;
        };

        function getOrderOperations(request) {

            var deffered = $q.defer();

            appService.postData(apiSettings.config.Apis.API_REPORTING_GET_ORDER_OPERATIONS.Address, request).then(function (response) {

                deffered.resolve(response);

            });

            return deffered.promise;
        };
    };

})();