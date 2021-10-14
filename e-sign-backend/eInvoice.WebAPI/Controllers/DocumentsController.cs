using eInvoice.Models.DTOModel.Invoices;
using eInvoice.Models.Models;
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
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentsService documentsService;
        private readonly ILogger logger;

        public DocumentsController(IDocumentsService documentsService, ILogger logger)
        {
            this.documentsService = documentsService;
            this.logger = logger;
        }

        [Authorize]
        [HttpPost("save")]
        public IActionResult SaveInvoice(Invoice invoice)
        {
            try
            {
                documentsService.SaveInvoice(invoice);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost("submit")]
        public IActionResult SubmitDocuments(List<string> internalIds)
        {
            try
            {
                documentsService.SubmitDocs(internalIds);
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
