(function () {
    'use strict';

    angular
        .module('app.budget.pages')
        .controller('DashboardGeneralController', DashboardGeneralController);

    /* @ngInject */
    function DashboardGeneralController($state, triAuthorization, dashboardService, accountService, $filter) {
        var vm = this;
        vm.init = init;
        vm.accountClicked = accountClicked;
        init();
    
   function updateDashboard(accountId)
   {
 vm.cardStats = {};
            vm.data = [];

            dashboardService.getCardStats(accountId).then(function (res) {
                vm.cardStats.expenseToday = res.expenseToday;
                vm.cardStats.incomeToday = res.incomeToday;
                vm.cardStats.balance = res.balance;
            });

            dashboardService.transactionsThisMonth(accountId).then(function (res) {
                vm.labels = res.days;
                vm.data.push(res.incomeStats);
                vm.data.push(res.expenseStats);
                vm.series = ['Income', 'Expense'];
                vm.options = {
                    datasetFill: false
                };
            });


            dashboardService.transactionsByCategory(accountId).then(function (res) {
                vm.pieOptions = {
                    datasetFill: false
                };

                vm.pieIncomeLabels = res.incomeCategories;
                vm.pieIncomeData = res.incomeValues;

                vm.pieExpenseLabels = res.expenseCategories;
                vm.pieExpenseData = res.expenseValues;
            });


          


            vm.barSeries = ['Income', 'Expense'];
            vm.barLabels = ['15-25', '25-35', '35-50', '50-70'];
            vm.barData = [
                [45, 150, 500, 10],
                [100, 125, 50, 110]
            ];
   }     

   function accountClicked($event, account){
           updateDashboard(account.id);
        }
        function init() {
               accountService.getAccounts(triAuthorization.getUserId()).then(function (res) {
                vm.accounts = res;
               updateDashboard(res[0].id);
            });
        }

    }
})();
