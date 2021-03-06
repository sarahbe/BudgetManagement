﻿using BudgetManagement.DAL;
using BudgetManagement.Domain;
using BudgetManagement.Models;
using BudgetManagement.Services;
using System.Linq;
using System.Web.Http;

namespace BudgetManagement.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoryController : BaseApiController
    {
        private BudgetContext bctx = new BudgetContext();

        [Authorize]
        [Route("GetAllByType")]
        public IHttpActionResult GetAllByType(TransactionType transactionTypeId, string userId)
        {
            var categoris = bctx.Categories.Where(c => c.TransactionTypeId == transactionTypeId && (string.IsNullOrEmpty(c.UserId) || c.UserId == userId)).ToList();
            return Ok(this.TheModelFactory.GetCategories(categoris));
        }

        [Authorize]
        [Route("GetAll")]
        public IHttpActionResult GetAll(string userId)
        {
            var categoris = bctx.Categories.Where(c => (string.IsNullOrEmpty(c.UserId) || c.UserId == userId) && c.Valid).ToList();
            return Ok(this.TheModelFactory.GetCategories(categoris));
        }

        [Authorize]
        [Route("Create")]
        [HttpPost]
        public IHttpActionResult SaveCategory(CategoryModel model)
        {
            CategoryService csrc = new CategoryService();
            if (!model.ID.HasValue)
            {
                csrc.CreateCategory(model);
            }
            else {
                csrc.UpdateCategory(model);
            }



            return Ok();
        }

        [Authorize]
        [Route("Update")]
        [HttpPut]
        public IHttpActionResult UpdateCategory(CategoryModel model)
        {
            CategoryService csrc = new CategoryService();
            csrc.UpdateCategory(model);

            return Ok();
        }


        [Authorize]
        [Route("Delete")]
        [HttpPut]
        public IHttpActionResult Delete(CategoryModel model)
        {
            CategoryService tsrc = new CategoryService();
            model.Valid = false;
            tsrc.UpdateCategory(model);
            return Ok();
        }
    }
}