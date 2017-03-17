using BudgetManagement.Domain;
using BudgetManagement.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BudgetManagement.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountsController : BaseApiController
    {
        /// <summary>
        ///  Responsible to return all the registered users in our system
        /// </summary>
        /// <returns></returns>
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
        [Route("create")]
        public async Task<IHttpActionResult> CreateUser(UserRegistration createUserModel)
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
                FullName = createUserModel.Fullname,
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

            Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));
            //From this result we  return the resource created in the location header and return 201 created status.
            return Created(locationHeader, TheModelFactory.Create(user));
        }
    }
}
