using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBlog.Data.Migrations
{
    public partial class TagsModelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_AspNetUsers_BlogUserId1",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_BlogUserId1",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "BlogUserId1",
                table: "Tags");

            migrationBuilder.AlterColumn<string>(
                name: "BlogUserId",
                table: "Tags",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_BlogUserId",
                table: "Tags",
                column: "BlogUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_AspNetUsers_BlogUserId",
                table: "Tags",
                column: "BlogUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_AspNetUsers_BlogUserId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_BlogUserId",
                table: "Tags");

            migrationBuilder.AlterColumn<int>(
                name: "BlogUserId",
                table: "Tags",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlogUserId1",
                table: "Tags",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_BlogUserId1",
                table: "Tags",
                column: "BlogUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_AspNetUsers_BlogUserId1",
                table: "Tags",
                column: "BlogUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
