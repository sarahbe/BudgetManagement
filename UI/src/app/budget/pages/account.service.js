(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .factory('accountService', accountService);

    /* @ngInject */
    function accountService($state, appService, $q) {
        // Service
        return {
            getAccounts: getAccounts,
            getAccountTypes: getAccountTypes,
            getCurrencies: getCurrencies,
            saveAccount: saveAccount
        };
        /// 

        function getAccounts(userId) {

            var deffered = $q.defer();
            var data = {
                userId: userId
            };
            appService.getData('api/accounts/GetAll', data).then(function (response) {
                //notify the end of promise request    
                deffered.resolve(response);

            });

            return deffered.promise;
        };

        function getAccountTypes(){
             var deffered = $q.defer();          
            appService.getData('api/accounts/GetAccountTypes', {}).then(function (response) {
                //notify the end of promise request    
                deffered.resolve(response);
            });

            return deffered.promise;
        }

         function getCurrencies(){
             var deffered = $q.defer();          
            appService.getData('api/accounts/getCurrencies', {}).then(function (response) {
                //notify the end of promise request    
                deffered.resolve(response);
            });

            return deffered.promise;
        }

        function saveAccount(account) {

                var deffered = $q.defer();
                
                appService.postData('api/accounts/Create', account).then(function (response) {
                    //notify the end of promise request    
                    deffered.resolve(response);

                });

                return deffered.promise;
        }


    };

})();
