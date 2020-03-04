using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Komis.Migrations
{
    public partial class KomisContextAndCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<int>(nullable: false),
                    YearOfProduction = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    FuelType = table.Column<string>(nullable: true),
                    Transmission = table.Column<string>(nullable: true),
                    BodyType = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    Photo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
