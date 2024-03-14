using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig_comment_create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductComments",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    AppUserID = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_ProductComments", x => new { x.ProductID, x.AppUserID });
                    table.ForeignKey(
                        name: "FK_ProductComments_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductComments_Products_ProductID",
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
                values: new object[] { "f2736cac-c482-4ad1-bffd-40dca5448b04", new DateTime(2024, 3, 14, 23, 29, 15, 709, DateTimeKind.Local).AddTicks(3477), "AQAAAAIAAYagAAAAEH1GnsdIzDMIXzlhNdNKSpAL8BQVZ1HqCYMB9PdhAfLBe2wI2KkxcFJhRodSYZk/bw==", "51a358c7-41a3-48c1-8423-1fb832b711d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "889e8760-46ad-4437-a49c-aefa2df62ce2", new DateTime(2024, 3, 14, 23, 29, 15, 775, DateTimeKind.Local).AddTicks(69), "AQAAAAIAAYagAAAAEO9WIfiUsQSoE+vyWME1quFY3p8h1LTK5J2I+TzKw6/k/hQtCQNCQRBKx0wZ7dcg1g==", "2b82c0ed-ddf7-441c-8139-1bfd05ad0de5" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 29, 15, 845, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 29, 15, 845, DateTimeKind.Local).AddTicks(4150));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 29, 15, 846, DateTimeKind.Local).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 29, 15, 846, DateTimeKind.Local).AddTicks(2619));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 29, 15, 846, DateTimeKind.Local).AddTicks(2222));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 29, 15, 846, DateTimeKind.Local).AddTicks(2228));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 29, 15, 846, DateTimeKind.Local).AddTicks(2229));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 29, 15, 846, DateTimeKind.Local).AddTicks(2425));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 29, 15, 846, DateTimeKind.Local).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 29, 15, 846, DateTimeKind.Local).AddTicks(2429));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 29, 15, 845, DateTimeKind.Local).AddTicks(6356));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 29, 15, 845, DateTimeKind.Local).AddTicks(6393));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 29, 15, 845, DateTimeKind.Local).AddTicks(6397));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 29, 15, 845, DateTimeKind.Local).AddTicks(6399));

            migrationBuilder.CreateIndex(
                name: "IX_ProductComments_AppUserID",
                table: "ProductComments",
                column: "AppUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductComments");

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
        }
    }
}
