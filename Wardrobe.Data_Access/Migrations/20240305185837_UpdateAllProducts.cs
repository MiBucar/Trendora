using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAllProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CollectionList",
                keyColumn: "CollectionId",
                keyValue: 4,
                column: "Name",
                value: "AllProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CollectionList",
                keyColumn: "CollectionId",
                keyValue: 4,
                column: "Name",
                value: "All Products");
        }
    }
}
