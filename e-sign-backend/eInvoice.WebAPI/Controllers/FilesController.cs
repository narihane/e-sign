using eInvoice.Models.Models;
using eInvoice.Services.Services;
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
    public class FilesController : ControllerBase
    {
        private readonly IFilesService filesService;
        private readonly ILogger logger;

        public FilesController(IFilesService filesService, ILogger logger)
        {
            this.filesService = filesService;
            this.logger = logger;
        }

        [HttpPost("save")]
        public IActionResult SaveFile([FromBody] CodeTemplate template)
        {
            try
            {
                var id = filesService.SaveCodeTemplate(template);
                return Ok(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("download/{id}")]
        public IActionResult DownloadFile(string id)
        {
            try
            {
                var template = filesService.GetCodeMapTemplate(id);
                var file = File(template.File, template.FileType, template.FileName);
                return file;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message); 
                return BadRequest(ex.Message);
            }
        }
    }
}
