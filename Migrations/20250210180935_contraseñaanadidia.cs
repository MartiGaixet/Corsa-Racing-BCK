using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorsaRacing.Migrations
{
    /// <inheritdoc />
    public partial class contraseñaanadidia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "Drivers",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Drivers");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Drivers",
                newName: "email");
        }
    }
}
