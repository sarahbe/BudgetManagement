(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .factory('accountRightService', accountRightService);

    /* @ngInject */
    function accountRightService($state, appService, $q) {
        // Service
        return {
            getAccountRights: getAccountRights,
            saveAccountRight: saveAccountRight,
            deleteAccountRight:deleteAccountRight
        };
        /// 

        function getAccountRights(accountId) {

            var deffered = $q.defer();
            var data = {
              accountId: accountId
            };
            appService.getData('api/accountRights/GetAll', data).then(function (response) {
                //notify the end of promise request    
                deffered.resolve(response);

            });

            return deffered.promise;
        };


        function saveAccountRight(accountRight) {

                var deffered = $q.defer();
        
                appService.postData('api/accountRights/Create', accountRight).then(function (response) {
                    //notify the end of promise request    
                    deffered.resolve(response);

                });

                return deffered.promise;
        }

         function deleteAccountRight(accountRight) {

                var deffered = $q.defer();
        
                appService.putData('api/accountRights/Delete', accountRight).then(function (response) {
                    //notify the end of promise request    
                    deffered.resolve(response);

                });

                return deffered.promise;
        }


    };

})();
