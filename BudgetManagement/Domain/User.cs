using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetManagement.Domain
{
    public class User :IdentityUser
    {
        public string FullName { get; set; }
        //public string Username { get; set; }
      //  public string Token { get; set; }
        public DateTime Birthdate { get; set; }
        //TODO: For the future job can be done as a seperate table. MArital STatus also.
        public string Job { get; set; }
        public string MaritalStatus { get; set; }
    }
}