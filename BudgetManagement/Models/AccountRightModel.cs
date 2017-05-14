using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetManagement.Models
{
    public class AccountRightModel
    {
        public int? ID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public bool FlWrite { get; set; }
        public bool Valid { get; set; }
        public bool FlAdmin { get; set; }
        public int AccountId { get; set; }
    }
}