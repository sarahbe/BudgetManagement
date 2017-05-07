using BudgetManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetManagement.Models
{
    public class CategoryModel
    {
        public int? ID { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public TransactionType TransactionTypeId { get; set; }
        public bool Valid { get; set; }

    }
}