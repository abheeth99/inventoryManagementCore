using inventoryManagementCore.Models;
using inventoryManagementCore.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventoryManagementCore.Services.InventoryService
{
    public interface IInventoryLogService
    {
        Task LogInventory(Inventory inventory, notificationAction action);
    }
}
