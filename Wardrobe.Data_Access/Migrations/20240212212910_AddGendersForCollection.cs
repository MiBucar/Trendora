using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class AddGendersForCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genders",
                table: "CollectionList");

            migrationBuilder.CreateTable(
                name: "GenderList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectionGender",
                columns: table => new
                {
                    CollectionsCollectionId = table.Column<int>(type: "int", nullable: false),
                    GendersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionGender", x => new { x.CollectionsCollectionId, x.GendersId });
                    table.ForeignKey(
                        name: "FK_CollectionGender_CollectionList_CollectionsCollectionId",
                        column: x => x.CollectionsCollectionId,
                        principalTable: "CollectionList",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionGender_GenderList_GendersId",
                        column: x => x.GendersId,
                        principalTable: "GenderList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CollectionList",
                columns: new[] { "CollectionId", "Name" },
                values: new object[,]
                {
                    { 1, "Women" },
                    { 2, "Men" },
                    { 3, "Kids" }
                });

            migrationBuilder.InsertData(
                table: "GenderList",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Women" },
                    { 2, "Men" },
                    { 3, "Kids" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionGender_GendersId",
                table: "CollectionGender",
                column: "GendersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionGender");

            migrationBuilder.DropTable(
                name: "GenderList");

            migrationBuilder.DeleteData(
                table: "CollectionList",
                keyColumn: "CollectionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CollectionList",
                keyColumn: "CollectionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CollectionList",
                keyColumn: "CollectionId",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "Genders",
                table: "CollectionList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
