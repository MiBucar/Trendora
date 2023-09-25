using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class newMigration11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SizeList_ItemTypeList_ItemTypeModelItemTypeId",
                table: "SizeList");

            migrationBuilder.DropIndex(
                name: "IX_SizeList_ItemTypeModelItemTypeId",
                table: "SizeList");

            migrationBuilder.DropColumn(
                name: "ItemTypeModelItemTypeId",
                table: "SizeList");

            migrationBuilder.AddColumn<int>(
                name: "ItemTypeModelId",
                table: "SizeList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SizeList_ItemTypeModelId",
                table: "SizeList",
                column: "ItemTypeModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_SizeList_ItemTypeList_ItemTypeModelId",
                table: "SizeList",
                column: "ItemTypeModelId",
                principalTable: "ItemTypeList",
                principalColumn: "ItemTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SizeList_ItemTypeList_ItemTypeModelId",
                table: "SizeList");

            migrationBuilder.DropIndex(
                name: "IX_SizeList_ItemTypeModelId",
                table: "SizeList");

            migrationBuilder.DropColumn(
                name: "ItemTypeModelId",
                table: "SizeList");

            migrationBuilder.AddColumn<int>(
                name: "ItemTypeModelItemTypeId",
                table: "SizeList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SizeList_ItemTypeModelItemTypeId",
                table: "SizeList",
                column: "ItemTypeModelItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SizeList_ItemTypeList_ItemTypeModelItemTypeId",
                table: "SizeList",
                column: "ItemTypeModelItemTypeId",
                principalTable: "ItemTypeList",
                principalColumn: "ItemTypeId");
        }
    }
}
