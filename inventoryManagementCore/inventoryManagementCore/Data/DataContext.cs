using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventoryManagementCore.Models;
using Microsoft.EntityFrameworkCore;

namespace inventoryManagementCore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryLog> InventoryLogs { get; set; }
    }
}
