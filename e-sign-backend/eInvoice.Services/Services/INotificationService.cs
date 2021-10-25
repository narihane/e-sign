using eInvoice.Models.DTOModel.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Services
{
    public interface INotificationService
    {
        Task<GetNotificationsResponse> Get(DateTime? dateFrom, DateTime? dateTo, string? type, string? status, string? channel, int pageSize, int pageNumber);
    }
}
