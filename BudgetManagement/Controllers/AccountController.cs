using BudgetManagement.Models;
using BudgetManagement.Services;
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