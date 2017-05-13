(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .factory('lookupService', lookupService);

    /* @ngInject */
    function lookupService($state, appService, $q) {
        // Service
        return {
            getCategories:getCategories,
            getAccounts:getAccounts
        };
        /// 

        function getCategories(typeId, userId) {

            var deffered = $q.defer();
            var data = {
                transactionTypeId: typeId,
                userId: userId
            };
            appService.getData('api/categories/GetAllByType', data).then(function (response) {
                //notify the end of promise request    
                deffered.resolve(response);

            });

            return deffered.promise;
        };       
        
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
 
    };

})();