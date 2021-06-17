using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using inventoryManagementCore.Utills;

namespace inventoryManagementCore.Dtos.Inventory
{
    public class UpdateInventoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public int UnitsCount { get; set; } = 0;

        public decimal UnitPrice { get; set; } = 0;

        public reorderLevel ReorderLevel { get; set; } = reorderLevel.low;

        public UpdateInventoryDto()
        {
            this.Name = "";
            this.UnitsCount = 0;
            this.UnitPrice = 0;
            this.ReorderLevel = reorderLevel.low;
        }
    }
}
