(function () {
    'use strict';

    angular
        .module('app.budget.authentication')
        .factory('authenticationService', authenticationService);

    /* @ngInject */
    function authenticationService($state,$window, appService, $q, triAuthenticationService, apiSettings, triAuthorization) {
        // Service
        return {
            login: login,
            signUp: signUp,
            confirm: confirm,
            forgot: forgot,
            // sendActivationMail: sendActivationMail,
            resetUserPassword: resetUserPassword,
            setUserData: setUserData
        };
        ///
        
        // function sendActivationMail() {
        //     var deffered = $q.defer();

        //     appService.postData("api/users/activation").then(function (response) {

              
        //         deffered.resolve(response);

        //     });

        //     return deffered.promise;
        // }
        function resetUserPassword(data) {
            var deffered = $q.defer();

            appService.postData("api/users/reset", data).then(function (response) {


                deffered.resolve(response);

            });

            return deffered.promise;
        }
        function login(data) {

            var deffered = $q.defer();

            appService.postData("oauth/token", data).then(function (response) {

                var userData = setUserData(response);

                deffered.resolve(userData);

            });

            return deffered.promise;
        };

        function setUserData(response){
                var roles = JSON.parse(response.roles);
                var rights = [];
                rights.push('public');

            var userData = {
                isAuthenticated: true,
                accessToken: response.access_token,
                expiresIn: response.expires_in,
                tokenType: response.token_type,
                userName: response.userName,
                userId: response.userId,
                email: response.email,
                rights: rights,
                roles: roles,                
                expires: response[".expires"]
        };

                triAuthenticationService.setTokenInfo(userData);
                
                return userData;
        }                

        function signUp(user) {

            var deffered = $q.defer();

            appService.postData('api/users/create', user).then(function (response) {

                deffered.resolve(response);

            });

            return deffered.promise;
        }; 

        function forgot(user) {

            var deffered = $q.defer();

            appService.postData('api/users/ChangePassword', user).then(function (response) {

                deffered.resolve(response);

            });

            return deffered.promise;
        };



        function confirm(data) {

            var deffered = $q.defer();

            appService.postData('api/users/ConfirmEmail', data).then(function (response) {

                var userData = {
                    isAuthenticated: false,
                    accessToken: '',
                    expiresIn: '',
                    tokenType: '',
                    userName: response.UserName,
                    userId: response.UserId,
                    email:response.Email
                };

                triAuthorization.setCurrentUser(userData);
                var datas = triAuthorization.getUserName();
                deffered.resolve(response);

            });

            return deffered.promise;
        };
    };

})();