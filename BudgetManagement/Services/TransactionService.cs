﻿using BudgetManagement.DAL;
using BudgetManagement.Domain;
using BudgetManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetManagement.Services
{
    public class TransactionService:BaseService
    {
        public void CreateTransation(EntringTransaction model)
        {
            var transaction = new Transaction()
            {
                TransactionTypeID = model.TransactionTypeID,
                TransactionDate = model.TransactionDate,
                Amount = model.Amount,
                Name = model.TransactionName,
                AccountID = model.AccountId ,
                UserID =model.UserId,
                CategoryID =model.CategoryId
            };
            bctx.Transactions.Add(transaction);
            bctx.SaveChanges();

        }

    }
}