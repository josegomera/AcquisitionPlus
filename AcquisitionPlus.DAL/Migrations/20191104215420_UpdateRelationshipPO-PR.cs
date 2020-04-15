using Microsoft.EntityFrameworkCore.Migrations;

namespace AcquisitionPlus.DAL.Migrations
{
    public partial class UpdateRelationshipPOPR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_IdProduct",
                table: "PurchaseOrders");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_IdProduct",
                table: "PurchaseOrders",
                column: "IdProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_IdProduct",
                table: "PurchaseOrders");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_IdProduct",
                table: "PurchaseOrders",
                column: "IdProduct",
                unique: true,
                filter: "[IdProduct] IS NOT NULL");
        }
    }
}
