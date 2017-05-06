(function() {
    'use strict';

    angular
        .module('app.budget')
        .provider('apiSettings', apiSettingsProvider);

 
    /* @ngInject */
    function apiSettingsProvider() {
 
        var config = {};
        return ({
  
            $get: instantiate
        });
 
        
        function instantiate() {
            
             
            return ({
                config: this.config,
                init: function (data) {
                    this.config = data;
                }
            });
        };
         
    }
})();

