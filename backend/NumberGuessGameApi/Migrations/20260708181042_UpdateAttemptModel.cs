using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NumberGuessGameApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAttemptModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Attempts");

            migrationBuilder.AddColumn<int>(
                name: "Famas",
                table: "Attempts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Picas",
                table: "Attempts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Famas",
                table: "Attempts");

            migrationBuilder.DropColumn(
                name: "Picas",
                table: "Attempts");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Attempts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
