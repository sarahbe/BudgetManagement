(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .controller('CategoryListController', CategoryListController);

    /* @ngInject */
    function CategoryListController($state, $filter, $mdDialog, categoryService, triAuthorization) {
        var vm = this;
        vm.init = init;
        vm.newCategory = newCategory;
        vm.editCategory = editCategory;

        init();
       
       function init(){
            categoryService.getCategorys(triAuthorization.getUserId()).then(function(res){
                vm.categorys = res;
            });
       }

        function newCategory($event) {
             $mdDialog.show({
                    templateUrl: 'app/budget/pages/category/category.tmpl.html',
                    targetEvent: $event,
                    controller: 'CategoryController',
                    controllerAs: 'vm',
                    parent: angular.element(document.body)
                })
                .then(function (response) {  
                        init();                  
                });
        }

        function editCategory($event, category) {
             $mdDialog.show({
                    templateUrl: 'app/budget/pages/category/category.tmpl.html',
                    targetEvent: $event,
                    controller: 'CategoryController',
                    controllerAs: 'vm',
                     parent: angular.element(document.body),
                    locals: {               
                        category: angular.copy(category)         
                    }
                })
                .then(function (response) {                        
                });
        }
    }

})();
