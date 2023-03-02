using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Limq.Persistence.LimqDb.Migrations;

/// <inheritdoc />
public partial class ChangeMessagesTimeDataType : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<DateTime>(
            name: "MessageTime",
            table: "MessagesSquad",
            type: "datetime2",
            nullable: false,
            oldClrType: typeof(DateTimeOffset),
            oldType: "datetimeoffset");

        migrationBuilder.AlterColumn<DateTime>(
            name: "MessageTime",
            table: "MessagesChat",
            type: "datetime2",
            nullable: false,
            oldClrType: typeof(DateTimeOffset),
            oldType: "datetimeoffset");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "MessageTime",
            table: "MessagesSquad",
            type: "datetimeoffset",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime2");

        migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "MessageTime",
            table: "MessagesChat",
            type: "datetimeoffset",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime2");
    }
}
