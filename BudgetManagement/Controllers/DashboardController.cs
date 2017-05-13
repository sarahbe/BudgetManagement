using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetManagement.DAL;
using BudgetManagement.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity.Core.Objects;
using System.Dynamic;

namespace BudgetManagement.Controllers
{
    [RoutePrefix("api/dashboards")]
    public class DashboardController : BaseApiController
    {
        private BudgetContext _ctx;

        //Our constructor. Initalizing context and userManager
        public DashboardController()
        {
            _ctx = new BudgetContext();
        }

        [Route("CardStats")]
        [HttpGet]
        public IHttpActionResult CardStats(string userId)
        {
            var transactions = _ctx.Transactions.
                  Where(o => o.UserID == userId 
                  && EntityFunctions.TruncateTime(o.TransactionDate) == EntityFunctions.TruncateTime(DateTime.Now))
                  .ToList();

            var model = new DashcardModel();

            model.IncomeToday = transactions.Where(o => o.TransactionType == Domain.TransactionType.Income).Sum(o => o.Amount);
            model.ExpenseToday = transactions.Where(o => o.TransactionType == Domain.TransactionType.Expense).Sum(o => o.Amount);
            model.Balance = _ctx.Accounts.First().Balance;

            return Ok(model);
        }

        [Route("TransactionsThisMonth")]
        [HttpGet]
        public IHttpActionResult TransactionsThisMonth(string userId)
        {
            var today = DateTime.Now;
            var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);

            var transactions = _ctx.Transactions.
                  Where(o => o.UserID == userId && o.TransactionDate > firstDayOfMonth && o.TransactionDate < today);

            var days = getNumbersFromRange(firstDayOfMonth.Day, today.Day);

            var incomeStats = transactions.Where(o => o.TransactionType == Domain.TransactionType.Income)
                   .GroupBy(x => x.TransactionDate.Value.Day)
                  .Select(x => 
                  new {
                        Value = x.Sum(o => o.Amount),
                        Day = x.Key
                      }
                      ).ToDictionary(p => p.Day, p => p.Value);

            var expenseStats = transactions.Where(o => o.TransactionType == Domain.TransactionType.Expense)
                .GroupBy(x => x.TransactionDate.Value.Day)
                .Select(x =>
                  new {
                      Value = x.Sum(o => o.Amount),
                      Day = x.Key
                  }
                      ).ToDictionary(p => p.Day, p => p.Value);

            var incomeStatsByDays = appendValuesToDays(incomeStats, days);
            var expenseStatsByDays = appendValuesToDays(expenseStats, days);
          

            dynamic model = new ExpandoObject();
            model.Days = days;
            model.IncomeStats = incomeStatsByDays;
            model.ExpenseStats = expenseStatsByDays;

            return Ok(model);
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
            for (int i = firstNumber; i < lastNumber; i++)
            {
                result.Add(i);
            }
            return result;
        }
    }
}