using eInvoice.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Services
{
    public interface IFilesService
    {
        CodeTemplate GetCodeMapTemplate(string id);

        Guid SaveCodeTemplate(CodeTemplate template);
    }
}
