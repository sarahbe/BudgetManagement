using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetManagement.Models
{
    public class Account
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        //Virtaul Properties    
        public virtual User User { get; set; }
    }
}