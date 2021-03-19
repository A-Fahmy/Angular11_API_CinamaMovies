using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularToAPI.Migrations
{
    public partial class UpdateFieldRolePermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "componentKindCode",
                table: "RolePermissions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "componentKindCode",
                table: "RolePermissions");
        }
    }
}
