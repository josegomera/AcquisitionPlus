using Microsoft.EntityFrameworkCore.Migrations;

namespace AcquisitionPlus.DAL.Migrations
{
    public partial class AddedUnitCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "UnitCost",
                table: "Products",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitCost",
                table: "Products");
        }
    }
}
