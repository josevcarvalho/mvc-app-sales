using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcAppSales.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnSeller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDay",
                table: "Seller",
                newName: "BirthDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Seller",
                newName: "BirthDay");
        }
    }
}
