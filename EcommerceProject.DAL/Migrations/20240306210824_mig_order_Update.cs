using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig_order_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1177bbef-9c9a-4565-b00a-7f0af946d141", new DateTime(2024, 3, 7, 0, 8, 23, 922, DateTimeKind.Local).AddTicks(6394), "AQAAAAIAAYagAAAAEIFLqwvbBOlVCFcsgu4Jq/lJhBxyR+5hdWc7Cj56GpZMUH78oTGmP/nVW0RhidEnKw==", "340330b8-6bfc-45c4-bfa2-143565c933fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "187b0df9-50f3-4285-8228-1964caee8b79", new DateTime(2024, 3, 7, 0, 8, 23, 982, DateTimeKind.Local).AddTicks(9002), "AQAAAAIAAYagAAAAEFTBldrA8XeEL0FEkhfWLJFapxBBcbmlk/JG7gyZmZms+3xnN3OKksylNCI/nGFxpg==", "8d8f5feb-4fff-4056-9825-6e7f25325259" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 7, 0, 8, 24, 43, DateTimeKind.Local).AddTicks(5621));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 7, 0, 8, 24, 43, DateTimeKind.Local).AddTicks(5639));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 7, 0, 8, 24, 45, DateTimeKind.Local).AddTicks(382));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 7, 0, 8, 24, 45, DateTimeKind.Local).AddTicks(384));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 7, 0, 8, 24, 44, DateTimeKind.Local).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 7, 0, 8, 24, 44, DateTimeKind.Local).AddTicks(9766));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 7, 0, 8, 24, 44, DateTimeKind.Local).AddTicks(9767));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 7, 0, 8, 24, 45, DateTimeKind.Local).AddTicks(88));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 7, 0, 8, 24, 45, DateTimeKind.Local).AddTicks(90));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 7, 0, 8, 24, 45, DateTimeKind.Local).AddTicks(91));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 7, 0, 8, 24, 44, DateTimeKind.Local).AddTicks(521));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 7, 0, 8, 24, 44, DateTimeKind.Local).AddTicks(538));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 7, 0, 8, 24, 44, DateTimeKind.Local).AddTicks(542));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 7, 0, 8, 24, 44, DateTimeKind.Local).AddTicks(544));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "851c0316-2cc8-479e-b406-014272c14d5c", new DateTime(2024, 2, 13, 15, 19, 16, 933, DateTimeKind.Local).AddTicks(3312), "AQAAAAIAAYagAAAAEIJOAD/IUYH48ERibuMnCDLaEdMzTqZSllpsBOiJUUrrQjWgZbehpEi/+3cUqL2Xlg==", "7f314cfb-3039-4dd5-aec5-34a9c9c18e55" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "139170ff-6af6-4a5e-a890-4918602292b9", new DateTime(2024, 2, 13, 15, 19, 16, 988, DateTimeKind.Local).AddTicks(4734), "AQAAAAIAAYagAAAAEOmxBtbiDw7OuuJ5B48dds/hbkNjUHn5ie6OyiXgbOioE6FHXO19L/+CiXyqczmgKA==", "0dea2d26-9b63-4c12-96a6-3e95e496ae10" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 15, 19, 17, 43, DateTimeKind.Local).AddTicks(1025));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 15, 19, 17, 43, DateTimeKind.Local).AddTicks(1032));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 15, 19, 17, 44, DateTimeKind.Local).AddTicks(1460));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 15, 19, 17, 44, DateTimeKind.Local).AddTicks(1463));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 15, 19, 17, 44, DateTimeKind.Local).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 15, 19, 17, 44, DateTimeKind.Local).AddTicks(1048));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 15, 19, 17, 44, DateTimeKind.Local).AddTicks(1049));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 15, 19, 17, 44, DateTimeKind.Local).AddTicks(1229));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 15, 19, 17, 44, DateTimeKind.Local).AddTicks(1231));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 15, 19, 17, 44, DateTimeKind.Local).AddTicks(1231));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 15, 19, 17, 43, DateTimeKind.Local).AddTicks(3076));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 15, 19, 17, 43, DateTimeKind.Local).AddTicks(3093));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 15, 19, 17, 43, DateTimeKind.Local).AddTicks(3095));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 15, 19, 17, 43, DateTimeKind.Local).AddTicks(3097));
        }
    }
}
