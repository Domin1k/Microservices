namespace PetFoodShop.Foods.Infrastructure.Common.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class FoodsRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodBrands_FoodCategories_Id",
                table: "FoodBrands");

            migrationBuilder.DropIndex(
                name: "IX_FoodBrands_Id",
                table: "FoodBrands");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Foods",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "FoodBrands",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodBrands_CategoryId",
                table: "FoodBrands",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodBrands_FoodCategories_CategoryId",
                table: "FoodBrands",
                column: "CategoryId",
                principalTable: "FoodCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodBrands_FoodCategories_CategoryId",
                table: "FoodBrands");

            migrationBuilder.DropIndex(
                name: "IX_FoodBrands_CategoryId",
                table: "FoodBrands");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "FoodBrands");

            migrationBuilder.CreateIndex(
                name: "IX_FoodBrands_Id",
                table: "FoodBrands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodBrands_FoodCategories_Id",
                table: "FoodBrands",
                column: "Id",
                principalTable: "FoodCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
