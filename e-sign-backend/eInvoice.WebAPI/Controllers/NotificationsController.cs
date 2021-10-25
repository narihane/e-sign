using eInvoice.Services.Services;
using eInvoice.WebAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eInvoice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService notificationsService;
        private readonly ILogger logger;

        public NotificationsController(INotificationService notificationsService, ILogger logger)
        {
            this.notificationsService = notificationsService;
            this.logger = logger;
        }

        [Authorize]
        [HttpGet()]
        public async Task<IActionResult> GetNotifications(DateTime? dateFrom, DateTime? dateTo, string? type, string? status, string? channel, int pageSize = 10, int pageNumber = 1)
        {
            try
            {
                var result = await notificationsService.Get(dateFrom, dateTo, type, status, channel, pageSize, pageNumber);
                return Ok(result);
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
