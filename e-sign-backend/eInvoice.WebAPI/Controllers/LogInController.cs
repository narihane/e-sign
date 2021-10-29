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

        [HttpPost("login")]
        public async Task<IActionResult> LogIn(AuthRequestModel model)
        {
            try
            {
                var response = await userService.LogIn(model);

                if (string.IsNullOrWhiteSpace(response))
                    return BadRequest(new { message = "Username or password is incorrect" });

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                return Unauthorized();
            }

        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserRegisterationModel model)
        {
            try
            {
                userService.Register(model);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet("Users")]
        public IActionResult GetAll()
        {
            try
            {
                var users = userService.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                if (ex.GetType().Name == "UnauthorizedAccessException")
                {
                    return Unauthorized();
                }
                return BadRequest(ex.Message);
            }

        }
    }
}
