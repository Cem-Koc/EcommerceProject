using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig_commentTable_productCode_add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductCode",
                table: "ProductComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afa0c606-fd10-4b92-9246-c5ea89bd03b2", new DateTime(2024, 3, 14, 23, 48, 35, 597, DateTimeKind.Local).AddTicks(3014), "AQAAAAIAAYagAAAAEIJl93i5R+XM6MDb80n0sz/pkEV0JL5/RdmH1YukdUUmbHIpYZDJW7J1DpVwvB/rnw==", "e793b8bd-ea50-41ec-b901-54d6013f5b01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2418b5c6-a485-481b-859a-7de061166c50", new DateTime(2024, 3, 14, 23, 48, 35, 682, DateTimeKind.Local).AddTicks(3393), "AQAAAAIAAYagAAAAEPWsncYAE0wvH3l/2YfckdS2R2GK8TFNwlnEiinQGCesZO15QY6tpQ3SuLqTGQueJw==", "960d08a3-f1b0-45ff-a11e-5855d24fea16" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 48, 35, 768, DateTimeKind.Local).AddTicks(3486));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 48, 35, 768, DateTimeKind.Local).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 48, 35, 769, DateTimeKind.Local).AddTicks(8250));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 48, 35, 769, DateTimeKind.Local).AddTicks(8253));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 48, 35, 769, DateTimeKind.Local).AddTicks(7718));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 48, 35, 769, DateTimeKind.Local).AddTicks(7729));

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 48, 35, 769, DateTimeKind.Local).AddTicks(7730));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 48, 35, 769, DateTimeKind.Local).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 48, 35, 769, DateTimeKind.Local).AddTicks(7997));

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 48, 35, 769, DateTimeKind.Local).AddTicks(7999));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 48, 35, 768, DateTimeKind.Local).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 48, 35, 768, DateTimeKind.Local).AddTicks(7607));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 48, 35, 768, DateTimeKind.Local).AddTicks(7613));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 14, 23, 48, 35, 768, DateTimeKind.Local).AddTicks(7615));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "ProductComments");

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
        }
    }
}
