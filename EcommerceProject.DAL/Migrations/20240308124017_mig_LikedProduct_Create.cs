using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig_LikedProduct_Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LikedProducts",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    AppUserID = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_LikedProducts", x => new { x.ProductID, x.AppUserID });
                    table.ForeignKey(
                        name: "FK_LikedProducts_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikedProducts_Products_ProductID",
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
                values: new object[] { "b4018e3a-e16e-414d-a9ad-f86ab9d0c43e", new DateTime(2024, 3, 8, 15, 40, 16, 901, DateTimeKind.Local).AddTicks(8002), "AQAAAAIAAYagAAAAEK7DXd3DmC2WNtiIM84cRW+OIxgUlMdoClw5jfvfmmk8I/7jUecSUW5qejzQwiysWA==", "2aefb7fa-54a2-48e1-a539-87bbf1bedc54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d043082-08e9-41d0-8548-7a33b1d5fb63", new DateTime(2024, 3, 8, 15, 40, 16, 955, DateTimeKind.Local).AddTicks(9822), "AQAAAAIAAYagAAAAEHnymVSSIXVJZre8y5q5Ykj9s+xkGV8trWfTrfWSowfsfMju2KMnNwE/KSjfQiuGWw==", "62ba1d77-96f2-495e-abb2-fa72ed6471e4" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 8, 15, 40, 17, 10, DateTimeKind.Local).AddTicks(5965));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 8, 15, 40, 17, 10, DateTimeKind.Local).AddTicks(5979));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 8, 15, 40, 17, 11, DateTimeKind.Local).AddTicks(5146));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 8, 15, 40, 17, 11, DateTimeKind.Local).AddTicks(5149));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 8, 15, 40, 17, 11, DateTimeKind.Local).AddTicks(4727));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 8, 15, 40, 17, 11, DateTimeKind.Local).AddTicks(4733));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 8, 15, 40, 17, 11, DateTimeKind.Local).AddTicks(4733));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 8, 15, 40, 17, 11, DateTimeKind.Local).AddTicks(4941));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 8, 15, 40, 17, 11, DateTimeKind.Local).AddTicks(4943));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 8, 15, 40, 17, 11, DateTimeKind.Local).AddTicks(4944));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 8, 15, 40, 17, 10, DateTimeKind.Local).AddTicks(8482));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 8, 15, 40, 17, 10, DateTimeKind.Local).AddTicks(8495));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 8, 15, 40, 17, 10, DateTimeKind.Local).AddTicks(8499));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 8, 15, 40, 17, 10, DateTimeKind.Local).AddTicks(8501));

            migrationBuilder.CreateIndex(
                name: "IX_LikedProducts_AppUserID",
                table: "LikedProducts",
                column: "AppUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikedProducts");

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
    }
}
