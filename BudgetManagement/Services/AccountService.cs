using BudgetManagement.DAL;
using BudgetManagement.Domain;
using BudgetManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Http;

namespace BudgetManagement.Services
{
    public class AccountService : BaseService
    {
        public void CreateAccount(AccountModel model)
        {
            using (TransactionScope scope = new TransactionScope())
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
                AccountRightService rightsrv = new AccountRightService();
                rightsrv.CreateDefaultAccountRight(account.UserID, account.ID);

                scope.Complete();


            }
        }
        public void CreateDefaultAccount(string userID)
        {
     
                var account = new Account()
                {
                    AccountTypeID = 1,
                    CurrencyId = 1,
                    Description = "Cash",
                    UserID = userID
                };

                bctx.Accounts.Add(account);
                bctx.SaveChanges();

                AccountRightService rightsrv = new AccountRightService();
                rightsrv.CreateDefaultAccountRight(account.UserID, account.ID);
            
        }
        public void UpdateAccount(AccountModel model)
        {
            if (!model.ID.HasValue)
            {
                throw new ApplicationException("account was not found");
            }
            var account = new Account();
            account = bctx.Accounts.First(a => a.ID == model.ID);

            account.AccountTypeID = model.AccountTypeID;
            account.CurrencyId = model.CurrencyId;
            account.Description = model.Description;
            account.Limit = model.Limit;
            account.DueDate = model.DueDate;
            account.UserID = model.UserId;
            account.Balance = model.Balance;
            account.Valid = model.Valid;

            bctx.SaveChanges();

        }

        public void UpdateBalance(Domain.Transaction transaction)
        {
            var account = bctx.Accounts.First(a => a.ID == transaction.AccountID);
            if (transaction.TransactionTypeID == (int)TransactionType.Expense)
            {
                account.Balance -= transaction.Amount;
            }
            else {
                account.Balance += transaction.Amount;
            }
            bctx.SaveChanges();
        }


        public void RollbackOldAmount(Domain.Transaction transaction, decimal oldAmount)
        {
            var account = bctx.Accounts.First(a => a.ID == transaction.AccountID);
            //Operations are done oppositely
            if (transaction.TransactionTypeID == (int)TransactionType.Expense)
            {
                account.Balance += oldAmount;
            }
            else
            {
                account.Balance -= oldAmount;
            }
            bctx.SaveChanges();
        }

    }
}