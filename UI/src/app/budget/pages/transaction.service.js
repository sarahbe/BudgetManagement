(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .factory('transactionService', transactionService);

    /* @ngInject */
    function transactionService($state, appService, $q, triAuthenticationService, apiSettings, triAuthorization) {
        // Service
        return {
            saveTransaction:saveTransaction
        };
        /// 

        function saveTransaction(data) {

            var deffered = $q.defer();

            appService.postData('api/transactions/create', data).then(function (response) {

                deffered.resolve(response);

            });

            return deffered.promise;
        };
        
 
    };

})();