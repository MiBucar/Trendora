using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class AddBoysAndGirlsToKids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GenderList",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Boys");

            migrationBuilder.InsertData(
                table: "GenderList",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Girls" });

            migrationBuilder.InsertData(
                table: "CollectionGender",
                columns: new[] { "CollectionsCollectionId", "GendersId" },
                values: new object[,]
                {
                    { 3, 4 },
                    { 4, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CollectionGender",
                keyColumns: new[] { "CollectionsCollectionId", "GendersId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "CollectionGender",
                keyColumns: new[] { "CollectionsCollectionId", "GendersId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "GenderList",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "GenderList",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Kids");
        }
    }
}
