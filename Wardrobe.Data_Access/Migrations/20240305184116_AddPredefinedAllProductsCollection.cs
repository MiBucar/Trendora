using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class AddPredefinedAllProductsCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CollectionList",
                columns: new[] { "CollectionId", "Name" },
                values: new object[] { 4, "All Products" });

            migrationBuilder.InsertData(
                table: "CollectionGender",
                columns: new[] { "CollectionsCollectionId", "GendersId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CollectionGender",
                keyColumns: new[] { "CollectionsCollectionId", "GendersId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "CollectionGender",
                keyColumns: new[] { "CollectionsCollectionId", "GendersId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "CollectionGender",
                keyColumns: new[] { "CollectionsCollectionId", "GendersId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "CollectionList",
                keyColumn: "CollectionId",
                keyValue: 4);
        }
    }
}
