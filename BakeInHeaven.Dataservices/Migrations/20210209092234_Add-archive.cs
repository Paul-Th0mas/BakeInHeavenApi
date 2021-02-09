using Microsoft.EntityFrameworkCore.Migrations;

namespace Dataservices.Migrations
{
    public partial class Addarchive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "archive",
                table: "Delicacys",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "archive",
                table: "Delicacys");
        }
    }
}
