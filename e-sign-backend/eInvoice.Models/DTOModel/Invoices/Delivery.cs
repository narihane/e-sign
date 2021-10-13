﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Models.DTOModel.Invoices
{
    public class Delivery
    {
        public string approach { get; set; }
        public string packaging { get; set; }
        public string dateValidity { get; set; }
        public string exportPort { get; set; }
        public string countryOfOrigin { get; set; }
        public decimal grossWeight { get; set; }
        public decimal netWeight { get; set; }
        public string terms { get; set; }
    }
}
