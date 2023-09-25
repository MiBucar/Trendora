using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class AddNewMigration09 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTypeModelSize");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTypeModelSizeModel");

            migrationBuilder.CreateTable(
                name: "ItemTypeModelSize",
                columns: table => new
                {
                    ItemTypesItemTypeId = table.Column<int>(type: "int", nullable: false),
                    SizesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypeModelSize", x => new { x.ItemTypesItemTypeId, x.SizesId });
                    table.ForeignKey(
                        name: "FK_ItemTypeModelSize_ItemTypeList_ItemTypesItemTypeId",
                        column: x => x.ItemTypesItemTypeId,
                        principalTable: "ItemTypeList",
                        principalColumn: "ItemTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTypeModelSize_SizeList_SizesId",
                        column: x => x.SizesId,
                        principalTable: "SizeList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypeModelSize_SizesId",
                table: "ItemTypeModelSize",
                column: "SizesId");
        }
    }
}
