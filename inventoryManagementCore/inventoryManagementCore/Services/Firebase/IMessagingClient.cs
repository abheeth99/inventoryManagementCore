using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventoryManagementCore.Services.Firebase
{
    public interface IMessagingClient
    {
        Task SendNotification(string token, string title, string body);
    }
}
