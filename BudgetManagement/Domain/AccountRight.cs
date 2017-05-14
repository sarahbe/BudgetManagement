using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BudgetManagement.Domain
{
    public class AccountRight:BaseEntity
    {
        public bool FlWrite { get; set; }
        public bool FlAdmin { get; set; }
        [Index("IX_UserAndAccount", 1, IsUnique = true)]
        public int AccountId { get; set; }
        [Index("IX_UserAndAccount", 2, IsUnique = true)]
        public string UserID { get; set; }
        //Virtual property 
        public virtual User User { get; set; }
        public virtual Account Account { get; set; }
    }
}