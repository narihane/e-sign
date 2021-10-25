using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Models.DTOModel.Responses
{
    public class GetNotificationsResponse
    {
        public List<Notification> result { get; set; }
        public PaginationData metadata { get; set; }
    }

    public class Notification
    {
        public int notificationId { get; set; }
        public string receiverName { get; set; }
        public string receiverType { get; set; }
        public DateTime creationDateTime { get; set; }
        public DateTime deliveredDateTime { get; set; }
        public DateTime receivedDateTime { get; set; }
        public string messageData { get; set; }
        public int typeId { get; set; }
        public string status { get; set; }
        public string typeName { get; set; }
        public int notificationDeliveryId { get; set; }
        public string finalMessage { get; set; }
        public string address { get; set; }
        public string channel { get; set; }
        public string documentUUID { get; set; }
        public string detailsUrl { get; set; }
        public string notificationSubject { get; set; }
        public string metadata { get; set; }
        public bool isBacthed { get; set; }
    }
}
