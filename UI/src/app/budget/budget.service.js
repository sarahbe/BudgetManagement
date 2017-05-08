'use strict';

(function () {
    'use strict';

    angular
        .module('app.budget')
        .factory('appService', appService);

    /* @ngInject */
    function appService($http, $q, triLoaderService, $mdToast, $mdDialog,$state, triAuthenticationService, triSettings, apiSettings, appNotifyService, API_CONFIG, Upload) {
        // Service

        return {
            postData: postData,            
            getData: getData,
            putData: putData

        };
        ///
        function alertDialog(title, msg) {
            //appNotifyService.alert(title, msg, 'Kapat');
            appNotifyService.warning(msg);
        };

        function handleSuccess(defferd, response) {
            triLoaderService.setLoaderActive(false);
            var data = response.data;
            defferd.resolve(data);
        };

        function handleError(defferd, response) {
            triLoaderService.setLoaderActive(false);
            var data = response.data;

            var msg = 'Sorry we are having an error. Please try again later.';
            var title = 'Error...';

             if (response.status == "401") {
     
                msg = null;
                 $state.go('authentication.login');


            } else if (response.status == "403") {

                msg = null;
                appNotifyService.warning('Mevcut işlemi yapmak için yetkiniz bulunmamaktadır.');
 

            }
            else if (response.status == "406") {
                msg = response.data;
            }
            else if (response.status == "500") {
                //Api'de Exception fırlatırsa buraya düşüyor
                msg = null;
                appNotifyService.warning('Sorry!Something went wrong. We will fix it as soon as possible');
            }
            else if (response.status == -1) {
                //Api'ye bağlanamazsa buraya
                msg = null;
                appNotifyService.warning('The application is down.');
            }
            else if (angular.isString(data)) {
                msg = data;
            } else if (angular.isObject(data)) {
                title = 'Error';

                //msg = response.message;

                if (data.error == 'invalid_grant') {
                    title = 'Invalid log in inforamtion';
                    msg = data.error_description;
                }

                if (data.message != undefined) {
                    title = 'Error';
                    msg = data.message;

                    if (data.exceptionMessage != undefined) {
                        title = data.message;
                        msg = data.exceptionMessage;
                    }
                }
                if (data.Message != undefined) {
                    title = 'Error';
                    msg = data.Message;

                }

            }

            if (msg)
                alertDialog(title, msg);

            defferd.reject(data);

        };      

        function postData(url, data) {
            $http.defaults.useXDomain = true;
            var deffered = $q.defer();
   
            var server = '';
            if (url.indexOf('http') < 0) {                
                server = API_CONFIG.baseApiAdress + '/';
            }
            triLoaderService.setLoaderActive(true);

            if (data == undefined) {
                data = {};
            }

            var request = $http({
                method: 'post',
                url: server + url,

                'crossDomain': true,
                data: data,
                headers: {
                    //  'content-type': 'application/json',
                    //  'accept': 'application/json',
                    'cache-control': 'no-cache',

                }
            }).then(function (response) {
                handleSuccess(deffered, response);
            }, function (response) {
                handleError(deffered, response);
            }
            );

            return deffered.promise;


        };

        function putData(url, data) {
            $http.defaults.useXDomain = true;
            var deffered = $q.defer();

            //TODO: Belki apisettings provider'a taşınabilir
            var server = '';
            if (url.indexOf('http') < 0) {                
                server = API_CONFIG.baseApiAdress + '/';
            }
            triLoaderService.setLoaderActive(true);

            if (data == undefined) {
                data = {};
            }

            var request = $http({
                method: 'put',
                url: server + url,

                'crossDomain': true,
                data: data,
                headers: {
                    //  'content-type': 'application/json',
                    //  'accept': 'application/json',
                    'cache-control': 'no-cache',

                }
            }).then(function (response) {
                handleSuccess(deffered, response);
            }, function (response) {
                handleError(deffered, response);
            }
            );

            return deffered.promise;


        };

        function getData(url, data, method) {
            $http.defaults.useXDomain = true;
            var deffered = $q.defer();

            if (!method) {
                method = 'get';
            }

           var server = '';
            if (url.indexOf('http') < 0) {                
                server = API_CONFIG.baseApiAdress + '/';
            }

            //show loading icon
            triLoaderService.setLoaderActive(true);

            if (!data) {
                data = {};
            }
           
            var request = $http({
                method: method,
                url: server + url, 
                headers: {
                    'content-type': 'application/json',
                    'accept': 'application/json',
                    'cache-control': 'no-cache',
                },
                params: data
            }).then(function (response) {
                handleSuccess(deffered, response);
            }, function (response) {
                handleError(deffered, response);
            }
            );        

            return deffered.promise;

        };
       

    };

})();