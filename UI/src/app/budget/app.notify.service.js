'use strict';

(function () {
    'use strict';

    angular
        .module('app.budget')
        .factory('appNotifyService', appNotifyService);

    /* @ngInject */
    function appNotifyService($http, $q, $mdToast, $mdDialog) {
        // Service

        return {
            alert: alert,
            warning: warning,
            success: success,
            info: info,
            confirm: confirm,
            message:message

        };
        ///
        function alert(title, msg, okMessage) {
            var defferd = $q.defer();

            $mdDialog.show(
                $mdDialog.alert()
                                .title(title)
                                .content(msg)
                                .ok(okMessage)
            ).then(function () {
                defferd.resolve();
            });

            return defferd.promise;
        };

        ///
        function confirm(title, msg, okMessage, cancelMessage) {
            var defferd = $q.defer();


            var confirm = $mdDialog.confirm()
                .title(title)
                  .textContent(msg)

                .ok(okMessage)
                  .cancel(cancelMessage);
            $mdDialog.show(confirm).then(function () {
                defferd.resolve();
            }, function () {
                defferd.reject();
            });

            return defferd.promise;
        };


        function warning(content) {

            var defferd = $q.defer();
             var el = angular.element(document.getElementById("testt"));

            var toast = $mdToast.simple()
               .textContent(content).parent(el)
               .action('Close')
               .hideDelay(5000)
               .highlightAction(false).theme('warning-toast').position('bottom right');

            $mdToast.show(toast).then(function (response) {
                defferd.resolve();
            });

            return defferd.promise;
        };

        function message(content) {

            var defferd = $q.defer();

            var toast = $mdToast.simple()
               .textContent(content)
               .action('Close')
               .highlightAction(false).theme('success-toast').position('bottom right');;

            $mdToast.show(toast).then(function (response) {
                defferd.resolve();
            });

            return defferd.promise;
        };

        function success(content) {

            var defferd = $q.defer();

            var toast = $mdToast.simple()
               .textContent(content)

               .highlightAction(false).theme('success-toast').position('bottom right');;

            $mdToast.show(toast).then(function (response) {
                defferd.resolve();
            });

            return defferd.promise;
        };
        function info(content) {

            var defferd = $q.defer();

            var toast = $mdToast.simple()
               .textContent(content)
               .action('Close')
               .highlightAction(false).theme('info-toast');

            $mdToast.show(toast).then(function (response) {
                defferd.resolve();
            });

            return defferd.promise;
        };
    };

})();