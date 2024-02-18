using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class MakeChangesOnProductAndItemType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductList_ItemTypeList_ItemTypeModelId",
                table: "ProductList");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "ProductList");

            migrationBuilder.DropColumn(
                name: "IsAccessory",
                table: "ItemTypeList");

            migrationBuilder.DropColumn(
                name: "IsClothing",
                table: "ItemTypeList");

            migrationBuilder.DropColumn(
                name: "IsShoes",
                table: "ItemTypeList");

            migrationBuilder.RenameColumn(
                name: "ItemTypeModelId",
                table: "ProductList",
                newName: "GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductList_ItemTypeModelId",
                table: "ProductList",
                newName: "IX_ProductList_GenderId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProductList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductList_CategoryId",
                table: "ProductList",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductList_GenderList_GenderId",
                table: "ProductList",
                column: "GenderId",
                principalTable: "GenderList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductList_ItemTypeList_CategoryId",
                table: "ProductList",
                column: "CategoryId",
                principalTable: "ItemTypeList",
                principalColumn: "ItemTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductList_GenderList_GenderId",
                table: "ProductList");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductList_ItemTypeList_CategoryId",
                table: "ProductList");

            migrationBuilder.DropIndex(
                name: "IX_ProductList_CategoryId",
                table: "ProductList");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductList");

            migrationBuilder.RenameColumn(
                name: "GenderId",
                table: "ProductList",
                newName: "ItemTypeModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductList_GenderId",
                table: "ProductList",
                newName: "IX_ProductList_ItemTypeModelId");

            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "ProductList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAccessory",
                table: "ItemTypeList",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsClothing",
                table: "ItemTypeList",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShoes",
                table: "ItemTypeList",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductList_ItemTypeList_ItemTypeModelId",
                table: "ProductList",
                column: "ItemTypeModelId",
                principalTable: "ItemTypeList",
                principalColumn: "ItemTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
