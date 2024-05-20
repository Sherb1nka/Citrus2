using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitrusWeb.Api.Migrations
{
    /// <inheritdoc />
    public partial class TimeCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeCodeHours",
                table: "PresentationSheets",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeCodeMinutes",
                table: "PresentationSheets",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeCodeSeconds",
                table: "PresentationSheets",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeCodeHours",
                table: "PresentationSheets");

            migrationBuilder.DropColumn(
                name: "TimeCodeMinutes",
                table: "PresentationSheets");

            migrationBuilder.DropColumn(
                name: "TimeCodeSeconds",
                table: "PresentationSheets");
        }
    }
}
