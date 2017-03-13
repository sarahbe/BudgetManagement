using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetManagement.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public DateTime Birthdate { get; set; }
        //TODO: For the future job can be done as a seperate table. MArital STatus also.
        public string Job { get; set; }
        public string MaritalStatus { get; set; }
    }
}