using BudgetManagement.DAL;
using BudgetManagement.Domain;
using BudgetManagement.Models;
using BudgetManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BudgetManagement.Controllers
{

    [RoutePrefix("api/transactions")]
    public class TransactionController:ApiController
    {
        private BudgetContext bctx = new BudgetContext();


        [Authorize]
        [Route("Add")]
        [HttpGet]
        public IHttpActionResult GetTransactionsByUserId(string UserId)
        {
            return Ok(bctx.Transactions.Where(o => o.UserID.Equals(UserId)));
        }

       // [Authorize]
        [Route("Create")]
        [HttpPost]
        public IHttpActionResult CreateTransaction(EntringTransaction model)
        {

            TransactionService tsrc = new TransactionService();
            tsrc.CreateTransation(model);
           
            return Ok();
        }

    }
}