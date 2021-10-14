using eInvoice.Models.DTOModel;
using eInvoice.Services.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Services
{
    public class TaxAuthorityServices : ITaxAuthorityService
    {
        private readonly IdentityServiceHttpClient httpClient;

        public TaxAuthorityServices(IdentityServiceHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<GetTokenResponse> GetToken()
        {
            var tokenResponse = await httpClient.GetToken();
            return tokenResponse;
        }
    }
}
