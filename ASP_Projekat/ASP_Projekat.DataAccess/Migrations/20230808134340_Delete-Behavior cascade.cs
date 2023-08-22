using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_Projekat.DataAccess.Migrations
{
    public partial class DeleteBehaviorcascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogImages_Blogs_BlogId",
                table: "BlogImages");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogReactions_Blogs_BlogId",
                table: "BlogReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogTags_Blogs_BlogId",
                table: "BlogTags");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Users",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Tags",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Roles",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Reactions",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "LogEntries",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Images",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Comments",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Blogs",
                newName: "IsActive");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Tags",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Reactions",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "LogEntries",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Blogs",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogImages_Blogs_BlogId",
                table: "BlogImages",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogReactions_Blogs_BlogId",
                table: "BlogReactions",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTags_Blogs_BlogId",
                table: "BlogTags",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogId",
                table: "Comments",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogImages_Blogs_BlogId",
                table: "BlogImages");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogReactions_Blogs_BlogId",
                table: "BlogReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogTags_Blogs_BlogId",
                table: "BlogTags");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Users",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Tags",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Roles",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Reactions",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "LogEntries",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Images",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Comments",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Blogs",
                newName: "isActive");

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "Tags",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "Roles",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "Reactions",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "LogEntries",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "Images",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "Comments",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "Blogs",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogImages_Blogs_BlogId",
                table: "BlogImages",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogReactions_Blogs_BlogId",
                table: "BlogReactions",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTags_Blogs_BlogId",
                table: "BlogTags",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogId",
                table: "Comments",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
