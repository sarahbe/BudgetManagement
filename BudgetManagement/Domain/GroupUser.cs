using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetManagement.Domain
{
    public class GroupUser:BaseEntity
    {
        public int GroupId { get; set; }
        public string UserID { get; set; }
        public bool FlRead { get; set; }
        public bool FlWrite { get; set; }
        public bool FlAdmin { get; set; }
        //Virtual properties
        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
    }
}