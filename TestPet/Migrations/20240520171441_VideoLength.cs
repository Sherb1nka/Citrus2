using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitrusWeb.Api.Migrations
{
    /// <inheritdoc />
    public partial class VideoLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Length",
                table: "Videos",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Length",
                table: "Videos");
        }
    }
}
