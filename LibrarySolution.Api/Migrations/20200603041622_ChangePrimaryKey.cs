using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySolution.Api.Migrations
{
    public partial class ChangePrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_books",
                table: "books");

            migrationBuilder.AlterColumn<string>(
                name: "Isbn",
                table: "books",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(13) CHARACTER SET utf8mb4",
                oldMaxLength: 13);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "books",
                maxLength: 13,
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_books",
                table: "books",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_books",
                table: "books");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "books");

            migrationBuilder.AlterColumn<string>(
                name: "Isbn",
                table: "books",
                type: "varchar(13) CHARACTER SET utf8mb4",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_books",
                table: "books",
                column: "Isbn");
        }
    }
}
