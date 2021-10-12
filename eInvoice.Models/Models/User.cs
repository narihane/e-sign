using System;
using System.Collections.Generic;

#nullable disable

namespace eInvoice.Models.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual Usersdetail Usersdetail { get; set; }
    }
}
