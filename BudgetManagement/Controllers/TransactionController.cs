using BudgetManagement.DAL;
using BudgetManagement.Domain;
using BudgetManagement.Models;
using BudgetManagement.Services;
using System.Linq;
using System.Web.Http;

namespace BudgetManagement.Controllers
{

    [RoutePrefix("api/transactions")]
    public class TransactionController:BaseApiController
    {
        private BudgetContext bctx = new BudgetContext();


        //[Authorize]
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetTransactionsByUserId(string UserId)
        {
            var transactions = bctx.Transactions.Where(o => o.UserID.Equals(UserId) && o.Valid).ToList();
            return Ok(this.TheModelFactory.GetTransactions(transactions));
        }

       // [Authorize]
        [Route("Create")]
        [HttpPost]
        public IHttpActionResult CreateTransaction(EntringTransaction model)
        {

            TransactionService tsrc = new TransactionService();
            if (!model.ID.HasValue) 
                tsrc.CreateTransation(model);
            else
                tsrc.UpdateTransaction(model);
            return Ok();
        }

        // [Authorize]
        [Route("Update")]
        [HttpPut]
        public IHttpActionResult Update(EntringTransaction model)
        {
            TransactionService tsrc = new TransactionService();   
            tsrc.UpdateTransaction(model);
            return Ok();
        }

        // [Authorize]
        [Route("Delete")]
        [HttpPut]
        public IHttpActionResult Delete(EntringTransaction model)
        {
            TransactionService tsrc = new TransactionService();
            model.Valid = false;
            tsrc.UpdateTransaction(model);
            return Ok();
        }
    }
}