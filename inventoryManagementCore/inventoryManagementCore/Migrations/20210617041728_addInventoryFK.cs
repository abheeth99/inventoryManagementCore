using Microsoft.EntityFrameworkCore.Migrations;

namespace inventoryManagementCore.Migrations
{
    public partial class addInventoryFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_InventoryLogs_InventoryId",
                table: "InventoryLogs",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLogs_Inventories_InventoryId",
                table: "InventoryLogs",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLogs_Inventories_InventoryId",
                table: "InventoryLogs");

            migrationBuilder.DropIndex(
                name: "IX_InventoryLogs_InventoryId",
                table: "InventoryLogs");
        }
    }
}
