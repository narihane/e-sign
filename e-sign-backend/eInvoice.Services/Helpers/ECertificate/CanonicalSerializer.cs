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
    public class CanonicalSerializer
    {
        public static string Serialize(JObject jObject)
        {
            return SerializeJToken(jObject);
        }

        private static string SerializeJToken(JToken jToken)
        {
            string serialized = "";
            if (jToken.Parent is null)
            {
                SerializeJToken(jToken.First);
            }
            else
            {
                if (jToken.Type == JTokenType.Property)
                {
                    string name = ((JProperty)jToken).Name.ToUpper();
                    serialized += "\"" + name + "\"";
                    foreach (var property in jToken)
                    {
                        if (property.Type == JTokenType.Object)
                        {
                            serialized += SerializeJToken(property);
                        }
                        if (property.Type == JTokenType.Boolean || property.Type == JTokenType.Integer || property.Type == JTokenType.Float || property.Type == JTokenType.Date)
                        {
                            serialized += "\"" + property.Value<string>() + "\"";
                        }
                        if (property.Type == JTokenType.String)
                        {
                            serialized += JsonConvert.ToString(property.Value<string>());
                        }
                        if (property.Type == JTokenType.Array)
                        {
                            foreach (var item in property.Children())
                            {
                                serialized += "\"" + ((JProperty)jToken).Name.ToUpper() + "\"";
                                serialized += SerializeJToken(item);
                            }
                        }
                    }
                }
            }
            if (jToken.Type == JTokenType.Object)
            {
                foreach (var property in jToken.Children())
                {

                    if (property.Type == JTokenType.Object || property.Type == JTokenType.Property)
                    {
                        serialized += SerializeJToken(property);
                    }
                }
            }

            return serialized;
        }
    }
}
