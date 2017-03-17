using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetManagement.Domain
{
    public class Account: BaseEntity
    {
        public int UserID { get; set; }


        public virtual User User { get; set; }
    }
}