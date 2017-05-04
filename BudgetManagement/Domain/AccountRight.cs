using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetManagement.Domain
{
    public class AccountRight:BaseEntity
    {
        public string UserID { get; set; }
        public bool FlWrite { get; set; }
        public bool FlAdmin { get; set; }
        public int AccountId { get; set; }
        //Virtual property 
        public User User { get; set; }
        public Account Account { get; set; }
    }
}