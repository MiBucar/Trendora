using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class ChangeModelToNameInCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductList_ItemTypeList_CategoryId",
                table: "ProductList");

            migrationBuilder.DropForeignKey(
                name: "FK_SizeList_ItemTypeList_ItemTypeModelId",
                table: "SizeList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemTypeList",
                table: "ItemTypeList");

            migrationBuilder.RenameTable(
                name: "ItemTypeList",
                newName: "CategoryList");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "CategoryList",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryList",
                table: "CategoryList",
                column: "ItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductList_CategoryList_CategoryId",
                table: "ProductList",
                column: "CategoryId",
                principalTable: "CategoryList",
                principalColumn: "ItemTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SizeList_CategoryList_ItemTypeModelId",
                table: "SizeList",
                column: "ItemTypeModelId",
                principalTable: "CategoryList",
                principalColumn: "ItemTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductList_CategoryList_CategoryId",
                table: "ProductList");

            migrationBuilder.DropForeignKey(
                name: "FK_SizeList_CategoryList_ItemTypeModelId",
                table: "SizeList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryList",
                table: "CategoryList");

            migrationBuilder.RenameTable(
                name: "CategoryList",
                newName: "ItemTypeList");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ItemTypeList",
                newName: "Model");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemTypeList",
                table: "ItemTypeList",
                column: "ItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductList_ItemTypeList_CategoryId",
                table: "ProductList",
                column: "CategoryId",
                principalTable: "ItemTypeList",
                principalColumn: "ItemTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SizeList_ItemTypeList_ItemTypeModelId",
                table: "SizeList",
                column: "ItemTypeModelId",
                principalTable: "ItemTypeList",
                principalColumn: "ItemTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
