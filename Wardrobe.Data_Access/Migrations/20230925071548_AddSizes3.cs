using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class AddSizes3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypeModelSize_ItemTypeList_ItemTypesItemTypeId",
                table: "ItemTypeModelSize");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypeModelSize_SizeList_SizesId",
                table: "ItemTypeModelSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemTypeModelSize",
                table: "ItemTypeModelSize");

            migrationBuilder.RenameTable(
                name: "ItemTypeModelSize",
                newName: "ItemTypeSize");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTypeModelSize_SizesId",
                table: "ItemTypeSize",
                newName: "IX_ItemTypeSize_SizesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemTypeSize",
                table: "ItemTypeSize",
                columns: new[] { "ItemTypesItemTypeId", "SizesId" });

            migrationBuilder.InsertData(
                table: "SizeList",
                columns: new[] { "Id", "IsChecked", "ItemSize" },
                values: new object[,]
                {
                    { 1, false, "S" },
                    { 2, false, "M" },
                    { 3, false, "L" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypeSize_ItemTypeList_ItemTypesItemTypeId",
                table: "ItemTypeSize",
                column: "ItemTypesItemTypeId",
                principalTable: "ItemTypeList",
                principalColumn: "ItemTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypeSize_SizeList_SizesId",
                table: "ItemTypeSize",
                column: "SizesId",
                principalTable: "SizeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypeSize_ItemTypeList_ItemTypesItemTypeId",
                table: "ItemTypeSize");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypeSize_SizeList_SizesId",
                table: "ItemTypeSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemTypeSize",
                table: "ItemTypeSize");

            migrationBuilder.DeleteData(
                table: "SizeList",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SizeList",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SizeList",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "ItemTypeSize",
                newName: "ItemTypeModelSize");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTypeSize_SizesId",
                table: "ItemTypeModelSize",
                newName: "IX_ItemTypeModelSize_SizesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemTypeModelSize",
                table: "ItemTypeModelSize",
                columns: new[] { "ItemTypesItemTypeId", "SizesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypeModelSize_ItemTypeList_ItemTypesItemTypeId",
                table: "ItemTypeModelSize",
                column: "ItemTypesItemTypeId",
                principalTable: "ItemTypeList",
                principalColumn: "ItemTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypeModelSize_SizeList_SizesId",
                table: "ItemTypeModelSize",
                column: "SizesId",
                principalTable: "SizeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
