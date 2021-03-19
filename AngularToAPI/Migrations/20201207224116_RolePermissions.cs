using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularToAPI.Migrations
{
    public partial class RolePermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    RoleName = table.Column<string>(nullable: true),
                    componentId = table.Column<int>(nullable: false),
                    componentName = table.Column<string>(nullable: true),
                    InsertYN = table.Column<bool>(nullable: false),
                    UpdateYN = table.Column<bool>(nullable: false),
                    DeleteYN = table.Column<bool>(nullable: false),
                    ViewYN = table.Column<bool>(nullable: false),
                    PrintYN = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermissions");
        }
    }
}
