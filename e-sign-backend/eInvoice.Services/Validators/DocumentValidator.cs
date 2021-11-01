using eInvoice.Models.Enums;
using eInvoice.Models.Models;
using eInvoice.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Validators
{
    public class DocumentValidator
    {
        private readonly IGenericRepository<Issuer> issuerRepo;

        public DocumentValidator(IGenericRepository<Issuer> issuerRepo)
        {
            this.issuerRepo = issuerRepo;
        }

        public bool ValidateInvoice(Invoice invoice)
        {
            var issuer = issuerRepo.GetAll().FirstOrDefault();
            if (issuer == null)
                throw new Exception("Invalid Issuer registeration number!");

            if (issuer.PriceThreshold == null)
                throw new Exception("Price Threshold is not defined, Please set a price limit for your business in the admin settings page!");

            if (invoice.Receiver.Type == IssuerType.P.ToString() && invoice.TotalAmount < issuer.PriceThreshold)
                return true;

            else
            {
                if (string.IsNullOrWhiteSpace(invoice.Receiver.RegistrationNumber))
                    throw new Exception($"Registeration Number is empty: Please provide buyer registeration number; Receiver is of type 'P' as in Person and invoice total amount: '{invoice.TotalAmount}' was greater than your business price limit: {issuer.PriceThreshold}");

                if (string.IsNullOrWhiteSpace(invoice.Receiver.Name))
                    throw new Exception($"Buyer Name is empty, Please provide buyer name!");

                if (string.IsNullOrWhiteSpace(invoice.Receiver.Country))
                    throw new Exception($"Buyer Country is empty, Please provide buyer nationality!");

                if (string.IsNullOrWhiteSpace(invoice.Receiver.Governate))
                    throw new Exception($"Buyer Governate is empty, Please provide buyer governate!");

                if (string.IsNullOrWhiteSpace(invoice.Receiver.RegionCity))
                    throw new Exception($"Buyer Region City is empty, Please provide buyer region city!");

                if (string.IsNullOrWhiteSpace(invoice.Receiver.Street))
                    throw new Exception($"Buyer street is empty, Please provide buyer street!");

                if (string.IsNullOrWhiteSpace(invoice.Receiver.BuildingNumber))
                    throw new Exception($"Buyer building number is empty, Please provide buyer building number!");
            }
            return true;
        }
    }
}
