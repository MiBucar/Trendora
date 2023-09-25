using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class AddSizes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypeModelSize_Sizes_SizesId",
                table: "ItemTypeModelSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.RenameTable(
                name: "Sizes",
                newName: "SizeList");

            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "SizeList",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SizeList",
                table: "SizeList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypeModelSize_SizeList_SizesId",
                table: "ItemTypeModelSize",
                column: "SizesId",
                principalTable: "SizeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypeModelSize_SizeList_SizesId",
                table: "ItemTypeModelSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SizeList",
                table: "SizeList");

            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "SizeList");

            migrationBuilder.RenameTable(
                name: "SizeList",
                newName: "Sizes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypeModelSize_Sizes_SizesId",
                table: "ItemTypeModelSize",
                column: "SizesId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
