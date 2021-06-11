﻿using inventoryManagementCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using inventoryManagementCore.Dtos.Inventory;
using AutoMapper;
using inventoryManagementCore.Data;
using Microsoft.EntityFrameworkCore;

namespace inventoryManagementCore.Services.InventoryService
{
    public class InventoryService : IInventoryService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public InventoryService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetInventoryDto>>> GetAllInventories()
        {
            var serviceResponse = new ServiceResponse<List<GetInventoryDto>>();
            var dbInventories = await _context.Inventories.ToListAsync();

            serviceResponse.Data = dbInventories.Select(i => _mapper.Map<GetInventoryDto>(i)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetInventoryDto>> GetInventoryById(int id)
        {
            var serviceResponse = new ServiceResponse<GetInventoryDto>();
            var dbInventories = await _context.Inventories.FirstOrDefaultAsync(i => i.Id == id);

            serviceResponse.Data = _mapper.Map<GetInventoryDto>(dbInventories);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetInventoryDto>>> AddInventory(AddInventoryDto newInventory)
        {
            var serviceResponse = new ServiceResponse<List<GetInventoryDto>>();

            Inventory inventory = _mapper.Map<Inventory>(newInventory);
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Inventories.Select(i => _mapper.Map<GetInventoryDto>(i)).ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetInventoryDto>> UpdateInventory(UpdateInventoryDto updatedInventory)
        {
            var serviceResponse = new ServiceResponse<GetInventoryDto>();
            try
            {
                Inventory inventory = await _context.Inventories.FirstOrDefaultAsync(i => i.Id == updatedInventory.Id);

                inventory.Name = updatedInventory.Name;
                inventory.UnitsCount = updatedInventory.UnitsCount;
                inventory.UnitPrice = updatedInventory.UnitPrice;
                inventory.ReorderLevel = updatedInventory.ReorderLevel;

                await _context.SaveChangesAsync();

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
                Inventory inventory = await _context.Inventories.FirstAsync(i => i.Id == id);
                _context.Inventories.Remove(inventory);

                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Inventories.Select(i => _mapper.Map<GetInventoryDto>(i)).ToList();
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
