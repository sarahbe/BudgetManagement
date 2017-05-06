(function () {
    'use strict';

    angular
        .module('app.budget.dashboards')
        .factory('dashboardsService', dashboardsService);

    /* @ngInject */
    function dashboardsService($state, appService, $q, triAuthenticationService, apiSettings, triAuthorization) {
        // Service
        return {
           
            getTableStatusByPercent:getTableStatusByPercent,
            getTotalSalesByDateRange:getTotalSalesByDateRange,
            getGeneralDashboardData:getGeneralDashboardData
        };
        ///
 
    

        function getGeneralDashboardData() {

            var deffered = $q.defer();

            appService.postData(apiSettings.config.Apis.API_REPORTING_GET_GENERAL_DASHBOARD_DATA.Address, {}).then(function (response) {

                deffered.resolve(response);

            });

            return deffered.promise;
        };
        function getTotalSalesByDateRange(data) {

            var deffered = $q.defer();

            appService.postData(apiSettings.config.Apis.API_REPORTING_GET_TOTAL_SALES_BY_DATE_RANGE.Address, data).then(function (response) {

                deffered.resolve(response);

            });

            return deffered.promise;
        };
        function getTableStatusByPercent() {

            var deffered = $q.defer();

            appService.postData(apiSettings.config.Apis.API_REPORTING_GET_TABLE_STATUS_BY_PERCENT.Address, {}).then(function (response) {

                deffered.resolve(response);

            });

            return deffered.promise;
        };
        
 
    };

})();