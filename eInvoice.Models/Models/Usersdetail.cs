using System;
using System.Collections.Generic;

#nullable disable

namespace eInvoice.Models.Models
{
    public partial class Usersdetail
    {
        public int Userid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string FullAddress { get; set; }

        public virtual User User { get; set; }
    }
}
