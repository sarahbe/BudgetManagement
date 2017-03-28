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
        [Authorize]
        [Route("transactions")]
        public IHttpActionResult GetTransactionsByUserId(string UserId)
        {
    
            return Ok(this.AppUserManager.Users.ToList().Select(u => this.TheModelFactory.Create(u)));
        }
    }
}