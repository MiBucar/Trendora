using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WardrobeList_ItemTypeModelDTO_ItemTypeId",
                table: "WardrobeList");

            migrationBuilder.RenameColumn(
                name: "ItemTypeId",
                table: "WardrobeList",
                newName: "ItemTypeModelId");

            migrationBuilder.RenameIndex(
                name: "IX_WardrobeList_ItemTypeId",
                table: "WardrobeList",
                newName: "IX_WardrobeList_ItemTypeModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_WardrobeList_ItemTypeModelDTO_ItemTypeModelId",
                table: "WardrobeList",
                column: "ItemTypeModelId",
                principalTable: "ItemTypeModelDTO",
                principalColumn: "ItemTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WardrobeList_ItemTypeModelDTO_ItemTypeModelId",
                table: "WardrobeList");

            migrationBuilder.RenameColumn(
                name: "ItemTypeModelId",
                table: "WardrobeList",
                newName: "ItemTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_WardrobeList_ItemTypeModelId",
                table: "WardrobeList",
                newName: "IX_WardrobeList_ItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WardrobeList_ItemTypeModelDTO_ItemTypeId",
                table: "WardrobeList",
                column: "ItemTypeId",
                principalTable: "ItemTypeModelDTO",
                principalColumn: "ItemTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
