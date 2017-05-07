(function () {
    'use strict';

    angular
        .module('app.budget.authentication')
        .controller('ForgotResetController', ForgotResetController);

    /* @ngInject */
    function ForgotResetController($scope, $state,$stateParams, $mdToast, $filter, $http, triSettings, API_CONFIG, authenticationService, appNotifyService, exPatterns) {
        var vm = this;
        vm.triSettings = triSettings;
        vm.user = {
            email: '',
            userId: 0,
            code: "",
            newPassword: ""
        };

        vm.exPatterns = exPatterns;

        vm.resetPasswordClick = resetPasswordClick;

        ////////////////

        function resetPasswordClick() {

            vm.submitted = true;
            if(!vm.password.$valid)
                return;

            vm.user.userId = $stateParams.userId;
            vm.user.code = $stateParams.code;
        
            if (vm.user.userId == undefined || vm.user.code == undefined) {
                $state.go('404');
            }

            authenticationService.resetUserPassword(vm.user).then(function (response) {

                appNotifyService.success('Şifreniz  değiştirilmiştir...');


                var postmodel = { grant_type: "password", password: vm.user.newPassword, username: response.userName }

                authenticationService.login($.param(postmodel)).then(function (result) {

                    $state.go('triangular.admin-default.dashboard-general');

                });


            });
        }
    }
})();
