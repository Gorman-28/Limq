using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Limq.Persistence.LimqDb.Migrations;

/// <inheritdoc />
public partial class InitialMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Chats",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                FirstUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                SecondUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Chats", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "MessagesChat",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                UserFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                UserToId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                MessageTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MessagesChat", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "MessagesSquad",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                SquadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                UserFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                MessageTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MessagesSquad", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Squads",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Avatar = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Squads", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                UserName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                Password = table.Column<string>(type: "nvarchar(20)", nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                LastName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                Avatar = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                Status = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "UserChatsBlocked",
            columns: table => new
            {
                FirstUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                SecondUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserChatsBlocked", x => new { x.FirstUser, x.SecondUser });
                table.ForeignKey(
                    name: "FK_UserChatsBlocked_Users_FirstUser",
                    column: x => x.FirstUser,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.NoAction);
                table.ForeignKey(
                    name: "FK_UserChatsBlocked_Users_SecondUser",
                    column: x => x.SecondUser,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.NoAction);
            });

        migrationBuilder.CreateTable(
            name: "UserSquads",
            columns: table => new
            {
                UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                SquadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserSquads", x => new { x.UserId, x.SquadId });
                table.ForeignKey(
                    name: "FK_UserSquads_Squads_SquadId",
                    column: x => x.SquadId,
                    principalTable: "Squads",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.NoAction);
                table.ForeignKey(
                    name: "FK_UserSquads_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.NoAction);
            });

        migrationBuilder.CreateTable(
            name: "UserSquadsBlocked",
            columns: table => new
            {
                UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                SquadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserSquadsBlocked", x => new { x.UserId, x.SquadId });
                table.ForeignKey(
                    name: "FK_UserSquadsBlocked_Squads_SquadId",
                    column: x => x.SquadId,
                    principalTable: "Squads",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.NoAction);
                table.ForeignKey(
                    name: "FK_UserSquadsBlocked_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.NoAction);
            });

        migrationBuilder.CreateIndex(
            name: "IX_UserChatsBlocked_SecondUser",
            table: "UserChatsBlocked",
            column: "SecondUser");

        migrationBuilder.CreateIndex(
            name: "IX_UserSquads_SquadId",
            table: "UserSquads",
            column: "SquadId");

        migrationBuilder.CreateIndex(
            name: "IX_UserSquadsBlocked_SquadId",
            table: "UserSquadsBlocked",
            column: "SquadId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Chats");

        migrationBuilder.DropTable(
            name: "MessagesChat");

        migrationBuilder.DropTable(
            name: "MessagesSquad");

        migrationBuilder.DropTable(
            name: "UserChatsBlocked");

        migrationBuilder.DropTable(
            name: "UserSquads");

        migrationBuilder.DropTable(
            name: "UserSquadsBlocked");

        migrationBuilder.DropTable(
            name: "Squads");

        migrationBuilder.DropTable(
            name: "Users");
    }
}
