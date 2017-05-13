using BudgetManagement.DAL;
using BudgetManagement.Domain;
using BudgetManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace BudgetManagement.Services
{
    public class TransactionService : BaseService
    {
        public void UpdateTransaction(EntringTransaction model)
        {
            if (!model.ID.HasValue)
            {
                throw new ApplicationException("transaction was not found");
            }
            Domain.Transaction transaction = new Domain.Transaction();
            transaction = bctx.Transactions.First(o => o.ID == model.ID);
            var oldAmount = transaction.Amount;
            transaction.Name = model.Name;
            transaction.TransactionTypeID = model.TransactionTypeID;
            transaction.TransactionDate = model.TransactionDate;
            transaction.Amount = model.Amount;
            transaction.Name = model.Name;
            transaction.AccountID = model.AccountId;
            transaction.UserID = model.UserId;
            transaction.CategoryID = model.CategoryId;
            transaction.Valid = model.Valid;

            if (oldAmount != model.Amount)
            {
                AccountService accsrv = new AccountService();
                accsrv.RollbackOldAmount(transaction, oldAmount);
                accsrv.UpdateBalance(transaction);
            }
            bctx.SaveChanges();
        }

        public void CreateTransation(EntringTransaction model)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var transaction = new Domain.Transaction()
                {
                    TransactionTypeID = model.TransactionTypeID,
                    TransactionDate = model.TransactionDate,
                    Amount = model.Amount,
                    Name = model.Name,
                    AccountID = model.AccountId,
                    UserID = model.UserId,
                    CategoryID = model.CategoryId
                };
                bctx.Transactions.Add(transaction);
                bctx.SaveChanges();
                AccountService accsrv = new AccountService();
                accsrv.UpdateBalance(transaction);
                scope.Complete();


            }
        }

    }
}