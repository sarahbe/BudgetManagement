using BudgetManagement.DAL;
using BudgetManagement.Models;
using BudgetManagement.Services;
using System.Linq;
using System.Web.Http;

namespace BudgetManagement.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountController:BaseApiController
    {
        private BudgetContext bctx = new BudgetContext();

        [Route("Create")]
        [HttpPost]
        public IHttpActionResult CreateAccount(AccountModel model)
        {
            AccountService tsrc = new AccountService();
            tsrc.CreateAccount(model);

            return Ok();
        }

        [Route("Update")]
        [HttpPut]
        public IHttpActionResult UpdateAccount(AccountModel model)
        {
            AccountService tsrc = new AccountService();
            tsrc.UpdateAccount(model);

            return Ok();
        }


        [Route("Delete")]
        [HttpPut]
        public IHttpActionResult DeleteAccount(AccountModel model)
        {
            AccountService tsrc = new AccountService();
            model.Valid = false;
            tsrc.UpdateAccount(model);

            return Ok();
        }

        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAccountByUserId(string userId)
        {
            var accounts = bctx.Accounts.Where(o => o.UserID.Equals(userId) && o.AccountRightList.Any(r=>r.FlWrite));
           
            return Ok(accounts);
        }

        [Route("GetAccountTypes")]
        [HttpGet]
        public IHttpActionResult GetAccountTypes()
        {
            return Ok(bctx.AccountTypes);
        }

        [Route("GetCurrencies")]
        [HttpGet]
        public IHttpActionResult GetCurrencies()
        {
            return Ok(bctx.Currencies);
        }
    }
}