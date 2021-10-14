using eInvoice.Models.DTOModel;
using eInvoice.Models.DTOModel.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Services
{
    public interface ITaxAuthorityService
    {
        Task<GetTokenResponse> GetToken();
    }
}
