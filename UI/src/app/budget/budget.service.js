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
            callServer: callServer,
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

            if (data != undefined) {
                if (data.isError == true) {
                    alertDialog(data.errorTitle, data.errorMessage);
                    defferd.reject(data);


                } else if (data.isError == true) {
                    alertDialog(data.errorTitle, data.errorMessage);
                    defferd.reject(data);

                }
                else {
                    defferd.resolve(data);
                }
            } else {
                defferd.resolve(data);
            }
        };

        function handleError(defferd, response) {
            triLoaderService.setLoaderActive(false);
            var data = response.data;

            var msg = 'sistemde hata oluştu.Lütfen daha sonra tekrar deneyiniz.';
            var title = 'Hata oluştu...';

            if (response.status == "402") {
                //TODO: payment sayfasına yönlendirebiliriz.
                //title = 'Abonelik Süreniz Bitti!';
                //msg = 'Abonelik süreniz sona erdiği için işlem devam edemiyor.';
                msg = null;
                appNotifyService.warning('Abonelik süreniz sona erdiği için işlem devam edemiyor.');
            }
            else if (response.status == "401") {
     
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
                appNotifyService.warning('İşleminiz bir hata ile karşılaştı. Biz gerekli düzeltmeyi yapıyoruz. Lütfen daha sonra tekrar deneyiniz.');
            }
            else if (response.status == -1) {
                //Api'ye bağlanamazsa buraya
                msg = null;
                appNotifyService.warning('adisyo servisine bağlanamıyorsunuz. İnternet bağlantınızı kontrol ediniz.');
            }
            else if (angular.isString(data)) {
                msg = data;
            } else if (angular.isObject(data)) {
                title = 'Hata';

                //msg = response.message;

                if (data.error == 'invalid_grant') {
                    title = 'Kullanıcı girişi onaylanmadı';
                    msg = data.error_description;
                }

                if (data.message != undefined) {
                    title = 'Hata';
                    msg = data.message;

                    if (data.exceptionMessage != undefined) {
                        title = data.message;
                        msg = data.exceptionMessage;
                    }
                }
                if (data.Message != undefined) {
                    title = 'hata';
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

            //TODO: Belki apisettings provider'a taşınabilir
            var server = '';
            if (url.indexOf('http') < 0) {

                var port = "";
                if (apiSettings.config.Servers[0].Port != 0) {
                    port = ':' + apiSettings.config.Servers[0].Port;
                }
                server = apiSettings.config.Servers[0].Address + port + '/';
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
                var port = "";
                if (apiSettings.config.Servers[0].Port != 0) {
                    port = ':' + apiSettings.config.Servers[0].Port;
                }
                server = apiSettings.config.Servers[0].Address + port + '/';
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

        function callServer(url, data, method) {
            $http.defaults.useXDomain = true;
            var deffered = $q.defer();

            if (!method) {
                method = 'get';
            }

            var server = '';
            if (url.indexOf('http') < 0) {
                var port = "";
                if (apiSettings.config.Servers[0].Port != 0) {
                    port = ':' + apiSettings.config.Servers[0].Port;
                }
                server = apiSettings.config.Servers[0].Address + port + '/';
            }


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
                param: data
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