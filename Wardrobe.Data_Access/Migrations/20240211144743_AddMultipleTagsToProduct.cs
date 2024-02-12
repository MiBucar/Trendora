using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class AddMultipleTagsToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductList_TagList_TagId",
                table: "ProductList");

            migrationBuilder.DropIndex(
                name: "IX_ProductList_TagId",
                table: "ProductList");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "ProductList");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "ProductList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductList_TagId",
                table: "ProductList",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductList_TagList_TagId",
                table: "ProductList",
                column: "TagId",
                principalTable: "TagList",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
