using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PRN02.Migrations
{
    public partial class seedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    DateIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b013f0-5201-4317-abd8-c211f91b7330",
                column: "ConcurrencyStamp",
                value: "3e30cc51-f928-4779-9f9e-7729bd76382c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711",
                column: "ConcurrencyStamp",
                value: "2faa90b0-8f9f-48cf-a267-2fe10bfb41e1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "174f7ccd-71a6-4caf-8afe-a7ed2971a88e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afec8296-e797-4f57-aa4f-a7865480441f", "AQAAAAEAACcQAAAAEBuKcNm/g5KxecTQSgz3ccCBTcrn7444BgsXVLCeSpD7SZTSQzAA5ZgZ2/esrKShIA==", "b8f3950b-5d81-4a70-b80d-aaae9d245f68" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb793cea-84bf-423d-87f6-6fe0880b09c2", "AQAAAAEAACcQAAAAEH4Crq3eYGTlB9D2viHkTs453CxDQcZlxxMwf+ZICGc+Ncgy/eWqkTdc4pBrZef4yQ==", "1d78b907-5875-4533-be75-874ca68d9b29" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Coffee" },
                    { 2, "Beer" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "DateIn", "ProductName", "Quantity", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 6, 29, 9, 59, 0, 502, DateTimeKind.Local).AddTicks(8200), "Trung Nguyen", 10, 2000.0 },
                    { 2, 1, new DateTime(2021, 6, 29, 9, 59, 0, 504, DateTimeKind.Local).AddTicks(7695), "Thanh Dat", 12, 1800.0 },
                    { 3, 2, new DateTime(2021, 6, 29, 9, 59, 0, 504, DateTimeKind.Local).AddTicks(7722), "Tiger", 50, 6200.0 },
                    { 4, 2, new DateTime(2021, 6, 29, 9, 59, 0, 504, DateTimeKind.Local).AddTicks(7724), "Heineken", 50, 7000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b013f0-5201-4317-abd8-c211f91b7330",
                column: "ConcurrencyStamp",
                value: "90880438-e17b-4771-a7be-2f923baf1d7e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711",
                column: "ConcurrencyStamp",
                value: "240443c5-6cf0-44af-8fce-9ddd4016c1c7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "174f7ccd-71a6-4caf-8afe-a7ed2971a88e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11881956-8d62-49be-9d79-3456d0971c9e", "AQAAAAEAACcQAAAAEHgO/4pNyAz89wcfW6sw1rQP1cyLUR0ZL7fLUa3cjvnySnoMF+6VjdblH9g49Ia9tA==", "56af5990-e2b9-47eb-9816-f14cbed38b9e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01af8b2e-50b1-43df-b82a-7b7f41f08c28", "AQAAAAEAACcQAAAAEFrt2rahr/twUNfghF42IYYGylQyF6a9IXjn/0REONVyX7ReVrMWiHAcDTtWv3bd7w==", "47e5f34d-808d-4b52-96f6-602e5c1de4e6" });
        }
    }
}
