using eInvoice.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Models.DTOModel
{
    public class AuthResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthResponseModel(User user, string token)
        {
            Id = user.Id;
            FirstName = user.Usersdetail.FirstName;
            LastName = user.Usersdetail.LastName;
            Username = user.Username;
            Token = token;
        }
    }
}
