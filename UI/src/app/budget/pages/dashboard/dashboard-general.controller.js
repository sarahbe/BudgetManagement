(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .controller('DashboardGeneralController', DashboardGeneralController);

    /* @ngInject */
    function DashboardGeneralController($state, $filter) {
        var vm = this;
        vm.init = init;

        init();

        function init() {
            vm.cardStats = {};
            vm.cardStats.expenseToday = 150;
            vm.cardStats.incomeToday = 450;
            vm.cardStats.balance = 3200;

            vm.series = ['Income', 'Expense'];
            vm.labels = ['1', '2', '3', '4'];
            vm.options = {
                datasetFill: false
            };
            vm.data = [
                [45, 150, 500, 10],
                [100, 125, 50, 110]
            ];


            vm.pieLabels = ['Shopping', 'Oil', 'Bills', 'Education'];
            vm.pieOptions = {
                datasetFill: false
            };
            vm.pieData = [25,15,35,25];


            vm.barSeries = ['Income', 'Expense'];
            vm.barLabels = ['15-25', '25-35', '35-50', '50-70'];
            vm.barData = [
                [45, 150, 500, 10],
                [100, 125, 50, 110]
            ];
        }

    }
})();
