using inventoryManagementCore.Data;
using inventoryManagementCore.Models;
using inventoryManagementCore.Services.Firebase;
using inventoryManagementCore.Utills;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventoryManagementCore.Services.InventoryService
{
    public class InventoryLogService : IInventoryLogService
    {
        private readonly DataContext _context;

        private readonly IMessagingClient _messagingClient;

        public InventoryLogService(DataContext context, IMessagingClient messagingClient)
        {
            _context = context;
            _messagingClient = messagingClient;
        }

        public async Task LogInventory(Inventory inventory, notificationAction action)
        {
            string inventoryJson = JsonConvert.SerializeObject(inventory);

            InventoryLog invLog = new InventoryLog();
            invLog.InventoryId = inventory.Id;
            invLog.ModifiedDate = DateTime.Now.ToString();
            invLog.UpdatedBy = "Abheeth";
            invLog.CreatedBy = "Abheeth";

            _context.InventoryLogs.Add(invLog);
            await _context.SaveChangesAsync();

            FireBaseNotification notification = new FireBaseNotification();
            notification.Title = "Inventory " + action.ToString();
            notification.Body = "A new inventory " + action.ToString();
            notification.Data = new Dictionary<String, String>();

            notification.Data.Add("Inventory", inventoryJson);

            await _messagingClient.SendNotification(notification);
        }
    }
}
