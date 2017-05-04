using BudgetManagement.Models;
using BudgetManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BudgetManagement.Controllers
{
    [RoutePrefix("api/accountRights")]
    public class AccountRightController:BaseApiController
    {
        [Route("Create")]
        [HttpPost]
        public IHttpActionResult CreateAccountRight(AccountRightModel model)
        {
            AccountRightService tsrc = new AccountRightService();
            tsrc.CreateAccountRight(model);

            return Ok();
        }
    }
}