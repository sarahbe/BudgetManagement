(function () {
    'use strict';

    angular
        .module('app.lokantapp.reporting')
        .controller('ReportSalesProductsController', ReportSalesProductsController);

    /* @ngInject */
    function ReportSalesProductsController($scope, $state, utilityService, $window, $mdDialog, $mdToast, accountService, $rootScope, appNotifyService, reportingService) {
        var vm = this;
        vm.setDayClick = setDayClick;
        vm.today = new Date();
        vm.thisDay = vm.today.getDate() - 1;
        vm.thisYearDay = Math.ceil((vm.today.getTime() - (new Date(vm.today.getFullYear(), 0, 0, 0, 0, 0, 0)).getTime()) / (1000 * 60 * 60 * 24)) - 1;
        vm.exportFile = exportFile;
        vm.request = {
            startDateTimeLocal: new Date(vm.today.getFullYear(), vm.today.getMonth(), vm.today.getDate(), 0, 0, 0, 0),
            endDateTimeLocal: new Date(vm.today.getFullYear(), vm.today.getMonth(), vm.today.getDate(), 23, 59, 59, 59),
            limit: 10000
        }
        vm.createReportClick = createReportClick;

        vm.productsData = {
            results: [],
            total: {
                quantity: 0,
                sum: 0
            }
        }
        vm.categoriesData = {
            results: [],
            total: {
                quantity: 0,
                sum: 0
            }
        }
        vm.areasData = {
            results: [],
            total: {
                quantity: 0,
                sum: 0
            }
        }
        vm.init = init;

        vm.restaurantUsers = {};

        init();

        function init() {

            vm.request.startDateTimeLocal.setDate(vm.request.startDateTimeLocal.getDate() - 7);
            createReportClick();
        };

        function exportFile(selector, mimType) {

            $(selector).tableExport({
                type: mimType,
                escape: 'false'
            });


        }

        function setDayClick(day) {
            vm.request.startDateTimeLocal = new Date(vm.today.getFullYear(), vm.today.getMonth(), vm.today.getDate(), 0, 0, 0, 0);
            vm.request.endDateTimeLocal = new Date(vm.today.getFullYear(), vm.today.getMonth(), vm.today.getDate(), 23, 59, 59, 59);

            vm.request.startDateTimeLocal.setDate(vm.request.startDateTimeLocal.getDate() - day);
            createReportClick();
        }

        function createReportClick() {
            resetModel();



            vm.request.startDateTime = new Date(vm.request.startDateTimeLocal.getFullYear(), vm.request.startDateTimeLocal.getMonth(), vm.request.startDateTimeLocal.getDate(), 0, 0, 0, 0);
            vm.request.endDateTime = new Date(vm.request.endDateTimeLocal.getFullYear(), vm.request.endDateTimeLocal.getMonth(), vm.request.endDateTimeLocal.getDate(), 23, 59, 59, 59);


            reportingService.getTopSalesByProduct(vm.request).then(function (response) {
                vm.productsData.results = response;
                angular.forEach(vm.productsData.results, function (item) {
                    vm.productsData.total.quantity += item.quantity;
                    vm.productsData.total.sum += item.sum;
                });
                angular.forEach(vm.productsData.results, function (item) {
                    item.percent = (item.sum * 100 / vm.productsData.total.sum).toFixed(2);
                });
            });

            reportingService.getTopSalesByCategory(vm.request).then(function (response) {

                vm.categoriesData.results = response;
                angular.forEach(vm.categoriesData.results, function (item) {
                    vm.categoriesData.total.quantity += item.quantity;
                    vm.categoriesData.total.sum += item.sum;
                });
                angular.forEach(vm.categoriesData.results, function (item) {
                    item.percent = (item.sum * 100 / vm.categoriesData.total.sum).toFixed(2);
                    item.percentQuantity = (item.quantity * 100 / vm.categoriesData.total.quantity).toFixed(2);
                });

            });

            reportingService.getTopSalesByArea(vm.request).then(function (response) {
                vm.areasData.results = response;
                angular.forEach(vm.areasData.results, function (item) {
                    vm.areasData.total.sum += item.sum;
                });
                angular.forEach(vm.areasData.results, function (item) {
                    item.percent = (item.sum * 100 / vm.areasData.total.sum).toFixed(2);
                });

            });

        };


        // private funcs
        function resetModel() {
            vm.productsData = {
                results: [],
                total: {
                    quantity: 0,
                    sum: 0
                }
            }
            vm.categoriesData = {
                results: [],
                total: {
                    quantity: 0,
                    sum: 0
                }
            }
            vm.areasData = {
                results: [],
                total: {
                    quantity: 0,
                    sum: 0
                }
            }
        }

    }
})();
