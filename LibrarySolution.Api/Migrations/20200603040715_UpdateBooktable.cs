using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySolution.Api.Migrations
{
    public partial class UpdateBooktable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Isbn",
                table: "books",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1) CHARACTER SET utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Isbn",
                table: "books",
                type: "varchar(1) CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 13);
        }
    }
}
