using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class sdds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_CategoryProducts_CategoryProductid",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Product_Productid",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInfo_Product_Productid",
                table: "ProductInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_SubProducts_Product_Productid",
                table: "SubProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryProductid",
                table: "Products",
                newName: "IX_Products_CategoryProductid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_Productid",
                table: "ProductImages",
                column: "Productid",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInfo_Products_Productid",
                table: "ProductInfo",
                column: "Productid",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CategoryProducts_CategoryProductid",
                table: "Products",
                column: "CategoryProductid",
                principalTable: "CategoryProducts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubProducts_Products_Productid",
                table: "SubProducts",
                column: "Productid",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_Productid",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInfo_Products_Productid",
                table: "ProductInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_CategoryProducts_CategoryProductid",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SubProducts_Products_Productid",
                table: "SubProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryProductid",
                table: "Product",
                newName: "IX_Product_CategoryProductid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_CategoryProducts_CategoryProductid",
                table: "Product",
                column: "CategoryProductid",
                principalTable: "CategoryProducts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Product_Productid",
                table: "ProductImages",
                column: "Productid",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInfo_Product_Productid",
                table: "ProductInfo",
                column: "Productid",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubProducts_Product_Productid",
                table: "SubProducts",
                column: "Productid",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
