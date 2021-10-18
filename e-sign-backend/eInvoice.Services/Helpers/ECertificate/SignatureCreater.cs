using eInvoice.Models.DTOModel.Invoices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Helpers.ECertificate
{
    public class SignatureCreater
    {
        public static Document CreateSignature(Document document)
        {
            var jsonString = JsonConvert.SerializeObject(document);
            var JObject = JsonConvert.DeserializeObject<JObject>(jsonString, new JsonSerializerSettings()
            {
                FloatFormatHandling = FloatFormatHandling.String,
                FloatParseHandling = FloatParseHandling.Decimal,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateParseHandling = DateParseHandling.None
            });
            var canonicalString = CanonicalSerializer.Serialize(JObject);
            string cades = "";
            if (document.documentTypeVersion.Equals("0.9", StringComparison.OrdinalIgnoreCase))
            {
                cades = "ANY";
            }
            else
            {
                cades = Encryptor.SignWithCMS(canonicalString);
            }
            document.signatures = new List<Signature>();
            var signature = new Signature
            {
                signatureType = "I",
                value = cades
            };
            document.signatures.Add(signature);
            return document;
        }
    }
}
