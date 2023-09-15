using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class NewModelMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "WardrobeList");

            migrationBuilder.AddColumn<int>(
                name: "ItemTypeId",
                table: "WardrobeList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ItemTypeModelDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypeModelDTO", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WardrobeList_ItemTypeId",
                table: "WardrobeList",
                column: "ItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WardrobeList_ItemTypeModelDTO_ItemTypeId",
                table: "WardrobeList",
                column: "ItemTypeId",
                principalTable: "ItemTypeModelDTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WardrobeList_ItemTypeModelDTO_ItemTypeId",
                table: "WardrobeList");

            migrationBuilder.DropTable(
                name: "ItemTypeModelDTO");

            migrationBuilder.DropIndex(
                name: "IX_WardrobeList_ItemTypeId",
                table: "WardrobeList");

            migrationBuilder.DropColumn(
                name: "ItemTypeId",
                table: "WardrobeList");

            migrationBuilder.AddColumn<string>(
                name: "ItemType",
                table: "WardrobeList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
