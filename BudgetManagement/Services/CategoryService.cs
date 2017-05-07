using BudgetManagement.Domain;
using BudgetManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetManagement.Services
{
    public class CategoryService:BaseService
    {
        public void CreateCategory(CategoryModel model)
        {
            var category = new Category()
            {
                UserId = model.UserId,
                 Description = model.Description,
                 TransactionTypeId = model.TransactionTypeId
            };
            bctx.Categories.Add(category);
            bctx.SaveChanges();

        }

        public void UpdateCategory(CategoryModel model)
        {
            if (!model.ID.HasValue)
            {
                throw new ApplicationException("Category was not found");
            }
            Category category= new Category();
            category = bctx.Categories.First(o => o.ID == model.ID);
            category.Valid = model.Valid;
            category.UserId = model.UserId;
            category.Description = model.Description;
            category.TransactionTypeId = model.TransactionTypeId;
            bctx.SaveChanges();
        }

    }
}