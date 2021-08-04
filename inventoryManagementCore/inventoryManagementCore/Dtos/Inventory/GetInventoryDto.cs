using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using inventoryManagementCore.Utills;

namespace inventoryManagementCore.Dtos.Inventory
{
    public class GetInventoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UnitsCount { get; set; }

        public decimal UnitPrice { get; set; }

        public reorderLevel ReorderLevel { get; set; }

        public GetInventoryDto()
        {
            this.Name = "";
            this.UnitsCount = 0;
            this.UnitPrice = 0;
            this.ReorderLevel = reorderLevel.low;
        }
    }
}
