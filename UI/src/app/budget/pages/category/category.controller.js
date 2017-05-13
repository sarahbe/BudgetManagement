(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .controller('CategoryController', CategoryController);

    /* @ngInject */
    function CategoryController($state, $filter, $mdDialog, categoryService, category, lookupService,  triAuthorization) {
        var vm = this;
        vm.init = init;
        vm.saveCategory = saveCategory;
        vm.deleteCategory = deleteCategory;
        vm.category = category;
        init();

        function init() {

        }

        function saveCategory(){
            vm.category.userId = triAuthorization.getUserId();
            categoryService.saveCategory(vm.category).then(function (res) {

                 $mdDialog.hide(res);
                 
            });
        }
          function deleteCategory(){
            categoryService.deleteCategory(vm.category).then(function (res) {

                 $mdDialog.hide(res);
                 
            });
        }

    }

})();
