(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .factory('dashboardService', dashboardService);

    /* @ngInject */
    function dashboardService($state, appService, $q) {
        // Service
        return {
            getCardStats:getCardStats,
            transactionsThisMonth:transactionsThisMonth,
            transactionsByCategory:transactionsByCategory
        };
        /// 

        function getCardStats(accountId) {

            var deffered = $q.defer();
            var data = {
                accountId: accountId
            };
            appService.getData('api/dashboards/cardStats', data).then(function (response) {
                deffered.resolve(response);
            });

            return deffered.promise;
        }

        function transactionsThisMonth(accountId) {

            var deffered = $q.defer();
            var data = {
                accountId: accountId
            };
            appService.getData('api/dashboards/transactionsThisMonth', data).then(function (response) {
                deffered.resolve(response);
            });

            return deffered.promise;
        }       
        
         function transactionsByCategory(accountId) {

            var deffered = $q.defer();
            var data = {
                accountId: accountId
            };
            appService.getData('api/dashboards/transactionsByCategory', data).then(function (response) {
                deffered.resolve(response);
            });

            return deffered.promise;
        }
 
    };

})();