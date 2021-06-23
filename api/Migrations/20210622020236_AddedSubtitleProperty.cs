using Microsoft.EntityFrameworkCore.Migrations;

namespace blog.API.Migrations
{
    public partial class AddedSubtitleProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subtitle",
                table: "Posts",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subtitle",
                table: "Posts");
        }
    }
}
