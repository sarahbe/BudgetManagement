(function () {
    'use strict';

    angular
        .module('app.budget.dashboards')
        .config(moduleConfig);

    /* @ngInject */
    function moduleConfig($translatePartialLoaderProvider, $stateProvider, triMenuProvider) {
        $translatePartialLoaderProvider.addPart('app/budget/dashboards');

        $stateProvider
        .state('triangular.admin-default.dashboard-general', {
            url: '/dashboards/general',
            templateUrl: 'app/budget/dashboards/general/dashboard-general.tmpl.html',
            controller: 'DashboardGeneralController',            
            controllerAs: 'vm'
        });      
        
        triMenuProvider.addMenu({
            name: 'MENU.DASHBOARDS.GENERAL',
            icon: 'zmdi zmdi-home',
            state: 'triangular.admin-default.dashboard-general',
            type: 'link',
            priority: 1.1

        });
        
        // triMenuProvider.addMenu({
        //     name: 'Admin',
        //     icon: 'zmdi zmdi-home',
        //     state: 'triangular.super-admin.admin-dashboard',
        //     type: 'link',
        //     priority: 1.2
        // });
        
        
        //SubMenu      
          triMenuProvider.addMenu({
           name: 'SETTINGS',
           icon: 'zmdi zmdi-settings',
           state: 'triangular.admin-default.addorupdate',           
           type: 'link',
           priority: 1.1,
           position: "bottom"
        });

    }
})();