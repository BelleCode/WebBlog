using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBlog.Data.Migrations
{
    public partial class deploy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "AspNetUsers",
                newName: "ImageData");

            migrationBuilder.AddColumn<string>(
                name: "ImageType",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageType",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ImageData",
                table: "AspNetUsers",
                newName: "Image");
        }
    }
}