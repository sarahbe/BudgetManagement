(function() {
    'use strict';

    angular
        .module('app').filter('myDate', function ($filter) {
             var angularDateFilter = $filter('date');
             return function (theDate) {
                   var localTime = moment.utc(theDate).toDate();
                return  moment(localTime).format('YYYY-MM-DD HH:mm:ss');
             }
        })
        .config(routeConfig);

    /* @ngInject */
    function routeConfig($stateProvider, $urlRouterProvider) {
        // Setup the apps routes

        // 404 & 500 pages
        $stateProvider
        .state('404', {
            url: '/404',
            templateUrl: '404.tmpl.html',
            controllerAs: 'vm',
            controller: function($state) {
                var vm = this;                

                vm.goHome = function () {
                     $state.go('triangular.admin-default.dashboard-general');
                };
            }
        })

        .state('500', {
            url: '/500',
            templateUrl: '500.tmpl.html',
            controllerAs: 'vm',
            controller: function($state) {
                var vm = this;
                
                vm.goHome = function() {
                    $state.go('triangular.admin-default.dashboard-general');
                };
            }
        });


        // set default routes when no path specified
        $urlRouterProvider.when('', '/pages/dashboard');
        $urlRouterProvider.when('/', '/pages/dashboard');

        // always goto 404 if route not found
        $urlRouterProvider.otherwise('/404');
    }
})();