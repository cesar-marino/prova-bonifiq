using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProvaPub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "RandomNumbers",
                columns: table => new
                {
                    RandomNumberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandomNumbers", x => x.RandomNumberId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(28,2)", precision: 28, scale: 2, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Name" },
                values: new object[,]
                {
                    { new Guid("0db09350-9a3c-40c1-bcfa-603acec7b65d"), "Customer 9" },
                    { new Guid("1040c9f9-7f56-4c5d-90ac-d3b69bee8a15"), "Customer 20" },
                    { new Guid("15e0454b-8378-4423-9374-947d7c1a0cb1"), "Customer 11" },
                    { new Guid("43749f94-bb6a-4219-b491-d9076b8f44d9"), "Customer 18" },
                    { new Guid("588d58ad-7648-4cc5-897b-3be539d2a068"), "Customer 17" },
                    { new Guid("5bd20719-ebc8-44ac-8890-adacfdd00c0b"), "Customer 12" },
                    { new Guid("65415a69-67dd-42fa-b46e-000a5761c09e"), "Customer 19" },
                    { new Guid("6aa0b12c-a645-4a91-8468-e865dfa3fd3e"), "Customer 3" },
                    { new Guid("6c52d19b-6070-401e-9a42-a0f188972e36"), "Customer 8" },
                    { new Guid("6ec8a7f9-2987-432f-b2a3-b56ff491a11d"), "Customer 5" },
                    { new Guid("70afbd9a-bb53-4950-9225-be467c81f081"), "Customer 10" },
                    { new Guid("747cb2c4-284a-4b0b-b112-5240948c8f35"), "Customer 1" },
                    { new Guid("d056c7ca-2cbe-42f0-84ee-f0b9e314ba03"), "Customer 2" },
                    { new Guid("d12a7211-4580-4e25-b8b2-be08232c9afc"), "Customer 4" },
                    { new Guid("d65859b1-61c1-4096-8a48-b4aa1c95bccc"), "Customer 14" },
                    { new Guid("dc0c6034-8351-41ca-bdf8-37931f78993d"), "Customer 6" },
                    { new Guid("dc533d52-a956-411a-9ac8-490963d8793f"), "Customer 7" },
                    { new Guid("e304e618-855e-434f-a65d-9939f0788988"), "Customer 16" },
                    { new Guid("f1c3f2f8-1100-47f2-863a-dd9922e87f81"), "Customer 13" },
                    { new Guid("f5b5bf67-8156-482f-8877-1f248572a55d"), "Customer 15" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name" },
                values: new object[,]
                {
                    { new Guid("080711bd-8395-4004-b79f-5fcbc9f9c06a"), "Product 14" },
                    { new Guid("0d7e9aa8-50d7-4966-adb0-3553175a7d24"), "Product 4" },
                    { new Guid("109d9239-a22b-4aa0-82d6-f6227c54c9a4"), "Product 15" },
                    { new Guid("215cf962-f89d-4f88-ad4a-62b5313707d8"), "Product 2" },
                    { new Guid("22474301-3380-4936-87f2-b5a1b1e3413b"), "Product 11" },
                    { new Guid("3b480b89-17d9-412c-a057-d47792aa742a"), "Product 12" },
                    { new Guid("5f86effc-a076-446d-abfc-b4bb9852fc34"), "Product 18" },
                    { new Guid("60297082-67d5-48d3-b6dd-5ccf4d1b7bc8"), "Product 20" },
                    { new Guid("6a385b22-5af2-4184-98e6-64bc45aef7a3"), "Product 19" },
                    { new Guid("6ef8ffb6-72dc-4a1f-85d0-e7b9238865ac"), "Product 7" },
                    { new Guid("8053622f-2ac1-47de-af76-a1817500f54b"), "Product 8" },
                    { new Guid("80ef4535-eeb4-41e0-9323-6ace9757b828"), "Product 3" },
                    { new Guid("b8b52983-9643-41d9-99d0-b5a739187274"), "Product 13" },
                    { new Guid("b9cbf743-f5e8-47a5-b23d-51b311b0bf87"), "Product 1" },
                    { new Guid("bb80b4d3-cfaf-4974-ba23-cfa636659171"), "Product 5" },
                    { new Guid("bea89c8e-1904-4b3b-96c5-726e75dc84a1"), "Product 6" },
                    { new Guid("c1bfbc67-3988-4c21-899a-74fb4f6bd96d"), "Product 10" },
                    { new Guid("ea03c9e0-4ac2-4b72-a0fb-7a554fab784d"), "Product 16" },
                    { new Guid("eeec841c-e3b5-48dc-9607-d8ec85a76639"), "Product 9" },
                    { new Guid("f03aad02-3b57-4e39-9fb6-ff31a17beb0e"), "Product 17" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RandomNumbers_Number",
                table: "RandomNumbers",
                column: "Number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RandomNumbers");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
