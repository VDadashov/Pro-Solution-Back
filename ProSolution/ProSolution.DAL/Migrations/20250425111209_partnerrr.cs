using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolution.DAL.Migrations
{
    /// <inheritdoc />
    public partial class partnerrr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AltText",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Desctription",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltText",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "Desctription",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Partners");
        }
    }
}
