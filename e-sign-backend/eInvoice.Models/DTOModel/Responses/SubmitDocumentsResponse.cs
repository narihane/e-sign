using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Models.DTOModel.Responses
{
    public class SubmitDocumentsResponse
    {
        public string submissionId { get; set; }
        public List<DocumentAccepted> acceptedDocuments { get; set; }
        public List<RejectedDocument> rejectedDocuments { get; set; }
    }

    public class DocumentAccepted
    {
        public string uuid { get; set; }
        public string longId { get; set; }
        public string internalId { get; set; }
    }

    public class RejectedDocument
    {
        public string internalId { get; set; }
        public Error error { get; set; }
    }

    public class Detail
    {
        public object code { get; set; }
        public string message { get; set; }
        public string target { get; set; }
        public object propertyPath { get; set; }
        public object details { get; set; }
    }

    public class Error
    {
        public object code { get; set; }
        public string message { get; set; }
        public string target { get; set; }
        public object propertyPath { get; set; }
        public List<Detail> details { get; set; }
    }
}
