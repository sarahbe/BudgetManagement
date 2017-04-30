using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace BudgetManagement.Domain
{
    public class User :IdentityUser
    {
        public string FullName { get; set; }
        //public string Username { get; set; }
      //  public string Token { get; set; }
        public DateTime Birthdate { get; set; }
        //TODO: For the future job can be done as a seperate table. MArital STatus also.
        public string Job { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime? Timestamp { get; set; }
        /// <summary>
        /// Responsible to fetch the authenticated user identity from the database
        /// </summary>
        /// <param name="manager">The manager will contain the credintials</param>
        /// <param name="authenticationType">Authontication Type</param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}