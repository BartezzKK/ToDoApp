using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApp.Data.Migrations
{
    public partial class test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItemGroups_AspNetUsers_UserId1",
                table: "ToDoItemGroups");

            migrationBuilder.DropIndex(
                name: "IX_ToDoItemGroups_UserId1",
                table: "ToDoItemGroups");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ToDoItemGroups");

            migrationBuilder.DropColumn(
                name: "isDone",
                table: "ToDoItemGroups");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ToDoItems",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "isDone",
                table: "ToDoItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ToDoItemGroups",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_UserId",
                table: "ToDoItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItemGroups_UserId",
                table: "ToDoItemGroups",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItemGroups_AspNetUsers_UserId",
                table: "ToDoItemGroups",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_AspNetUsers_UserId",
                table: "ToDoItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItemGroups_AspNetUsers_UserId",
                table: "ToDoItemGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_AspNetUsers_UserId",
                table: "ToDoItems");

            migrationBuilder.DropIndex(
                name: "IX_ToDoItems_UserId",
                table: "ToDoItems");

            migrationBuilder.DropIndex(
                name: "IX_ToDoItemGroups_UserId",
                table: "ToDoItemGroups");

            migrationBuilder.DropColumn(
                name: "isDone",
                table: "ToDoItems");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ToDoItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ToDoItemGroups",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ToDoItemGroups",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDone",
                table: "ToDoItemGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItemGroups_UserId1",
                table: "ToDoItemGroups",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItemGroups_AspNetUsers_UserId1",
                table: "ToDoItemGroups",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
