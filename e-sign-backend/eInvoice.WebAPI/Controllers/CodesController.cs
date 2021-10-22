using eInvoice.Services.Services;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodesController : ControllerBase
    {
        private readonly ICodesService codesService;
        private readonly ILogger logger;
        public CodesController(ICodesService codesService, ILogger logger)
        {
            this.codesService = codesService;
            this.logger = logger;
        }

        [HttpPost("new/request")]
        public async Task<IActionResult> UploadNewCodeUsageBulk()
        {
            try
            {
                var file = Request.Form.Files.FirstOrDefault();
                await codesService.SubmitNewCodes(file);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("reuse/request")]
        public async Task<IActionResult> UploadExistingCodeUsageBulk()
        {
            try
            {
                var file = Request.Form.Files.FirstOrDefault();
                await codesService.RequestCodeReuse(file);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
