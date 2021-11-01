using eInvoice.Services.Services;
using eInvoice.WebAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace eInvoice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IUserService userService;

        public UsersController(IUserService userService, ILogger logger)
        {
            this.userService = userService;
            this.logger = logger;
        }

        [Authorize]
        [HttpGet("all")]
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

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var users = userService.GetById(id);
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

        [Authorize]
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var users = userService.Delete(id);
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

        [Authorize]
        [HttpPut("approve/{id}")]
        public IActionResult ApproveUserAccount(int id)
        {
            try
            {
                var status = userService.Approve(id);
                return Ok(status);
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

        [Authorize]
        [HttpPut("reject/{id}")]
        public IActionResult RejectUserAccount(int id)
        {
            try
            {
                var status = userService.Reject(id);
                return Ok(status);
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
