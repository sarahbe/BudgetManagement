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
    [RoutePrefix("api/accounts")]
    public class AccountController:BaseApiController
    {
       
        [Route("Create")]
        [HttpPost]
        public IHttpActionResult CreateAccount(AccountModel model)
        {
            AccountService tsrc = new AccountService();
            tsrc.CreateAccount(model);

            return Ok();
        }

        [Route("Update")]
        [HttpPost]
        public IHttpActionResult UpdateAccount(AccountModel model)
        {
            AccountService tsrc = new AccountService();
            tsrc.UpdateAccount(model);

            return Ok();
        }


        [Route("Delete")]
        [HttpPost]
        public IHttpActionResult DeleteAccount(AccountModel model)
        {
            AccountService tsrc = new AccountService();
            model.Valid = false;
            tsrc.UpdateAccount(model);

            return Ok();
        }
    }
}