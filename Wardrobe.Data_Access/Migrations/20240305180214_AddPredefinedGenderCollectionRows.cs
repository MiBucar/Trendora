using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class AddPredefinedGenderCollectionRows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CollectionGender",
                columns: new[] { "CollectionsCollectionId", "GendersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CollectionGender",
                keyColumns: new[] { "CollectionsCollectionId", "GendersId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CollectionGender",
                keyColumns: new[] { "CollectionsCollectionId", "GendersId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CollectionGender",
                keyColumns: new[] { "CollectionsCollectionId", "GendersId" },
                keyValues: new object[] { 3, 3 });
        }
    }
}
