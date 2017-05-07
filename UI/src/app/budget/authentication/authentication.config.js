(function () {
    'use strict';

    angular
        .module('app.budget.authentication')
        .config(moduleConfig);

    /* @ngInject */
    function moduleConfig($translatePartialLoaderProvider, $stateProvider, triMenuProvider) {
        $translatePartialLoaderProvider.addPart('app/budget/authentication');




        $stateProvider
        .state('authentication', {
            abstract: true,
            templateUrl: 'app/budget/authentication/layouts/authentication.tmpl.html'
        })
            .state('authentication.login', {
                url: '/login',
                templateUrl: 'app/budget/authentication/login/login.tmpl.html',
                controller: 'LoginController',
                controllerAs: 'vm',              
                module: 'public'
            })
            .state('authentication.signup', {
                url: '/signup',
                templateUrl: 'app/budget/authentication/signup/signup.tmpl.html',
                controller: 'SignupController',               
                controllerAs: 'vm',                
                module: 'public'
            })
            .state('authentication.lock', {
                url: '/lock',
                templateUrl: 'app/budget/authentication/lock/lock.tmpl.html',
                controller: 'LockController',
                controllerAs: 'vm', 
                module: 'public'

            })
            .state('authentication.confirm', {
                url: '/confirm?userId&code',
                templateUrl: 'app/budget/authentication/confirm/confirm.tmpl.html',
                controller: 'ConfirmController',
                controllerAs: 'vm',
                module: 'public'
            }).state('authentication.forgot', {
                url: '/forgot',
                templateUrl: 'app/budget/authentication/forgot/forgot.tmpl.html',
                controller: 'ForgotController',
                controllerAs: 'vm',
                module: 'public'
            })
            .state('authentication.forgot-reset', {
                url: '/forgot-reset?userId&code',
                templateUrl: 'app/budget/authentication/forgot-reset/forgot-reset.tmpl.html',
                controller: 'ForgotResetController',
                controllerAs: 'vm',
                module: 'public'
            }).state('authentication.forgotsuccess', {
                url: '/forgotsuccess',
                templateUrl: 'app/budget/authentication/forgotsuccess/forgot.tmpl.html',
                controller: 'ForgotSuccessController',
                controllerAs: 'vm',
                module: 'public'
            });

    
    }
})();