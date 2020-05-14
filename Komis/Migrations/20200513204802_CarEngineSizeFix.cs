using Microsoft.EntityFrameworkCore.Migrations;

namespace Komis.Migrations
{
    public partial class CarEngineSizeFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "EngineSize",
                table: "Cars",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngineSize",
                table: "Cars");
        }
    }
}
