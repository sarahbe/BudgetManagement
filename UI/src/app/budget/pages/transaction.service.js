(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .factory('transactionService', transactionService);

    /* @ngInject */
    function transactionService($state, appService, $q) {
        // Service
        return {
            saveTransaction:saveTransaction,
            getTransaction:getTransaction
        };
        /// 

        function saveTransaction(data) {

            var deffered = $q.defer();

            appService.postData('api/transactions/create', data).then(function (response) {
                //notify the end of promise request    
                deffered.resolve(response);

            });

            return deffered.promise;
        };
        
        function getTransaction(id) {

            var deffered = $q.defer();

            appService.postData('api/transactions/create', data).then(function (response) {

                deffered.resolve(response);

            });

            return deffered.promise;
        };
 
    };

})();