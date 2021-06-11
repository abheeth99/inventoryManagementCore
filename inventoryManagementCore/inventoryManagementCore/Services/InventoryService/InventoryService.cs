using inventoryManagementCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using inventoryManagementCore.Dtos.Inventory;
using AutoMapper;

namespace inventoryManagementCore.Services.InventoryService
{
    public class InventoryService : IInventoryService
    {
        // Mocked inventory to set up basic CRUD
        private static List<Inventory> inventories = new List<Inventory> {
            new Inventory() { Id = 1, Name = "First" },
            new Inventory() { Id = 2, Name = "Second" }
        };

        private readonly IMapper _mapper;

        public InventoryService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetInventoryDto>>> GetAllInventories()
        {
            var serviceResponse = new ServiceResponse<List<GetInventoryDto>>();
            serviceResponse.Data = inventories.Select(i => _mapper.Map<GetInventoryDto>(i)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetInventoryDto>> GetInventoryById(int id)
        {
            var serviceResponse = new ServiceResponse<GetInventoryDto>();
            serviceResponse.Data = _mapper.Map<GetInventoryDto>(inventories.FirstOrDefault(i => i.Id == id));
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetInventoryDto>>> AddInventory(AddInventoryDto newInventory)
        {
            var serviceResponse = new ServiceResponse<List<GetInventoryDto>>();

            Inventory inventory = _mapper.Map<Inventory>(newInventory);
            inventory.Id = inventories.Max(i => i.Id) + 1;

            inventories.Add(inventory);

            serviceResponse.Data = inventories.Select(i => _mapper.Map<GetInventoryDto>(i)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetInventoryDto>> UpdateInventory(UpdateInventoryDto updatedInventory)
        {
            var serviceResponse = new ServiceResponse<GetInventoryDto>();
            try
            {
                Inventory inventory = inventories.FirstOrDefault(i => i.Id == updatedInventory.Id);

                inventory.Name = updatedInventory.Name;
                inventory.UnitsCount = updatedInventory.UnitsCount;
                inventory.UnitPrice = updatedInventory.UnitPrice;
                inventory.ReorderLevel = updatedInventory.ReorderLevel;

                serviceResponse.Data = _mapper.Map<GetInventoryDto>(inventory);
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetInventoryDto>>> DeleteInventory(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetInventoryDto>>();
            try
            {
                Inventory inventory = inventories.First(i => i.Id == id);
                inventories.Remove(inventory);

                serviceResponse.Data = inventories.Select(i => _mapper.Map<GetInventoryDto>(i)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
