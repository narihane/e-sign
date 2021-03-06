using eInvoice.Models.DTOModel;
using eInvoice.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Services
{
    public interface IUserService
    {
        Task<string> LogIn(AuthRequestModel model);

        void Register(UserRegisterationModel model);

        IEnumerable<User> GetAll();

        string Approve(int id);
        
        string Reject(int id);

        User GetById(int id);

        User GetByUsername(string username);

        string Delete(int id);
    }
}
