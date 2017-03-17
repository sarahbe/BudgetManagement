using BudgetManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetManagement.Domain
{
    public class Category: BaseEntity
    {
        public string Description { get; set; }
    }
}