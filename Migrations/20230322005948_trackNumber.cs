using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvancedDatabaseAndORMAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class trackNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrackNumber",
                table: "Song",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrackNumber",
                table: "Song");
        }
    }
}
