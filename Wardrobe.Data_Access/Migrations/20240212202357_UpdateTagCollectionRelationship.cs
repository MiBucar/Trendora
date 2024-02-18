using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTagCollectionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagList_CollectionList_CollectionId",
                table: "TagList");

            migrationBuilder.DropIndex(
                name: "IX_TagList_CollectionId",
                table: "TagList");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "TagList");

            migrationBuilder.CreateTable(
                name: "CollectionTag",
                columns: table => new
                {
                    CollectionsCollectionId = table.Column<int>(type: "int", nullable: false),
                    TagsTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionTag", x => new { x.CollectionsCollectionId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_CollectionTag_CollectionList_CollectionsCollectionId",
                        column: x => x.CollectionsCollectionId,
                        principalTable: "CollectionList",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionTag_TagList_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "TagList",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionTag_TagsTagId",
                table: "CollectionTag",
                column: "TagsTagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionTag");

            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "TagList",
                type: "int",
                nullable: true);

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
    }
}
