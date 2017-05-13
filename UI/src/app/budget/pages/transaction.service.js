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
            getTransactions:getTransactions,
            deleteTransaction:deleteTransaction
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
        
         function deleteTransaction(data) {

            var deffered = $q.defer();

            appService.putData('api/transactions/delete', data).then(function (response) {
                //notify the end of promise request    
                deffered.resolve(response);

            });

            return deffered.promise;
        };
        function getTransactions(userId) {

            var deffered = $q.defer();
            var data = {
                userId: userId
            };

            appService.getData('api/transactions/GetAll', data).then(function (response) {

                deffered.resolve(response);

            });

            return deffered.promise;
        };
 
    };

})();