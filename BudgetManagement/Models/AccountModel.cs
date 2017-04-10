﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetManagement.Models
{
    public class AccountModel
    {

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Account Type ID")]
        public int AccountTypeID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string UserId { get; set; }

        public int CurrencyId { get; set; }


    }
}