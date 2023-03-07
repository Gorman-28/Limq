using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Limq.Persistence.LimqDb.Migrations;

/// <inheritdoc />
public partial class AddThemeColumn : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<bool>(
            name: "Theme",
            table: "Users",
            type: "bit",
            nullable: false,
            defaultValue: false);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Theme",
            table: "Users");
    }
}
