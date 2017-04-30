using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BudgetManagement.Domain
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public bool Valid { get; set; }
    }
}