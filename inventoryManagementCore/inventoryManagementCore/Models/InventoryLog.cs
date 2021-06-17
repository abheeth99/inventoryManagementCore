using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventoryManagementCore.Models
{
    public class InventoryLog
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = "";
        public string UpdatedBy { get; set; } = "";
        public string ModifiedDate { get; set; } = DateTime.Now.ToString();

        // Navigation Properties
        public int InventoryId{ get; set; }
        public Inventory Inventory{ get; set; }
    }
}
