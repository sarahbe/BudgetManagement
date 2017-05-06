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
            emailOrPhonePattern: /^([_aA-zZ0-9]+(\.[_aA-zZ0-9]+)*@[aA-zZ0-9-]+(\.[aA-zZ0-9-]+)*(\.[a-z]{2,4}))|((5(\d{9})))$/,
            passwordPattern: /^.{6,}$/, // /(?=.*[aA-zZ-a!@#\$%\^&\*])(?=.*[0-9])(?=.{6,})/,            
            pinPattern: /^\b\d{4}\b$/
          
        };
 

        // Service
        this.$get = function () {
            return {
                emailPattern: patterns.emailPattern,
                phonePattern: patterns.phonePattern,
                emailOrPhonePattern: patterns.emailOrPhonePattern,
                passwordPattern: patterns.passwordPattern,
                pinPattern: patterns.pinPattern
            };
        };
         
    }
})();

