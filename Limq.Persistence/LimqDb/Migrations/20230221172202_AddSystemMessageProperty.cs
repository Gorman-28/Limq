using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Limq.Persistence.LimqDb.Migrations;

/// <inheritdoc />
public partial class AddSystemMessageProperty : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<bool>(
            name: "SystemMessage",
            table: "MessagesSquad",
            type: "bit",
            nullable: false,
            defaultValue: false);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "SystemMessage",
            table: "MessagesSquad");
    }
}
