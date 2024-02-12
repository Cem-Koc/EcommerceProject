using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig_test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ProductSizes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "ProductSizes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ProductSizes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ProductColors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "ProductColors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ProductColors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CustomerTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "CustomerTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CustomerTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedBy", "CreatedDate", "DeletedBy", "ModifiedBy", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09337116-5629-493c-b071-dcd19a3cb171", "Test", new DateTime(2024, 2, 13, 2, 5, 3, 302, DateTimeKind.Local).AddTicks(5096), null, null, "AQAAAAIAAYagAAAAEHwTROw+dxg5PcDJaqXBZDFvGgezWs9VhuYPi+i0xIm0CKa7OMK0AwzHsZd9f/6cAA==", "be34d2c7-5259-4651-89d6-0f0b6873f148" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedBy", "CreatedDate", "DeletedBy", "ModifiedBy", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40a07574-1600-4f54-8a34-566554e9658f", "Test", new DateTime(2024, 2, 13, 2, 5, 3, 356, DateTimeKind.Local).AddTicks(7169), null, null, "AQAAAAIAAYagAAAAEHOwmk1SxAGjsk5tLYszcmRthNLffBTKRCaDgPLXlgn6CNiu0uP6almZTG0f3lAQjA==", "938aa1b7-1d70-4936-ae9e-3cf192d92dd8" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "ModifiedBy" },
                values: new object[] { "Undefined", new DateTime(2024, 2, 13, 2, 5, 3, 410, DateTimeKind.Local).AddTicks(6418), null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "ModifiedBy" },
                values: new object[] { "Undefined", new DateTime(2024, 2, 13, 2, 5, 3, 410, DateTimeKind.Local).AddTicks(6428), null, null });

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "ModifiedBy" },
                values: new object[] { "Undefined", new DateTime(2024, 2, 13, 2, 5, 3, 411, DateTimeKind.Local).AddTicks(1533), null, null });

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "ModifiedBy" },
                values: new object[] { "Undefined", new DateTime(2024, 2, 13, 2, 5, 3, 411, DateTimeKind.Local).AddTicks(1535), null, null });

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "ModifiedBy" },
                values: new object[] { "Undefined", new DateTime(2024, 2, 13, 2, 5, 3, 411, DateTimeKind.Local).AddTicks(1195), null, null });

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "ModifiedBy" },
                values: new object[] { "Undefined", new DateTime(2024, 2, 13, 2, 5, 3, 411, DateTimeKind.Local).AddTicks(1200), null, null });

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "ModifiedBy" },
                values: new object[] { "Undefined", new DateTime(2024, 2, 13, 2, 5, 3, 411, DateTimeKind.Local).AddTicks(1201), null, null });

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "ModifiedBy" },
                values: new object[] { "Undefined", new DateTime(2024, 2, 13, 2, 5, 3, 411, DateTimeKind.Local).AddTicks(1365), null, null });

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "ModifiedBy" },
                values: new object[] { "Undefined", new DateTime(2024, 2, 13, 2, 5, 3, 411, DateTimeKind.Local).AddTicks(1370), null, null });

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "ModifiedBy" },
                values: new object[] { "Undefined", new DateTime(2024, 2, 13, 2, 5, 3, 411, DateTimeKind.Local).AddTicks(1371), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "ModifiedBy" },
                values: new object[] { "Undefined", new DateTime(2024, 2, 13, 2, 5, 3, 410, DateTimeKind.Local).AddTicks(7418), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "ModifiedBy" },
                values: new object[] { "Undefined", new DateTime(2024, 2, 13, 2, 5, 3, 410, DateTimeKind.Local).AddTicks(7431), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "ModifiedBy" },
                values: new object[] { "Undefined", new DateTime(2024, 2, 13, 2, 5, 3, 410, DateTimeKind.Local).AddTicks(7434), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedBy", "CreatedDate", "DeletedBy", "ModifiedBy" },
                values: new object[] { "Undefined", new DateTime(2024, 2, 13, 2, 5, 3, 410, DateTimeKind.Local).AddTicks(7436), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProductSizes");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ProductSizes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ProductSizes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProductColors");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ProductColors");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ProductColors");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CustomerTypes");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "CustomerTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CustomerTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e005f9e1-d52b-4e93-ae94-c1e8dcc87033", new DateTime(2024, 2, 12, 0, 13, 31, 335, DateTimeKind.Local).AddTicks(2607), "AQAAAAIAAYagAAAAEI8RZ3uwhtYi3UT0xxEzkNEpe4zbIpbO3wUqxtRwNNN2Uzf8lSX7sPBWgSxskHW4sA==", "a7075e4c-5f33-4599-a92e-228dadc5f26f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c4887de-4296-4244-8477-188454407f19", new DateTime(2024, 2, 12, 0, 13, 31, 410, DateTimeKind.Local).AddTicks(4589), "AQAAAAIAAYagAAAAEIHqTHb+h0Pe9GlKcGmx/DVUIB+N0xjdIsWB6ft3YcTUKH96c9SqEOOej8I2j4mP5A==", "d09a8fea-cf9b-4782-b73d-076183a94beb" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 12, 0, 13, 31, 480, DateTimeKind.Local).AddTicks(7798));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 12, 0, 13, 31, 480, DateTimeKind.Local).AddTicks(7812));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 12, 0, 13, 31, 481, DateTimeKind.Local).AddTicks(4009));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 12, 0, 13, 31, 481, DateTimeKind.Local).AddTicks(4011));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 12, 0, 13, 31, 481, DateTimeKind.Local).AddTicks(3661));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 12, 0, 13, 31, 481, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 12, 0, 13, 31, 481, DateTimeKind.Local).AddTicks(3670));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 12, 0, 13, 31, 481, DateTimeKind.Local).AddTicks(3838));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 12, 0, 13, 31, 481, DateTimeKind.Local).AddTicks(3840));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 12, 0, 13, 31, 481, DateTimeKind.Local).AddTicks(3840));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 12, 0, 13, 31, 480, DateTimeKind.Local).AddTicks(9122));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 12, 0, 13, 31, 480, DateTimeKind.Local).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 12, 0, 13, 31, 480, DateTimeKind.Local).AddTicks(9137));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 12, 0, 13, 31, 480, DateTimeKind.Local).AddTicks(9140));
        }
    }
}
