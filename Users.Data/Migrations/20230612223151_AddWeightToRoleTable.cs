using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Users.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddWeightToRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "weight",
                table: "roles",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "weight",
                table: "roles");
        }
    }
}
