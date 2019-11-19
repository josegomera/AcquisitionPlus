using Microsoft.EntityFrameworkCore.Migrations;

namespace AcquisitionPlus.DAL.Migrations
{
    public partial class SetFieldNameInSupplierEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Suppliers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Suppliers");
        }
    }
}
