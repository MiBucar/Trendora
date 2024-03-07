using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class AddPredefinedAllProductsCollection2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CollectionTag",
                columns: new[] { "CollectionsCollectionId", "TagsTagId" },
                values: new object[] { 4, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CollectionTag",
                keyColumns: new[] { "CollectionsCollectionId", "TagsTagId" },
                keyValues: new object[] { 4, 1 });
        }
    }
}
