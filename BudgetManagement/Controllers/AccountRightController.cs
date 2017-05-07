using BudgetManagement.DAL;
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
        private BudgetContext bctx = new BudgetContext();

        [Route("Create")]
        [HttpPost]
        public IHttpActionResult CreateAccountRight(AccountRightModel model)
        {
            AccountRightService tsrc = new AccountRightService();
            tsrc.CreateAccountRight(model);

            return Ok();
        }

        [Route("Update")]
        [HttpPut]
        public IHttpActionResult UpdateAccountRight(AccountRightModel model)
        {
            AccountRightService tsrc = new AccountRightService();
            tsrc.UpdateAccountRight(model);

            return Ok();
        }


        [Route("Delete")]
        [HttpPut]
        public IHttpActionResult DeleteAccountRight(AccountRightModel model)
        {
            AccountRightService tsrc = new AccountRightService();
            model.Valid = false;
            tsrc.UpdateAccountRight(model);

            return Ok();
        }

        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAccountRightByAccountId(string accountId)
        {

            return Ok(bctx.AccountRights.Where(o => o.AccountId.Equals(accountId)));
        }

    }
}