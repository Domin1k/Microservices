namespace PetFoodShop.Foods.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class InitFoods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shippments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueNumber = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: false),
                    ShippmentDate = table.Column<DateTime>(nullable: false),
                    ExpectedDeliveryDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodBrands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    FoodCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodBrands_FoodCategories_FoodCategoryId",
                        column: x => x.FoodCategoryId,
                        principalTable: "FoodCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 1500, nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    FoodBrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_FoodBrands_FoodBrandId",
                        column: x => x.FoodBrandId,
                        principalTable: "FoodBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodBrands_FoodCategoryId",
                table: "FoodBrands",
                column: "FoodCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodBrandId",
                table: "Foods",
                column: "FoodBrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Shippments");

            migrationBuilder.DropTable(
                name: "FoodBrands");

            migrationBuilder.DropTable(
                name: "FoodCategories");
        }
    }
}
