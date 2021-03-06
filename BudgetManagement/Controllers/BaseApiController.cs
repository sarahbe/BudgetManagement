﻿using BudgetManagement.DAL;
using BudgetManagement.Domain;
using BudgetManagement.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BudgetManagement.Controllers
{
    public class BaseApiController : ApiController
    {

        private ModelFactory _modelFactory;
        private ApplicationUserManager _AppUserManager = null;
        private BudgetContext bctx = null;


        /// <summary>
        /// Read-only property
        /// Gets the instance of the “ApplicationUserManager” we already set in the “Startup” class, this instance will be initialized and ready to invoke.
        /// </summary>
        protected ApplicationUserManager AppUserManager
        {
            get
            {
                return _AppUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        /// <summary>
        /// Read-only property
        /// Gets the instance of the “ApplicationUserManager” we already set in the “Startup” class, this instance will be initialized and ready to invoke.
        /// </summary>
        protected BudgetContext BudgetContext
        {
            get
            {
                if (bctx == null)
                    bctx = new BudgetContext();
                return bctx;
            }
        }

        /// <summary>
        /// Our Constructor 
        /// </summary>
        public BaseApiController()
        {
        }

        /// <summary>
        /// Read-only property
        /// This factory pattern will help us in shaping and controlling the response returned to the client
        /// </summary>
        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(this.Request, this.AppUserManager);
                }
                return _modelFactory;
            }
        }

        /// <summary>
        /// Takes “IdentityResult” as a constructor and formats the error messages returned to the client.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            // 500: This is a 'catch-all' error generated by the Web server.
            // Basically something has gone wrong, but the server can not be more specific about the error condition in its response to the client.
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                //Show error messages from module
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
