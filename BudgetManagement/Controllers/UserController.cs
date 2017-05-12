using BudgetManagement.Domain;
using BudgetManagement.Models;
using BudgetManagement.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Http;

namespace BudgetManagement.Controllers
{

    [RoutePrefix("api/users")]
    public class UserController : BaseApiController
    {
        /// <summary>
        ///  Responsible to return all the registered users in our system
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("users")]
        public IHttpActionResult GetUsers()
        {
            return Ok(this.AppUserManager.Users.ToList().Select(u => this.TheModelFactory.Create(u)));
        }

        /// <summary>
        /// Responsible to return single user by providing it is unique identifier 
        /// </summary>
        /// <param name="Id">Id"User Id</param>
        /// <returns></returns>
        [Authorize]
        [Route("user/{id:guid}", Name = "GetUserById")]
        public async Task<IHttpActionResult> GetUser(string Id)
        {
            var user = await this.AppUserManager.FindByIdAsync(Id);
            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }
            return NotFound();

        }

        /// <summary>
        /// Responsible to return single user by providing it is username 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [Authorize]
        [Route("user/{username}")]
        public async Task<IHttpActionResult> GetUserByName(string username)
        {
            var user = await this.AppUserManager.FindByNameAsync(username);
            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }
            return NotFound();

        }

        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="createUserModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("create")]
        public async Task<IHttpActionResult> CreateUser(UserRegistration createUserModel)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    //validate the request model based on the data annotations we introduced in MODELView
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    var user = new User()
                    {
                        UserName = createUserModel.Username,
                        Email = createUserModel.Email,
                        //FullName = createUserModel.Fullname,
                        Birthdate = createUserModel.Birthdate,
                        MaritalStatus = createUserModel.MaritalStatus,
                        Job = createUserModel.Job
                    };


                    //CreateAsync: inside this method it will validate if the username, email is used before, and if the password matches our policy, etc.. 
                    // if the request is valid then it will create new user and add to the “AspNetUsers” table and return success result.

                    IdentityResult addUserResult = await this.AppUserManager.CreateAsync(user, createUserModel.Password);

                    if (!addUserResult.Succeeded)
                    {
                        return GetErrorResult(addUserResult);
                    }

                    //create default cash account on new user
                    AccountService tsrc = new AccountService();
                    tsrc.CreateDefaultAccount(user.Id);

                    string code = await this.AppUserManager.GenerateEmailConfirmationTokenAsync(user.Id);

                    var callbackUrl = new Uri(Url.Link("ConfirmEmailRoute", new { userId = user.Id, code = code }));

                    await this.AppUserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

                    var userModel = TheModelFactory.Create(user);
                    scope.Complete();

                    //From this result we  return the resource created in the location header and return 201 created status.

                    return Created(locationHeader, userModel);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        /// <summary>
        /// Change old password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //ChangePasswordAsyn: take care of validating current password, as well validating new password policy, and then updating old password with new one.
            IdentityResult result = await this.AppUserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        /// <summary>
        /// Confirm Email address
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("ConfirmEmail", Name = "ConfirmEmailRoute")]
        public async Task<IHttpActionResult> ConfirmEmail(string userId = "", string code = "")
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest(ModelState);
            }

            IdentityResult result = await this.AppUserManager.ConfirmEmailAsync(userId, code);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return GetErrorResult(result);
            }
        }
    }
}
