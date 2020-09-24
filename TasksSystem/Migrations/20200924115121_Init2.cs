using Microsoft.EntityFrameworkCore.Migrations;

namespace TasksSystem.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Task",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Task",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Task",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
