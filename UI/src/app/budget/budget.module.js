(function () {
    'use strict';

    angular
        .module('app.budget', [
        'app.budget.pages', 'app.budget.authentication'
        ]).run(runFunction);
        
})();

function runFunction($rootScope, $window, $state, appService, apiSettings, API_CONFIG, triAuthenticationService, triMenu, triAuthorization, triLoaderService) {
    $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
        triLoaderService.setLoaderActive(false);

        if (toState.module != undefined && toState.module == 'public') {

        } else if (triAuthenticationService.IsAutanticate()) {
    	    
            var allstates = $state.get();
            var currentUserRights = triAuthorization.getRights();

            for (var i = 0; i < allstates.length; i++) {

                var currentState = allstates[i];

                if (currentState.module != undefined) {

                    
                    var isRightExsist = $window._.contains(currentUserRights, currentState.module);
                    if (!isRightExsist) {
                        triMenu.removeMenu(allstates[i].name, undefined);
                    }

                }

            }
            if (toState.module != undefined) {


                var isRightExsist = currentUserRights.indexOf(toState.module);

                if (isRightExsist < 0) {
                    event.preventDefault();

                    $state.go('authentication.login');
                }
            }
          
        }
        else {
             event.preventDefault();

             $state.go('authentication.login');
        }         
    });

 

}