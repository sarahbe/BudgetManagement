(function () {
    'use strict';

    angular
        .module('triangular')
        .provider('triAuthorization', authorizationProvider);

    /* @ngInject */
    function authorizationProvider() {
        // Provider
        var currentUser = {
            isAuthenticated: false,
            access_token: null,
            userName: '',
            userId: '',
            email: '',
            roles: '',
            rights: ["public"],
            pin: 0,
            restaurantId: ''
        };



        // Service
        this.$get = function () {
            return {




                setCurrentUser: function setCurrentUser(userData) {
                    currentUser = userData;
                },
                cleanCurrentUser: function cleanCurrentUser(name) {
                    currentUser = {
                        isAuthenticated: false,
                        access_token: null,
                        userName: '',
                        userId: '',
                        rights: ["public"],
                        roles: '',
                        pin: 0,
                        restaurantId: '',
                        emailConfirmed:true,
                        packageDueDate:'',
                        isBlockWaiterPayment:false,
                        isBlockWaiterDelete:false
                    };
                },

                isAuthenticated: function () {

                    return currentUser.isAuthenticated;
                },
                getAccessToken: function () {

                    return currentUser.access_token;

                },
                getUserName: function () {

                    return currentUser.userName;

                },
                getUserId: function () {
                    // return 1;//currentUser.userId;
                    return currentUser.userId;
                },
                getEmail: function () {
                    return currentUser.email;
                },
                getRights: function () {
                    return currentUser.rights;
                },
                getRoles: function () {
                    return currentUser.roles;
                },
                getPin: function () {
                    return currentUser.pin;
                },
                getRestaurantId: function () {
                    return currentUser.restaurantId;
                },
                emailConfirmed: function () {
                    return currentUser.emailConfirmed && JSON.parse(currentUser.emailConfirmed);

                },
                packageDueDate: function() {
                    return new Date(currentUser.packageDueDate);
                },
                isBlockWaiterPayment: function() {
                    return currentUser.isBlockWaiterPayment && JSON.parse(currentUser.isBlockWaiterPayment);
                },
                isBlockWaiterDelete: function() {
                    return currentUser.isBlockWaiterDelete && JSON.parse(currentUser.isBlockWaiterDelete);
                },
                isAdmin: function() {
                    return currentUser.isAdmin && JSON.parse(currentUser.isAdmin);
                },
                isWaiter: function() {
                    return currentUser.isWaiter && JSON.parse(currentUser.isWaiter);
                }


            };
        };
    }
})();

