using eInvoice.Models.DTOModel;
using eInvoice.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace eInvoice.WebAPI.Controllers
{
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IUserService userService;

        public LogInController(IUserService userService, ILogger logger)
        {
            this.userService = userService;
            this.logger = logger;
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
    }
}
