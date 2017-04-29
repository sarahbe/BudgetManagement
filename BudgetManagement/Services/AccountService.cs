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
    public class AccountService : BaseService
    {
        public void CreateAccount(AccountModel model)
        {
            var account = new Account()
            {
                AccountTypeID = model.AccountTypeID,
                CurrencyId = model.CurrencyId,
                Description = model.Description,
                Limit = model.Limit,
                DueDate = model.DueDate,
                UserID = model.UserId,
                Balance = model.Balance
            };

            bctx.Accounts.Add(account);
            bctx.SaveChanges();

        }
        public void CreateDefaultAccount(string userID)
        {
            var account = new Account()
            {
                AccountTypeID = 1,
                CurrencyId = 2,
                Description = "Cash",
                UserID = userID
            };

            bctx.Accounts.Add(account);
          bctx.SaveChanges();
            
        }

    }
}