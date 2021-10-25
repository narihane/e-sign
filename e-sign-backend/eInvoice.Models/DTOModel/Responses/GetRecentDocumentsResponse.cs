﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Models.DTOModel.Responses
{
    public class GetRecentDocumentsResponse
    {
        public List<DocumentsResult> result { get; set; }
        public PaginationData metadata { get; set; }
    }

    public class DocumentsResult
    {
        public string publicUrl { get; set; }
        public string uuid { get; set; }
        public string submissionUUID { get; set; }
        public string longId { get; set; }
        public string internalId { get; set; }
        public string typeName { get; set; }
        public string documentTypeNamePrimaryLang { get; set; }
        public string documentTypeNameSecondaryLang { get; set; }
        public string typeVersionName { get; set; }
        public string issuerId { get; set; }
        public string issuerName { get; set; }
        public string receiverId { get; set; }
        public string receiverName { get; set; }
        public DateTime dateTimeIssued { get; set; }
        public DateTime dateTimeReceived { get; set; }
        public double totalSales { get; set; }
        public double totalDiscount { get; set; }
        public double netAmount { get; set; }
        public double total { get; set; }
        public int maxPercision { get; set; }
        public object invoiceLineItemCodes { get; set; }
        public object cancelRequestDate { get; set; }
        public object rejectRequestDate { get; set; }
        public object cancelRequestDelayedDate { get; set; }
        public object rejectRequestDelayedDate { get; set; }
        public object declineCancelRequestDate { get; set; }
        public object declineRejectRequestDate { get; set; }
        public string documentStatusReason { get; set; }
        public string status { get; set; }
        public string createdByUserId { get; set; }
    }
}
