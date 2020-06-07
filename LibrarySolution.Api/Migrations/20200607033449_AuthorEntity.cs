using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySolution.Api.Migrations
{
    public partial class AuthorEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Isbn",
                table: "books",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(13) CHARACTER SET utf8mb4",
                oldMaxLength: 13,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AuthorName = table.Column<string>(nullable: true),
                    BriefDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.AlterColumn<string>(
                name: "Isbn",
                table: "books",
                type: "varchar(13) CHARACTER SET utf8mb4",
                maxLength: 13,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
