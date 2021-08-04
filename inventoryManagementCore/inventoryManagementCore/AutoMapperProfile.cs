using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using inventoryManagementCore.Models;
using inventoryManagementCore.Dtos.Inventory;

namespace inventoryManagementCore
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Inventory, GetInventoryDto>();
            CreateMap<AddInventoryDto, Inventory>();
        }
    }
}
