using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WardrobeList_ItemTypeModelDTO_ItemTypeModelId",
                table: "WardrobeList");

            migrationBuilder.DropTable(
                name: "ItemTypeModelDTO");

            migrationBuilder.AddForeignKey(
                name: "FK_WardrobeList_ItemTypeList_ItemTypeModelId",
                table: "WardrobeList",
                column: "ItemTypeModelId",
                principalTable: "ItemTypeList",
                principalColumn: "ItemTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WardrobeList_ItemTypeList_ItemTypeModelId",
                table: "WardrobeList");

            migrationBuilder.CreateTable(
                name: "ItemTypeModelDTO",
                columns: table => new
                {
                    ItemTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypeModelDTO", x => x.ItemTypeId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WardrobeList_ItemTypeModelDTO_ItemTypeModelId",
                table: "WardrobeList",
                column: "ItemTypeModelId",
                principalTable: "ItemTypeModelDTO",
                principalColumn: "ItemTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
