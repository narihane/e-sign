using eInvoice.Models.DTOModel;
using eInvoice.Services.Services;
using eInvoice.WebAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eInvoice.WebAPI.Controllers
{
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IUserService userService;
        private readonly ITaxAuthorityService taxAuthorityService;

        public LogInController(IUserService userService, ILogger logger, ITaxAuthorityService taxAuthorityService)
        {
            this.userService = userService;
            this.logger = logger;
            this.taxAuthorityService = taxAuthorityService;
        }

        //[HttpPost("login")]
        //public IActionResult LogIn(AuthRequestModel model)
        //{
        //    try
        //    {
        //        var response = userService.LogIn(model);

        //        if (response == null)
        //            return BadRequest(new { message = "Username or password is incorrect" });

        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex, ex.Message);
        //        return Unauthorized();
        //    }

        //}

        //[HttpPost]
        //[Route("register")]
        //public IActionResult Register(UserRegisterationModel model)
        //{
        //    try
        //    {
        //        userService.Register(model);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex, ex.Message);
        //        return Unauthorized();
        //    }
        //}

        //[Authorize]
        //[HttpGet("Users")]
        //public IActionResult GetAll()
        //{
        //    try
        //    {
        //        var users = userService.GetAll();
        //        return Ok(users);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex, ex.Message);
        //        return BadRequest();
        //    }

        //}


        [HttpGet("TaxPayer/Login")]
        public async Task<IActionResult> GetToken()
        {
            try
            {
                var response = await taxAuthorityService.GetToken();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
