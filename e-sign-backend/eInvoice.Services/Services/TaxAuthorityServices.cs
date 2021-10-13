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
        private readonly BaseHttpClient httpClient;

        public TaxAuthorityServices(BaseHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task GetToken()
        {
            await httpClient.GetToken();
        }
    }
}
