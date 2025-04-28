using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProSolution.DAL.Migrations
{
    /// <inheritdoc />
    public partial class blogreviewlast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Reviews",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                newName: "IX_Reviews_BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Blogs_BlogId",
                table: "Reviews",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Blogs_BlogId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "Reviews",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BlogId",
                table: "Reviews",
                newName: "IX_Reviews_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
