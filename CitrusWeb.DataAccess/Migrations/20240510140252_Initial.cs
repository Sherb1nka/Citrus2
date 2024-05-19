using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitrusWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Presentation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Presentation_Video_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Video",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PresentationSheet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PresentationId = table.Column<int>(type: "int", nullable: true),
                    ImgUrl = table.Column<string>(type: "varchar", nullable: true),
                    HtmlText = table.Column<string>(type: "varchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentationSheet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresentationSheet_Presentation_PresentationId",
                        column: x => x.PresentationId,
                        principalTable: "Presentation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresentationSheet");
            
            migrationBuilder.DropTable(
                name: "Presentation");
            
            migrationBuilder.DropTable(
                name: "Video");
        }
    }
}
