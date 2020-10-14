using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApp.Data.Migrations
{
    public partial class First_Models_Creating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoItemGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    isDone = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItemGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoItemGroups_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ToDoItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ToDoItemGroupId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ToDoItemGroupId1 = table.Column<int>(nullable: true),
                    ToDoItemGroupId2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoItems_ToDoItemGroups_ToDoItemGroupId",
                        column: x => x.ToDoItemGroupId,
                        principalTable: "ToDoItemGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDoItems_ToDoItemGroups_ToDoItemGroupId1",
                        column: x => x.ToDoItemGroupId1,
                        principalTable: "ToDoItemGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItemGroups_UserId1",
                table: "ToDoItemGroups",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_ToDoItemGroupId",
                table: "ToDoItems",
                column: "ToDoItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_ToDoItemGroupId1",
                table: "ToDoItems",
                column: "ToDoItemGroupId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoItems");

            migrationBuilder.DropTable(
                name: "ToDoItemGroups");
        }
    }
}
