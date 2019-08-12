using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class InsertTestValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "order_vs_product",
                keyColumn: "id",
                keyValue: new Guid("811ae373-1408-483f-ac3e-babcbb1dcaaf"));

            migrationBuilder.InsertData(
                table: "order_vs_product",
                columns: new[] { "id", "OrderEntityId", "OrderId", "ProductEntityId", "ProductId" },
                values: new object[] { new Guid("66397d65-2191-43bd-8f13-283e4c10ffae"), null, 1, null, 1 });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 1,
                column: "created",
                value: new DateTimeOffset(new DateTime(2019, 7, 10, 13, 14, 14, 100, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "id", "created", "status" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2019, 9, 19, 19, 19, 19, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), 0 });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "name", "price", "quantity" },
                values: new object[,]
                {
                    { 2, "TestProduct2", 122.0, 10 },
                    { 3, "TestProduct3", 10.0, 1000 }
                });

            migrationBuilder.InsertData(
                table: "order_vs_product",
                columns: new[] { "id", "OrderEntityId", "OrderId", "ProductEntityId", "ProductId" },
                values: new object[,]
                {
                    { new Guid("86b7ace5-eb64-4b56-89a9-4e3195d32a65"), null, 1, null, 2 },
                    { new Guid("7ca86171-3837-4a2d-a0a2-9856cd456495"), null, 2, null, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "order_vs_product",
                keyColumn: "id",
                keyValue: new Guid("66397d65-2191-43bd-8f13-283e4c10ffae"));

            migrationBuilder.DeleteData(
                table: "order_vs_product",
                keyColumn: "id",
                keyValue: new Guid("7ca86171-3837-4a2d-a0a2-9856cd456495"));

            migrationBuilder.DeleteData(
                table: "order_vs_product",
                keyColumn: "id",
                keyValue: new Guid("86b7ace5-eb64-4b56-89a9-4e3195d32a65"));

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "order_vs_product",
                columns: new[] { "id", "OrderEntityId", "OrderId", "ProductEntityId", "ProductId" },
                values: new object[] { new Guid("811ae373-1408-483f-ac3e-babcbb1dcaaf"), 1, 1, 1, 1 });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 1,
                column: "created",
                value: new DateTimeOffset(new DateTime(2019, 8, 11, 23, 31, 24, 691, DateTimeKind.Unspecified).AddTicks(2503), new TimeSpan(0, 3, 0, 0, 0)));
        }
    }
}
