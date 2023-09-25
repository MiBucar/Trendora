using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class ItemTypeModelAndSizeCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTypeModelSizeModel");

            migrationBuilder.RenameColumn(
                name: "IsChecked",
                table: "SizeList",
                newName: "IsAvailable");

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

            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "SizeList",
                newName: "IsChecked");

            migrationBuilder.CreateTable(
                name: "ItemTypeModelSizeModel",
                columns: table => new
                {
                    ItemTypesItemTypeId = table.Column<int>(type: "int", nullable: false),
                    SizesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypeModelSizeModel", x => new { x.ItemTypesItemTypeId, x.SizesId });
                    table.ForeignKey(
                        name: "FK_ItemTypeModelSizeModel_ItemTypeList_ItemTypesItemTypeId",
                        column: x => x.ItemTypesItemTypeId,
                        principalTable: "ItemTypeList",
                        principalColumn: "ItemTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTypeModelSizeModel_SizeList_SizesId",
                        column: x => x.SizesId,
                        principalTable: "SizeList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypeModelSizeModel_SizesId",
                table: "ItemTypeModelSizeModel",
                column: "SizesId");
        }
    }
}
