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
            transactionsThisMonth:transactionsThisMonth
        };
        /// 

        function getCardStats(userId) {

            var deffered = $q.defer();
            var data = {
                userId: userId
            };
            appService.getData('api/dashboards/cardStats', data).then(function (response) {
                deffered.resolve(response);
            });

            return deffered.promise;
        }

        function transactionsThisMonth(userId) {

            var deffered = $q.defer();
            var data = {
                userId: userId
            };
            appService.getData('api/dashboards/transactionsThisMonth', data).then(function (response) {
                deffered.resolve(response);
            });

            return deffered.promise;
        }       
        
 
    };

})();