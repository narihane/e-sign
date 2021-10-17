﻿using eInvoice.Models.DTOModel.Invoices;
//using eInvoice.Models.Models;
using eInvoice.Services.Services;
using eInvoice.WebAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        //[Authorize]
        //[HttpPost("save")]
        //public IActionResult SaveInvoice([FromBody] DocumentsContainer document)
        //{
        //    try
        //    {
        //        documentsService.SaveInvoice(document);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex, ex.Message);
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpGet("get")]
        //public IActionResult GetInvoice(string Id)
        //{
        //    try
        //    {
        //        var invoice = documentsService.GetLocalInvoice(Id);
        //        return Ok(invoice);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex, ex.Message);
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[Authorize]
        //[HttpPost("submit")]
        //public async Task<IActionResult> SubmitDocuments([FromBody] List<string> internalIds)
        //{
        //    try
        //    {
        //        var response = await documentsService.SubmitDocs(internalIds);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex, ex.Message);
        //        return BadRequest();
        //    }
        //}
    }
}
