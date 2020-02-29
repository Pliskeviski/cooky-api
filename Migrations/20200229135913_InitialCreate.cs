using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cooky.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Logitude = table.Column<double>(nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
