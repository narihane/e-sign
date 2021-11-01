using eInvoice.Models.Enums;
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
        public UserRole Role { get; set; }
        public AccountStatus? Status { get; set; }

        public virtual Usersdetail Usersdetail { get; set; }
    }
}
