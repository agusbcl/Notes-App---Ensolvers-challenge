using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ensolvers_Challenge.Backend.Data.Migrations
{
    public partial class Note_AddStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Notes");
        }
    }
}
