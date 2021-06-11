using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using inventoryManagementCore.Utilities;

namespace inventoryManagementCore.Dtos.Inventory
{
    public class GetInventoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public int UnitsCount { get; set; } = 0;

        public decimal UnitPrice { get; set; } = 0;

        public reorderLevel ReorderLevel { get; set; } = reorderLevel.low;
    }
}
