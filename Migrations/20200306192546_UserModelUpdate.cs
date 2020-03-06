using Microsoft.EntityFrameworkCore.Migrations;

namespace Cooky.API.Migrations
{
    public partial class UserModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logitude",
                table: "Users");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Users",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Users",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Users");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Users",
                type: "float",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<double>(
                name: "Logitude",
                table: "Users",
                type: "float",
                nullable: true);
        }
    }
}
