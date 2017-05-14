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
using BudgetManagement.Services;

namespace BudgetManagement.Controllers
{
    [RoutePrefix("api/dashboards")]
    public class DashboardController : BaseApiController
    {
        private BudgetContext _ctx;
        private DashboardService _dashboardService;
        //Our constructor. Initalizing context and userManager
        public DashboardController()
        {
            _ctx = new BudgetContext();
            _dashboardService = new DashboardService();
        }

        [Authorize]
        [Route("CardStats")]
        [HttpGet]
        public IHttpActionResult CardStats(string userId)
        {
            var transactions = _ctx.Transactions.
                  Where(o => o.UserID == userId 
                  && EntityFunctions.TruncateTime(o.TransactionDate) == EntityFunctions.TruncateTime(DateTime.Now))
                  .ToList();

            var model = new DashcardModel();

            model.IncomeToday = transactions.Where(o => o.TransactionTypeID == (int)Domain.TransactionType.Income).Sum(o => o.Amount);
            model.ExpenseToday = transactions.Where(o => o.TransactionTypeID == (int)Domain.TransactionType.Expense).Sum(o => o.Amount);
            model.Balance = _ctx.Accounts.First().Balance;

            return Ok(model);
        }

        [Authorize]
        [Route("TransactionsThisMonth")]
        [HttpGet]
        public IHttpActionResult TransactionsThisMonth(string userId)
        {
            dynamic model = _dashboardService.GetTransactionsThisMonth(userId);

            return Ok(model);
        }


        [Authorize]
        [Route("TransactionsByCategory")]
        [HttpGet]
        public IHttpActionResult TransactionsByCategory(string userId)
        {

            dynamic model = _dashboardService.GetTransactionsByCategory(userId);

            return Ok(model);

        }

        
    }
}