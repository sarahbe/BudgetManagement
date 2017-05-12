﻿using BudgetManagement.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace BudgetManagement.Models
{
    /// <summary>
    /// Contain all the functions needed to shape the response object and control the object graph returned to the client.
    /// </summary>
    public class ModelFactory
    {
        private UrlHelper _UrlHelper;
        private ApplicationUserManager _AppUserManager;

        public ModelFactory(HttpRequestMessage request, ApplicationUserManager appUserManager)
        {
            _UrlHelper = new UrlHelper(request);
            _AppUserManager = appUserManager;
        }

        public UserReturnModel Create(User appUser)
        {
            return new UserReturnModel
            {
                Url = _UrlHelper.Link("GetUserById", new { id = appUser.Id }),
                Id = appUser.Id,
                UserName = appUser.UserName,
                FullName = appUser.FullName,
                Email = appUser.Email,
                EmailConfirmed = appUser.EmailConfirmed,
                Job = appUser.Job,
                MaritalStatus= appUser.MaritalStatus,
                Birthdate = appUser.Birthdate,
                Roles = _AppUserManager.GetRolesAsync(appUser.Id).Result,
                Claims = _AppUserManager.GetClaimsAsync(appUser.Id).Result
            };
        }

        public List<AccountReturnModel> GetAccounts(List<Account> accounts)
        {
            List<AccountReturnModel> acct = new List<AccountReturnModel>();
            foreach (Account a in accounts)
            {
                acct.Add(new AccountReturnModel
                {
                    Id = a.ID,
                    Description = a.Description,
                    Limit = a.Limit
                });
            }
            return acct;
        }
    }

    public class UserReturnModel
    {
        public string Url { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public int Level { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime Birthdate { get; set; }
        public string MaritalStatus { get; set; }
        public string Job { get; set; }
        public IList<string> Roles { get; set; }
        public IList<System.Security.Claims.Claim> Claims { get; set; }
    }

    public class AccountReturnModel
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public decimal? Limit { get; set; }
    }
}