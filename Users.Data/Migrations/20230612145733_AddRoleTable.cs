using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Users.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "roles_id",
                table: "users",
                type: "character varying(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("roles_pkey", x => x.name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_roles_id",
                table: "users",
                column: "roles_id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_roles_id",
                table: "users",
                column: "roles_id",
                principalTable: "roles",
                principalColumn: "name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_roles_id",
                table: "users");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropIndex(
                name: "IX_users_email",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_roles_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "roles_id",
                table: "users");
        }
    }
}
