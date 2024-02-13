using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class migimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_ProductID",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ProductID",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "SortImage",
                table: "Images");

            migrationBuilder.CreateTable(
                name: "ImageDetails",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ImageID = table.Column<int>(type: "int", nullable: false),
                    SortImage = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageDetails", x => new { x.ProductID, x.ImageID });
                    table.ForeignKey(
                        name: "FK_ImageDetails_Images_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Images",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ImageDetails_ImageID",
                table: "ImageDetails",
                column: "ImageID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageDetails");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SortImage",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09337116-5629-493c-b071-dcd19a3cb171", new DateTime(2024, 2, 13, 2, 5, 3, 302, DateTimeKind.Local).AddTicks(5096), "AQAAAAIAAYagAAAAEHwTROw+dxg5PcDJaqXBZDFvGgezWs9VhuYPi+i0xIm0CKa7OMK0AwzHsZd9f/6cAA==", "be34d2c7-5259-4651-89d6-0f0b6873f148" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40a07574-1600-4f54-8a34-566554e9658f", new DateTime(2024, 2, 13, 2, 5, 3, 356, DateTimeKind.Local).AddTicks(7169), "AQAAAAIAAYagAAAAEHOwmk1SxAGjsk5tLYszcmRthNLffBTKRCaDgPLXlgn6CNiu0uP6almZTG0f3lAQjA==", "938aa1b7-1d70-4936-ae9e-3cf192d92dd8" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 2, 5, 3, 410, DateTimeKind.Local).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 2, 5, 3, 410, DateTimeKind.Local).AddTicks(6428));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 2, 5, 3, 411, DateTimeKind.Local).AddTicks(1533));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 2, 5, 3, 411, DateTimeKind.Local).AddTicks(1535));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 2, 5, 3, 411, DateTimeKind.Local).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 2, 5, 3, 411, DateTimeKind.Local).AddTicks(1200));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 2, 5, 3, 411, DateTimeKind.Local).AddTicks(1201));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 2, 5, 3, 411, DateTimeKind.Local).AddTicks(1365));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 2, 5, 3, 411, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 2, 5, 3, 411, DateTimeKind.Local).AddTicks(1371));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 2, 5, 3, 410, DateTimeKind.Local).AddTicks(7418));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 2, 5, 3, 410, DateTimeKind.Local).AddTicks(7431));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 2, 5, 3, 410, DateTimeKind.Local).AddTicks(7434));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 2, 5, 3, 410, DateTimeKind.Local).AddTicks(7436));

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductID",
                table: "Images",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_ProductID",
                table: "Images",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
