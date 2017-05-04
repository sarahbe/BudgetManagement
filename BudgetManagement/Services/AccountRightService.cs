using BudgetManagement.DAL;
using BudgetManagement.Domain;
using BudgetManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BudgetManagement.Services
{
    public class AccountRightService : BaseService
    {
        public void CreateAccountRight(AccountRightModel model)
        {
            var accountRight = new AccountRight()
            {
                FlAdmin = model.FlAdmin,
                FlWrite = model.FlWrite,
                UserID = model.UserID,
            };

            bctx.AccountRights.Add(accountRight);
            bctx.SaveChanges();

        }
    
        public void UpdateAccountRight(AccountRightModel model)
        {
            var accountRight = new AccountRight();
            accountRight = bctx.AccountRights.First(a => a.ID.Equals(model.ID));

            accountRight.UserID = model.UserID;
            accountRight.FlWrite = model.FlWrite;
            accountRight.FlAdmin = model.FlAdmin;
            accountRight.Valid = model.Valid;

            bctx.SaveChanges();

        }

    }
}