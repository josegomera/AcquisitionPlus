using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcquisitionPlus.DAL.Migrations
{
    public partial class CreatedRelationshipProductAndPurchaseOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Employees_IdEmployee",
                table: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdEmployee",
                table: "PurchaseOrders",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "IdProduct",
                table: "PurchaseOrders",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "PurchaseOrders",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_IdProduct",
                table: "PurchaseOrders",
                column: "IdProduct",
                unique: true,
                filter: "[IdProduct] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Employees_IdEmployee",
                table: "PurchaseOrders",
                column: "IdEmployee",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Products_IdProduct",
                table: "PurchaseOrders",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Employees_IdEmployee",
                table: "PurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Products_IdProduct",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_IdProduct",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "PurchaseOrders");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdEmployee",
                table: "PurchaseOrders",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdProduct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPurchaseOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_PurchaseOrders_IdPurchaseOrder",
                        column: x => x.IdPurchaseOrder,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_IdProduct",
                table: "Item",
                column: "IdProduct",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_IdPurchaseOrder",
                table: "Item",
                column: "IdPurchaseOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Employees_IdEmployee",
                table: "PurchaseOrders",
                column: "IdEmployee",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
