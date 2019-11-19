using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcquisitionPlus.DAL.Migrations
{
    public partial class SetFieldsToRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_IdDepartment",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_IdSupplier",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_UnitOfMeasurements_IdUnitOfMeasurement",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Employees_IdEmployee",
                table: "PurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Products_IdProduct",
                table: "PurchaseOrders");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdProduct",
                table: "PurchaseOrders",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdEmployee",
                table: "PurchaseOrders",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdUnitOfMeasurement",
                table: "Products",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdSupplier",
                table: "Products",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdDepartment",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_IdDepartment",
                table: "Employees",
                column: "IdDepartment",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_IdSupplier",
                table: "Products",
                column: "IdSupplier",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UnitOfMeasurements_IdUnitOfMeasurement",
                table: "Products",
                column: "IdUnitOfMeasurement",
                principalTable: "UnitOfMeasurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Employees_IdEmployee",
                table: "PurchaseOrders",
                column: "IdEmployee",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Products_IdProduct",
                table: "PurchaseOrders",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_IdDepartment",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_IdSupplier",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_UnitOfMeasurements_IdUnitOfMeasurement",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Employees_IdEmployee",
                table: "PurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Products_IdProduct",
                table: "PurchaseOrders");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdProduct",
                table: "PurchaseOrders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "IdEmployee",
                table: "PurchaseOrders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "IdUnitOfMeasurement",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "IdSupplier",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "IdDepartment",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_IdDepartment",
                table: "Employees",
                column: "IdDepartment",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_IdSupplier",
                table: "Products",
                column: "IdSupplier",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UnitOfMeasurements_IdUnitOfMeasurement",
                table: "Products",
                column: "IdUnitOfMeasurement",
                principalTable: "UnitOfMeasurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
