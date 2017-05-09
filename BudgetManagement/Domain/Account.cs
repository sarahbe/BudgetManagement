using System;
using System.Collections.Generic;

namespace BudgetManagement.Domain
{
    public class Account: BaseEntity
    {
        public string UserID { get; set; }
        public int AccountTypeID { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? Limit { get; set; }
        public int CurrencyId { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }

        public virtual User User { get; set; }
        public virtual AccountType AccountType { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual List<AccountRight> AccountRightList { get; set; } 
    }
}