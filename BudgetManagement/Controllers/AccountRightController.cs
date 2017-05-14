using BudgetManagement.DAL;
using BudgetManagement.Domain;
using BudgetManagement.Models;
using BudgetManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BudgetManagement.Controllers
{
    [RoutePrefix("api/accountRights")]
    public class AccountRightController : BaseApiController
    {
        private BudgetContext bctx = new BudgetContext();

        [Authorize]
        [Route("Create")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateAccountRight(AccountRightModel model)
        {
            var user = await this.AppUserManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                throw new ApplicationException("User is not found");
            }
            model.UserID = user.Id;
            AccountRightService tsrc = new AccountRightService();
            if (!model.ID.HasValue)
                tsrc.CreateAccountRight(model);
            else
                tsrc.UpdateAccountRight(model);

            return Ok();
        }
        [Authorize]
        [Route("Update")]
        [HttpPut]
        public IHttpActionResult UpdateAccountRight(AccountRightModel model)
        {
            AccountRightService tsrc = new AccountRightService();
            tsrc.UpdateAccountRight(model);

            return Ok();
        }

        [Authorize]
        [Route("Delete")]
        [HttpPut]
        public IHttpActionResult DeleteAccountRight(AccountRightModel model)
        {
            AccountRightService tsrc = new AccountRightService();
            model.Valid = false;
            tsrc.UpdateAccountRight(model);

            return Ok();
        }

        [Authorize]
        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAccountRightByAccountId(int accountId)
        {
            var accountRights = bctx.AccountRights.Where(o => o.AccountId == accountId).ToList();
            return Ok(this.TheModelFactory.GetAccountRights(accountRights));
        }

    }
}