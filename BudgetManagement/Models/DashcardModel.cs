using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetManagement.Models
{
    public class DashcardModel
    {
        public decimal IncomeToday { get; set; }

        public decimal ExpenseToday { get; set; }

        public decimal Balance { get; set; }
    }
}