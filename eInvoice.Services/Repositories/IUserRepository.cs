using eInvoice.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Repositories
{
    public interface IUserRepository
    {
        User GetById(object id);

        IEnumerable<User> GetAll();

        User GetUser(string username, string password);

        void Insert(User entity);

        void Delete(User entity);

        void Update(User entity);
    }
}
