using eInvoice.Models.Models;
using eInvoice.Models.Models.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly eInvoiceContext dbcontext;

        public UserRepository(eInvoiceContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public void Delete(User entity)
        {
            dbcontext.Set<User>().Remove(entity);
            dbcontext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return dbcontext.Set<User>();
        }

        public User GetById(object id)
        {
            return dbcontext.Set<User>().Find(id);
        }

        public User GetUser(string username, string password)
        {
            return dbcontext.Set<User>().Where(x => x.Username == username && x.Password == password).FirstOrDefault();
        }

        public void Insert(User entity)
        {
            dbcontext.Set<User>().Add(entity);
            dbcontext.SaveChanges();
        }

        public void Update(User entity)
        {
            dbcontext.Set<User>().Update(entity);
            dbcontext.SaveChanges();
        }
    }
}
