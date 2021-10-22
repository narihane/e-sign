﻿using eInvoice.Models.DTOModel.Invoices;
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
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoicesService invoiceService;
        private readonly ILogger logger;

        public InvoicesController(IInvoicesService invoiceService, ILogger logger)
        {
            this.invoiceService = invoiceService;
            this.logger = logger;
        }

        //[Authorize]
        [HttpPost("save")]
        public IActionResult SaveInvoices([FromBody] DocumentsContainer document)
        {
            try
            {
                invoiceService.SaveInvoices(document);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get/{Id}")]
        public IActionResult GetInvoice(string Id)
        {
            try
            {
                var invoice = invoiceService.GetLocalInvoice(Id);
                return Ok(invoice);
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get")]
        public IActionResult GetAllInvoices()
        {
            try
            {
                var invoice = invoiceService.GetAllInvoices();
                return Ok(invoice);
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
