using BudgetManagement.DAL;
using BudgetManagement.Domain;
using BudgetManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetManagement.Services
{
    public class AccountService:BaseService
    {
        public void CreateAccount(AccountModel model)
        { 
            var account = new Account()
        {
            AccountTypeID = model.AccountTypeID,
            CurrencyId = model.CurrencyId
        };
        
            bctx.Accounts.Add(account);
            bctx.SaveChanges();

        }

    }
}