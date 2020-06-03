using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySolution.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Isbn = table.Column<string>(nullable: false),
                    BookTitle = table.Column<string>(nullable: true),
                    BookDescription = table.Column<string>(nullable: true),
                    DateOfPublication = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Isbn);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");
        }
    }
}
