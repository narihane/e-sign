using eInvoice.Models.DTOModel;
using eInvoice.Services.Services;
using eInvoice.WebAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eInvoice.WebAPI.Controllers
{
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly ILogger<LogInController> logger;
        private readonly IUserService userService;

        public LogInController(IUserService userService, ILogger<LogInController> logger)
        {
            this.userService = userService;
            this.logger = logger;
        }

        [HttpPost("login")]
        public IActionResult LogIn(AuthRequestModel model)
        {
            try
            {
                var response = userService.LogIn(model);

                if (response == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
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
                logger.LogInformation(ex.Message);
                return Unauthorized();
            }
        }

        [Authorize]
        [HttpGet("Users")]
        public IActionResult GetAll()
        {
            var users = userService.GetAll();
            return Ok(users);
        }
    }
}
