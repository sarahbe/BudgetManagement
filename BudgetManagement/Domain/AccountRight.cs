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
    }
}