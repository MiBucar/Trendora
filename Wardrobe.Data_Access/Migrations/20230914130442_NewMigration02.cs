using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WardrobeList",
                newName: "WardrobeModelId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ItemTypeModelDTO",
                newName: "ItemTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ItemTypeList",
                newName: "ItemTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WardrobeModelId",
                table: "WardrobeList",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ItemTypeId",
                table: "ItemTypeModelDTO",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ItemTypeId",
                table: "ItemTypeList",
                newName: "Id");
        }
    }
}
