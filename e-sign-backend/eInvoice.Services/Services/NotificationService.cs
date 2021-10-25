using eInvoice.Models.DTOModel.Responses;
using eInvoice.Services.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Services
{
    public class NotificationService: INotificationService
    {
        private readonly SystemApiHttpClient httpClient;

        public NotificationService(SystemApiHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<GetNotificationsResponse> Get(DateTime? dateFrom, DateTime? dateTo, string? type, string? status, string? channel, int pageSize, int pageNumber)
        {
            var notifications = await httpClient.GetNotifications(dateFrom, dateTo, type, status, channel, pageSize, pageNumber);
            return notifications;
        }

    }
}
