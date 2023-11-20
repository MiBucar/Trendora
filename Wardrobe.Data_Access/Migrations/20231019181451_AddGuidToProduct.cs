using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class AddGuidToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorProduct_ProductList_ProductsWardrobeModelId",
                table: "ColorProduct");

            migrationBuilder.RenameColumn(
                name: "WardrobeModelId",
                table: "ProductList",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductsWardrobeModelId",
                table: "ColorProduct",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_ColorProduct_ProductsWardrobeModelId",
                table: "ColorProduct",
                newName: "IX_ColorProduct_ProductsId");

            migrationBuilder.AddColumn<Guid>(
                name: "IdGuid",
                table: "ProductList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_ColorProduct_ProductList_ProductsId",
                table: "ColorProduct",
                column: "ProductsId",
                principalTable: "ProductList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorProduct_ProductList_ProductsId",
                table: "ColorProduct");

            migrationBuilder.DropColumn(
                name: "IdGuid",
                table: "ProductList");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductList",
                newName: "WardrobeModelId");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "ColorProduct",
                newName: "ProductsWardrobeModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ColorProduct_ProductsId",
                table: "ColorProduct",
                newName: "IX_ColorProduct_ProductsWardrobeModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ColorProduct_ProductList_ProductsWardrobeModelId",
                table: "ColorProduct",
                column: "ProductsWardrobeModelId",
                principalTable: "ProductList",
                principalColumn: "WardrobeModelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
