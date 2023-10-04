using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorProduct_WardrobeList_ProductsWardrobeModelId",
                table: "ColorProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_WardrobeList_ItemTypeList_ItemTypeModelId",
                table: "WardrobeList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WardrobeList",
                table: "WardrobeList");

            migrationBuilder.RenameTable(
                name: "WardrobeList",
                newName: "ProductList");

            migrationBuilder.RenameIndex(
                name: "IX_WardrobeList_ItemTypeModelId",
                table: "ProductList",
                newName: "IX_ProductList_ItemTypeModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductList",
                table: "ProductList",
                column: "WardrobeModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ColorProduct_ProductList_ProductsWardrobeModelId",
                table: "ColorProduct",
                column: "ProductsWardrobeModelId",
                principalTable: "ProductList",
                principalColumn: "WardrobeModelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductList_ItemTypeList_ItemTypeModelId",
                table: "ProductList",
                column: "ItemTypeModelId",
                principalTable: "ItemTypeList",
                principalColumn: "ItemTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorProduct_ProductList_ProductsWardrobeModelId",
                table: "ColorProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductList_ItemTypeList_ItemTypeModelId",
                table: "ProductList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductList",
                table: "ProductList");

            migrationBuilder.RenameTable(
                name: "ProductList",
                newName: "WardrobeList");

            migrationBuilder.RenameIndex(
                name: "IX_ProductList_ItemTypeModelId",
                table: "WardrobeList",
                newName: "IX_WardrobeList_ItemTypeModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WardrobeList",
                table: "WardrobeList",
                column: "WardrobeModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ColorProduct_WardrobeList_ProductsWardrobeModelId",
                table: "ColorProduct",
                column: "ProductsWardrobeModelId",
                principalTable: "WardrobeList",
                principalColumn: "WardrobeModelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WardrobeList_ItemTypeList_ItemTypeModelId",
                table: "WardrobeList",
                column: "ItemTypeModelId",
                principalTable: "ItemTypeList",
                principalColumn: "ItemTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
