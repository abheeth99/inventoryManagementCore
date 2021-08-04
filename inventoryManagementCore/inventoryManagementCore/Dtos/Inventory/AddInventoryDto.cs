using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventoryManagementCore.Utills;

namespace inventoryManagementCore.Dtos.Inventory
{
    public class AddInventoryDto
    {
        public string Name { get; set; }

        public int UnitsCount { get; set; }

        public decimal UnitPrice { get; set; }

        public reorderLevel ReorderLevel { get; set; }

        public AddInventoryDto()
        {
            this.Name = "";
            this.UnitsCount = 0;
            this.UnitPrice = 0;
            this.ReorderLevel = reorderLevel.low;
        }
    }
}
