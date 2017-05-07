(function() {
    'use strict';

    angular
        .module('app.budget')
        .provider('exPatterns', exPatternsProvider);

 
    /* @ngInject */
    function exPatternsProvider() { 


        // Provider
        var patterns = {
            emailPattern: /^[_A-Za-z0-9]+(\.[_A-Za-z0-9]+)*@[A-Za-z0-9-]+(\.[A-Za-z0-9-]+)*(\.[A-Za-z]{2,4})$/,
            phonePattern: /^(5(\d{9}))$/,            
            passwordPattern: /^.{6,}$/          
        };
 

        // Service
        this.$get = function () {
            return {
                emailPattern: patterns.emailPattern,
                phonePattern: patterns.phonePattern,
                passwordPattern: patterns.passwordPattern
            };
        };
         
    }
})();

