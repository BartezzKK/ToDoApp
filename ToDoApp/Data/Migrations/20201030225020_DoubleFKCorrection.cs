using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApp.Data.Migrations
{
    public partial class DoubleFKCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_ToDoItemGroups_ToDoItemGroupId1",
                table: "ToDoItems");

            migrationBuilder.DropIndex(
                name: "IX_ToDoItems_ToDoItemGroupId1",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "ToDoItemGroupId1",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "ToDoItemGroupId2",
                table: "ToDoItems");

            migrationBuilder.RenameColumn(
                name: "isDone",
                table: "ToDoItems",
                newName: "IsDone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDone",
                table: "ToDoItems",
                newName: "isDone");

            migrationBuilder.AddColumn<int>(
                name: "ToDoItemGroupId1",
                table: "ToDoItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToDoItemGroupId2",
                table: "ToDoItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_ToDoItemGroupId1",
                table: "ToDoItems",
                column: "ToDoItemGroupId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_ToDoItemGroups_ToDoItemGroupId1",
                table: "ToDoItems",
                column: "ToDoItemGroupId1",
                principalTable: "ToDoItemGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
