(function() {
    'use strict';

    angular
        .module('app', [
            'triangular',
            'ngAnimate', 'ngCookies', 'ngMessages', 'ngMaterial',
            'ui.router', 'pascalprecht.translate', 'LocalStorageModule',
            'chart.js', 'linkify', 'ui.calendar', 'angularMoment', 'textAngular', 'md.data.table', angularDragula(angular), 'ngFileUpload', 'xeditable',            
            // uncomment above to activate the example seed module
            'app.budget',
            'rt.popup',
            'ngWebSocket', 'ngAudio'
        ])
        //Bu kısım proda geçilirken aktif hale getirilmeli
        // .config([
        //     '$compileProvider', function($compileProvider) {
        //         $compileProvider.debugInfoEnabled(false);
        //     }
        // ])
        // create a constant for languages so they can be added to both triangular & translate
        .constant('APP_LANGUAGES', [
            {
                name: 'LANGUAGES.ENGLISH',
                key: 'en'
            }
        ])
        // set a constant for the API we are connecting to
        .constant('API_CONFIG', {
            // baseApiAdress :  'http://localhost:14562'
            baseApiAdress :  'http://bounbudget.azurewebsites.net'
        }); 


    navigator.serviceWorker && navigator.serviceWorker.register('../sw.js').then(function(registration) {
    });

})();