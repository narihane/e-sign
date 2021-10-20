using eInvoice.Models.Models;
using eInvoice.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Services
{
    public class FilesService : IFilesService
    {
        private readonly IGenericRepository<CodeTemplate> genericRepo;

        public FilesService(IGenericRepository<CodeTemplate> genericRepo)
        {
            this.genericRepo = genericRepo;
        }

        public CodeTemplate GetCodeMapTemplate(string id)
        {
            var template = genericRepo.GetById(Guid.Parse(id));

            if (template == null)
            {
                throw new Exception($"Code template with id {id} is unavailable!");
            }
            return template;
        }

        public Guid SaveCodeTemplate(CodeTemplate template)
        {
            template.Id = Guid.NewGuid();
            genericRepo.Insert(template);

            return template.Id;
        }
    }
}
