using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTagProductRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagList_ProductList_ProductId",
                table: "TagList");

            migrationBuilder.DropIndex(
                name: "IX_TagList_ProductId",
                table: "TagList");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "TagList");

            migrationBuilder.CreateTable(
                name: "ProductTag",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    TagsTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTag", x => new { x.ProductsId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_ProductTag_ProductList_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "ProductList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTag_TagList_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "TagList",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTag_TagsTagId",
                table: "ProductTag",
                column: "TagsTagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTag");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "TagList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TagList_ProductId",
                table: "TagList",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagList_ProductList_ProductId",
                table: "TagList",
                column: "ProductId",
                principalTable: "ProductList",
                principalColumn: "Id");
        }
    }
}
