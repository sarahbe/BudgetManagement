(function () {
    'use strict';

    angular
        .module('app.budget.authentication')
        .controller('SignupController', SignupController);

    /* @ngInject */
    function SignupController($scope, $state, $mdToast, $http, $filter, triSettings, API_CONFIG, triAuthorization, authenticationService, appNotifyService, exPatterns) {
        var vm = this;
        vm.triSettings = triSettings;
        vm.signupClick = signupClick;
        vm.user = {
            Username: '',
            Email: '',
            Password: '',
            MaritalStatus: 0,
            Birthdate:'01.01.1900'

        };
        vm.exPatterns = exPatterns;


        function signupClick() {
            vm.submitted =true;
            
            if(!vm.signup.$valid)
            return;

            authenticationService.signUp(vm.user).then(function (result) {
                if (result.isError) {
                    appNotifyService.alert('Error', result.errorMessage, 'Ok');
                } else {
                    appNotifyService.success('Your account has been created successfully').then(function () {


                    });
                    // var postmodel = { grant_type: 'password', password: vm.user.Password, username: vm.user.Email }
                    // authenticationService.signUp(vm.signUp).then(function (result) {
                    //     $state.go('triangular.admin-default.dashboard-general');
                    //     $state.go('triangular-no-sidebar.wizard');
                    // });
                }
            });

        }


    }
})();