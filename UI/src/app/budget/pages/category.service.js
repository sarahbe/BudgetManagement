(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .factory('categoryService', categoryService);

    /* @ngInject */
    function categoryService($state, appService, $q) {
        // Service
        return {
            getCategorys: getCategorys,
            saveCategory: saveCategory,
            deleteCategory: deleteCategory
        };
        /// 

        function getCategorys(userId) {

            var deffered = $q.defer();
            var data = {
                userId: userId
            };
            appService.getData('api/categories/GetAll', data).then(function (response) {
                //notify the end of promise request    
                deffered.resolve(response);

            });

            return deffered.promise;
        };

     
        function saveCategory(category) {

                var deffered = $q.defer();
                
                appService.postData('api/categories/Create', category).then(function (response) {
                    //notify the end of promise request    
                    deffered.resolve(response);

                });

                return deffered.promise;
        }

        function deleteCategory(category) {

                var deffered = $q.defer();
                
                appService.putData('api/categories/Delete', category).then(function (response) {
                    //notify the end of promise request    
                    deffered.resolve(response);

                });

                return deffered.promise;
        }



    };

})();
