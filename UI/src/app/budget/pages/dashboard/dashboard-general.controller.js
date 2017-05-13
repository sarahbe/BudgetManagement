(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .controller('DashboardGeneralController', DashboardGeneralController);

    /* @ngInject */
    function DashboardGeneralController($state, triAuthorization, dashboardService, $filter) {
        var vm = this;
        vm.init = init;

        init();

        function init() {
            vm.cardStats = {};
                vm.data = [];

            dashboardService.getCardStats(triAuthorization.getUserId()).then(function (res) {
                vm.cardStats.expenseToday = res.expenseToday;
                vm.cardStats.incomeToday = res.incomeToday;
                vm.cardStats.balance = res.balance;
            });

            dashboardService.transactionsThisMonth(triAuthorization.getUserId()).then(function (res) {
                vm.labels = res.days;
                vm.data.push(res.incomeStats);
                vm.data.push(res.expenseStats);
            });

            vm.series = ['Income', 'Expense'];
            vm.options = {
                datasetFill: false
            };



            vm.pieLabels = ['Shopping', 'Oil', 'Bills', 'Education'];
            vm.pieOptions = {
                datasetFill: false
            };
            vm.pieData = [25, 15, 35, 25];


            vm.barSeries = ['Income', 'Expense'];
            vm.barLabels = ['15-25', '25-35', '35-50', '50-70'];
            vm.barData = [
                [45, 150, 500, 10],
                [100, 125, 50, 110]
            ];
        }

    }
})();
