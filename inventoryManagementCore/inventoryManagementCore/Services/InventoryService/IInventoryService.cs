using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using inventoryManagementCore.Models;
using inventoryManagementCore.Dtos.Inventory;

namespace inventoryManagementCore.Services.InventoryService
{
    public interface IInventoryService
    {
        Task<ServiceResponse<List<GetInventoryDto>>> GetAllInventories();
        Task<ServiceResponse<GetInventoryDto>> GetInventoryById(int id);
        Task<ServiceResponse<List<GetInventoryDto>>> AddInventory(AddInventoryDto newInventory);
        Task<ServiceResponse<GetInventoryDto>> UpdateInventory(UpdateInventoryDto updatedInventory);
        Task<ServiceResponse<List<GetInventoryDto>>> DeleteInventory(int id);
    }
}
