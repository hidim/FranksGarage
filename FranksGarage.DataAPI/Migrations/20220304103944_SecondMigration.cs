using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FranksGarage.DataAPI.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Warehouse_WarehouseModelId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_WarehouseModelId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "WarehouseModelId",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarsId",
                table: "Warehouse",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_CarsId",
                table: "Warehouse",
                column: "CarsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Cars_CarsId",
                table: "Warehouse",
                column: "CarsId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Cars_CarsId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_CarsId",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "CarsId",
                table: "Warehouse");

            migrationBuilder.AddColumn<int>(
                name: "WarehouseModelId",
                table: "Cars",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_WarehouseModelId",
                table: "Cars",
                column: "WarehouseModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Warehouse_WarehouseModelId",
                table: "Cars",
                column: "WarehouseModelId",
                principalTable: "Warehouse",
                principalColumn: "Id");
        }
    }
}
