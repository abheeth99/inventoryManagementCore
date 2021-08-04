using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using inventoryManagementCore.Models;
using inventoryManagementCore.Services.InventoryService;
using inventoryManagementCore.Dtos.Inventory;
using Microsoft.AspNetCore.Cors;
using FirebaseAdmin.Messaging;
using inventoryManagementCore.Services.Firebase;

namespace inventoryManagementCore.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        private readonly IMessagingClient _messagingClient;
        public InventoryController(IInventoryService inventoryService, IMessagingClient messagingClient)
        {
            _inventoryService = inventoryService;
            _messagingClient = messagingClient;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetInventoryDto>>>> GetAll()
        {
            return Ok(await _inventoryService.GetAllInventories());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetInventoryDto>>> GetById(int id)
        {
            return Ok(await _inventoryService.GetInventoryById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetInventoryDto>>>> AddInventory(AddInventoryDto newInventory)
        {
            return Ok(await _inventoryService.AddInventory(newInventory));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetInventoryDto>>> UpdateInventory(UpdateInventoryDto updatedInventory)
        {
            var respone = await _inventoryService.UpdateInventory(updatedInventory);
            if (respone.Data == null)
            {
                return NotFound(respone);
            }
            return Ok(respone);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetInventoryDto>>>> DeleteInventory(int id)
        {
            var respone = await _inventoryService.DeleteInventory(id);
            if (respone.Data == null)
            {
                return NotFound(respone);
            }
            return Ok(respone);
        }

        [HttpPost("PushNotification")]
        public ActionResult PushNotificationAsync(FireBaseNotification notification)
        {
            _messagingClient.SendNotification(notification);
            return Ok();
        }

    }
}
