using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Services
{
    public interface ICodesService
    {
        Task SubmitNewCodes(IFormFile file);
        Task RequestCodeReuse(IFormFile file);
    }
}
