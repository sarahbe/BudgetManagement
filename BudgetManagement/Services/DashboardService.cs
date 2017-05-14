using BudgetManagement.DAL;
using BudgetManagement.Domain;
using BudgetManagement.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace BudgetManagement.Services
{
    public class DashboardService : BaseService
    {
        private BudgetContext _ctx;

        public DashboardService()
        {
            _ctx = new BudgetContext();
        }

        public dynamic GetTransactionsThisMonth(string userId)
        {
            var today = DateTime.Now;
            var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);

            var transactions = GetTransactionsByDate(userId, firstDayOfMonth, today);

            var days = getNumbersFromRange(firstDayOfMonth.Day, today.Day);

            var incomeStats = transactions.Where(o => o.TransactionTypeID == (int)Domain.TransactionType.Income)
                   .GroupBy(x => x.TransactionDate.Value.Day)
                  .Select(x =>
                  new
                  {
                      Value = x.Sum(o => o.Amount),
                      Day = x.Key
                  }).ToDictionary(p => p.Day, p => p.Value);

            var expenseStats = transactions.Where(o => o.TransactionTypeID == (int)Domain.TransactionType.Expense)
                .GroupBy(x => x.TransactionDate.Value.Day)
                .Select(x =>
                  new
                  {
                      Value = x.Sum(o => o.Amount),
                      Day = x.Key
                  }).ToDictionary(p => p.Day, p => p.Value);

            var incomeStatsByDays = appendValuesToDays(incomeStats, days);
            var expenseStatsByDays = appendValuesToDays(expenseStats, days);


            dynamic model = new ExpandoObject();
            model.Days = days;
            model.IncomeStats = incomeStatsByDays;
            model.ExpenseStats = expenseStatsByDays;
            return model;
        }


        public dynamic GetTransactionsByCategory(string userId)
        {
            var today = DateTime.Now;
            var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);

            var transactions = GetTransactionsByDate(userId, firstDayOfMonth, today);

            var incomeTransactions = transactions.Where(o => o.TransactionTypeID == (int)Domain.TransactionType.Income);
            var incomeSum = incomeTransactions.Sum(o => (decimal?)o.Amount);

            var incomeStats = incomeTransactions.GroupBy(x => x.Category.Description)
                .Select(x =>
                  new
                  {
                      Value = x.Sum(o => o.Amount) * 100 / incomeSum,
                      Category = x.Key
                  }).ToDictionary(p => p.Category, p => p.Value);

            var expenseTransactions = transactions.Where(o => o.TransactionTypeID == (int)Domain.TransactionType.Expense);
            var expenseSum = expenseTransactions.Sum(o => (decimal?)o.Amount);

            var expenseStats = expenseTransactions.GroupBy(x => x.Category.Description)
                .Select(x =>
                  new
                  {
                      Value = x.Sum(o => o.Amount) * 100 / expenseSum,
                      Category = x.Key
                  }).ToDictionary(p => p.Category, p => p.Value);

            dynamic model = new ExpandoObject();
            model.IncomeCategories = incomeStats.Keys.ToList();
            model.IncomeValues = incomeStats.Values.ToList();

            model.ExpenseCategories = expenseStats.Keys.ToList();
            model.ExpenseValues = expenseStats.Values.ToList();
            return model;
        }



        private IQueryable<Transaction> GetTransactionsByDate(string userId, DateTime from, DateTime to)
        {
            var transactions = _ctx.Transactions;
            //.Where(o => o.UserID == userId && o.TransactionDate > to && o.TransactionDate < from);
            var zz = transactions.Where(o => o.UserID == userId && o.TransactionDate > to && o.TransactionDate < from);
            return transactions;
        }

        private List<decimal> appendValuesToDays(Dictionary<int, decimal> incomeStats, List<int> days)
        {
            var result = new List<decimal>();
            foreach (var day in days)
            {
                if (incomeStats.ContainsKey(day))
                    result.Add(incomeStats[day]);
                else
                    result.Add(0);
            }
            return result;
        }

        private List<int> getNumbersFromRange(int firstNumber, int lastNumber)
        {
            var result = new List<int>();
            for (int i = firstNumber; i <= lastNumber; i++)
            {
                result.Add(i);
            }
            return result;
        }
    }
}