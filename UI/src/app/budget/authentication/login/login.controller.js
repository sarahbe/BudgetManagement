(function() {
    'use strict';

    angular
        .module('app.budget.authentication')
        .controller('LoginController', LoginController);

    /* @ngInject */
    function LoginController($state, $window, triSettings, triAuthenticationService, appService, apiSettings, authenticationService, exPatterns) {
  
        var vm = this;
        vm.loginClick = loginClick;


        vm.emailPattern = exPatterns.emailPattern;
        vm.passwordPattern = exPatterns.passwordPattern;
        vm.triSettings = triSettings;
        // create blank user variable for login form
        vm.user = {
            username: '',
            password: ''
        };

        ////////////////

        function loginClick() {
            vm.submitted=true;

            if(!vm.login.$valid)
                return;


            var postmodel = { grant_type: "password", password: vm.user.password, username: vm.user.username }
            
            authenticationService.login(postmodel).then(function (result) { 
                // burada garson ise satış sayfasına yönlendirme yapılıyor.

                authenticationService.redirectUser(result);
              
            });
        
        }
    }
})();