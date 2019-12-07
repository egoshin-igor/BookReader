using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReader.Api.Migrations
{
    public partial class addBookFileParams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Book",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Book",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Book");
        }
    }
}
