using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class AddCollectionToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdGuid",
                table: "ProductList");

            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "TagList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CollectionList",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genders = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionList", x => x.CollectionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagList_CollectionId",
                table: "TagList",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagList_CollectionList_CollectionId",
                table: "TagList",
                column: "CollectionId",
                principalTable: "CollectionList",
                principalColumn: "CollectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagList_CollectionList_CollectionId",
                table: "TagList");

            migrationBuilder.DropTable(
                name: "CollectionList");

            migrationBuilder.DropIndex(
                name: "IX_TagList_CollectionId",
                table: "TagList");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "TagList");

            migrationBuilder.AddColumn<Guid>(
                name: "IdGuid",
                table: "ProductList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
