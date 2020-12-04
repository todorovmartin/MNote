using Microsoft.EntityFrameworkCore.Migrations;

namespace MNote.Data.Migrations
{
    public partial class titleAddedToNotebooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "NoteBooks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "NoteBooks");
        }
    }
}
