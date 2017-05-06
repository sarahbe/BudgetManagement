﻿(function() {
    'use strict';

    angular
        .module('triangular.components')
        .service('triAuthenticationService', AuthenticationService);

    /* @ngInject */
    function AuthenticationService($http, $window,API_CONFIG,triAuthorization, $cookies) {
              var tokenInfo;  
  
            this.setTokenInfo = function (data) {  
                tokenInfo = data; 
             
               triAuthorization.setCurrentUser(data);
         
               $cookies.put("LokantAppToken", JSON.stringify(tokenInfo), { 'expires': data.expires });
            this.setHeader($http);
 
            }  
  
            this.getTokenInfo = function () {  
                return tokenInfo;  
            }  
  
            this.removeToken = function () {  
                tokenInfo = null;  
                $cookies.remove("LokantAppToken");
                 this.setHeader($http);
                 triAuthorization.cleanCurrentUser();
            }  
            this.IsAutanticate = function () {  
                if ($cookies.get("LokantAppToken")) {  
                  return true;
                  
                } 
                else{
                return false;
                } 
            }
            this.IsLocked = function () {
                if (this.getTokenInfo() && this.getTokenInfo().isLock) {
                    return true;

                }
                else {
                    return false;
                }
            }
            this.init = function () {  
                if ($cookies.get("LokantAppToken")) {  
                    tokenInfo = JSON.parse($cookies.get("LokantAppToken"));  
                     triAuthorization.setCurrentUser(tokenInfo);
                    this.setHeader($http);
                }  
            }  
  
            this.setHeader = function (http) {  
                delete http.defaults.headers.common['X-Requested-With'];  
                if ((tokenInfo != undefined) && (tokenInfo.accessToken != undefined) && (tokenInfo.accessToken != null) && (tokenInfo.accessToken != "")) {  
                    http.defaults.headers.common['Authorization'] = 'Bearer ' + tokenInfo.accessToken;  
                    http.defaults.headers.common['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';  
                }  
            }  
       this.validateRequest = function () {  
            var url = API_CONFIG + 'api/validate';  
            var deferred = $q.defer();  
            $http.get(url).then(function () {  
                 deferred.resolve(null);  
            }, function (error) {  
                    deferred.reject(error);  
            });  
            return deferred.promise;  
        }  
            this.init(); 
    }
})();