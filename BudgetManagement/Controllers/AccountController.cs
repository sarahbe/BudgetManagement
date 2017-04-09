using BudgetManagement.Domain;
using BudgetManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BudgetManagement.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountController:BaseApiController
    {

        [Route("Create")]
        [HttpPost]
        public IHttpActionResult CreateTransaction(AccountModel model)
        {
            Account account = new Account();
            account.AccountTypeID = model.AccountTypeID;

            BudgetContext.Accounts.Add(account);
            BudgetContext.SaveChanges();
           

            return Ok();
        }

    }
}