using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameInactiveToDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Inactive",
                table: "ProductSizes",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "Inactive",
                table: "Products",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "Inactive",
                table: "Orders",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "Inactive",
                table: "OrderItems",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "Inactive",
                table: "Addresses",
                newName: "Deleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "ProductSizes",
                newName: "Inactive");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Products",
                newName: "Inactive");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Orders",
                newName: "Inactive");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "OrderItems",
                newName: "Inactive");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Addresses",
                newName: "Inactive");
        }
    }
}
