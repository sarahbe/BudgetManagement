using BudgetManagement.DAL;
using BudgetManagement.Domain;
using BudgetManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Transaction transaction = new Transaction();
            transaction = bctx.Transactions.First(o => o.ID == model.ID);
            transaction.Name = model.TransactionName;
            transaction.TransactionTypeID = model.TransactionTypeID;
            transaction.TransactionDate = model.TransactionDate;
            transaction.Amount = model.Amount;
            transaction.Name = model.TransactionName;
            transaction.AccountID = model.AccountId;
            transaction.UserID = model.UserId;
            transaction.CategoryID = model.CategoryId;
            transaction.Valid = model.Valid;
            bctx.SaveChanges();
        }

        public void CreateTransation(EntringTransaction model)
        {

            var transaction = new Transaction()
            {
                TransactionTypeID = model.TransactionTypeID,
                TransactionDate = model.TransactionDate,
                Amount = model.Amount,
                Name = model.TransactionName,
                AccountID = model.AccountId,
                UserID = model.UserId,
                CategoryID = model.CategoryId
            };
            bctx.Transactions.Add(transaction);
            bctx.SaveChanges();

        }

    }
}