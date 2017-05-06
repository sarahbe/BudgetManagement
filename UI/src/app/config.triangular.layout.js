(function() {
    'use strict';

    angular
        .module('app')
        .config(config);

    /* @ngInject */
    function config(triLayoutProvider, $httpProvider, $cookiesProvider) {
        triLayoutProvider.setDefaultOption('toolbarSize', 'default');

        triLayoutProvider.setDefaultOption('toolbarShrink', false);

        triLayoutProvider.setDefaultOption('toolbarClass', '');

        triLayoutProvider.setDefaultOption('contentClass', '');
      
        triLayoutProvider.setDefaultOption('sideMenuSize', 'icon');

        triLayoutProvider.setDefaultOption('showToolbar', true);

        triLayoutProvider.setDefaultOption('footer', false);
        
        $cookiesProvider.defaults = { path: '/' };

        
        // burası sistemdeki http status codlar dinlenerek gerekli yönlendirmeler yapılır.
        $httpProvider.interceptors.push(function ($q, $injector) {

            return {


                'responseError': function (rejection) {
                
                    var defer = $q.defer();            

                    defer.reject(rejection);

                    return defer.promise;

                }
            };
        });
    }
})();