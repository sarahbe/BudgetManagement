﻿using BudgetManagement.DAL;
using BudgetManagement.Domain;
using BudgetManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BudgetManagement.Services
{
    public class AccountRightService : BaseService
    {
        public void CreateAccountRight(AccountRightModel model)
        {


            try
            {
                var accountRight = new AccountRight()
                {
                    FlAdmin = model.FlAdmin,
                    FlWrite = model.FlWrite,
                    UserID = model.UserID,
                    AccountId = model.AccountId,
                    Valid = true
                };

                bctx.AccountRights.Add(accountRight);
                bctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void CreateDefaultAccountRight(string userID , int accountId)
        {
            var accountRight = new AccountRight()
            {
                FlAdmin = true,
                FlWrite = true,
                UserID = userID,
                AccountId = accountId,
                Valid = true
            };

            bctx.AccountRights.Add(accountRight);
            bctx.SaveChanges();
        }
        public void UpdateAccountRight(AccountRightModel model)
        {
            if (!model.ID.HasValue)
            {
                throw new ApplicationException("right was not found");
            }

            var accountRight = bctx.AccountRights.First(a => a.ID == model.ID);
                        
            accountRight.FlWrite = model.FlWrite;
            accountRight.FlAdmin = model.FlAdmin;
            accountRight.Valid = model.Valid;

            bctx.SaveChanges();

        }

    }
}