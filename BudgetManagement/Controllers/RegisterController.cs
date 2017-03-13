using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetManagement.DAL;
using BudgetManagement.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace BudgetManagement.Controllers
{
    public class RegisterController : System.Web.Http.ApiController
    {
        private BudgetContext _ctx;

        private UserManager<IdentityUser> _userManager;
        //Our constructor. Initalizing context and userManager
        public RegisterController()
        {
            _ctx = new BudgetContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserRegistration userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.Username
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

    }
}