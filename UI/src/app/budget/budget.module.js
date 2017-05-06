(function () {
    'use strict';

    angular
        .module('app.budget', [
        'app.budget.pages'
        ]).run(runFunction);       
        
})();

function runFunction($rootScope, $window, $state, appService, apiSettings, API_CONFIG, triAuthenticationService, triMenu, triAuthorization, triLoaderService) {
    $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
        triLoaderService.setLoaderActive(false);

        if (toState.module != undefined && toState.module == 'public') {
            // event.preventDefault();

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
        else if (triAuthenticationService.IsAutanticate() == false) {
            // event.preventDefault();

            // $state.go('authentication.login');
        } 
        if (toState.name != 'authentication.lock' && toState.name != 'authentication.login' && toState != 'triangular.kitchen.kitchen-screen' && triAuthenticationService.IsLocked() == true) {
            // event.preventDefault();
            // $state.go('authentication.lock');            
        }
    });

 

}