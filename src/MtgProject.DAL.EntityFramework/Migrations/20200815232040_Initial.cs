using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.EntityFramework.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    TurnCount = table.Column<int>(nullable: false),
                    StartingHp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    RolesString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeckEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeckEntity_UserEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameParticipationEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    GameId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    DeckId = table.Column<Guid>(nullable: false),
                    IsWinner = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameParticipationEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameParticipationEntity_DeckEntity_DeckId",
                        column: x => x.DeckId,
                        principalTable: "DeckEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameParticipationEntity_GameEntity_GameId",
                        column: x => x.GameId,
                        principalTable: "GameEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameParticipationEntity_UserEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatsEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    DamageDealt = table.Column<int>(nullable: false),
                    DamageReceived = table.Column<int>(nullable: false),
                    Kills = table.Column<int>(nullable: false),
                    GameParticipationEntityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatsEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatsEntity_GameParticipationEntity_GameParticipationEntityId",
                        column: x => x.GameParticipationEntityId,
                        principalTable: "GameParticipationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "GameEntity",
                columns: new[] { "Id", "Created", "Deleted", "Modified", "StartingHp", "TurnCount" },
                values: new object[,]
                {
                    { new Guid("fbef72ad-12d2-4436-9854-7dffd6416fdc"), new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 40, 11 },
                    { new Guid("d4b640a5-70b2-4d1d-8b43-f6a16d4b957a"), new DateTime(2019, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 40, 8 }
                });

            migrationBuilder.InsertData(
                table: "UserEntity",
                columns: new[] { "Id", "Created", "Deleted", "Modified", "Name", "PasswordHash", "RolesString" },
                values: new object[,]
                {
                    { new Guid("abcb66ba-e6c0-4145-b793-09429b969a78"), new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "René", "", "User" },
                    { new Guid("6f3e6f0b-e245-4d8b-a685-9141b8efbc79"), new DateTime(2018, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Rudolf", "", "User" }
                });

            migrationBuilder.InsertData(
                table: "DeckEntity",
                columns: new[] { "Id", "Created", "Deleted", "Modified", "Name", "UserId" },
                values: new object[] { new Guid("ada578f0-50b1-4bf4-834e-d50a5d4201e5"), new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "René Deck 1", new Guid("abcb66ba-e6c0-4145-b793-09429b969a78") });

            migrationBuilder.InsertData(
                table: "DeckEntity",
                columns: new[] { "Id", "Created", "Deleted", "Modified", "Name", "UserId" },
                values: new object[] { new Guid("07c3c09b-3bd1-4b27-9453-fc6e356e075c"), new DateTime(2019, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "René Deck 2", new Guid("abcb66ba-e6c0-4145-b793-09429b969a78") });

            migrationBuilder.InsertData(
                table: "DeckEntity",
                columns: new[] { "Id", "Created", "Deleted", "Modified", "Name", "UserId" },
                values: new object[] { new Guid("fc43bac5-0203-456e-8cbe-35223f895a5a"), new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Rudolf Deck 1", new Guid("6f3e6f0b-e245-4d8b-a685-9141b8efbc79") });

            migrationBuilder.InsertData(
                table: "GameParticipationEntity",
                columns: new[] { "Id", "Created", "DeckId", "Deleted", "GameId", "IsWinner", "Modified", "UserId" },
                values: new object[,]
                {
                    { new Guid("39b5af36-1363-4b21-b428-ffa149608fec"), new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ada578f0-50b1-4bf4-834e-d50a5d4201e5"), null, new Guid("fbef72ad-12d2-4436-9854-7dffd6416fdc"), false, null, new Guid("abcb66ba-e6c0-4145-b793-09429b969a78") },
                    { new Guid("ebfe6d78-8d09-4194-a0ae-4989170052a2"), new DateTime(2019, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("07c3c09b-3bd1-4b27-9453-fc6e356e075c"), null, new Guid("d4b640a5-70b2-4d1d-8b43-f6a16d4b957a"), true, null, new Guid("abcb66ba-e6c0-4145-b793-09429b969a78") },
                    { new Guid("c2f6a555-1085-4193-83da-df84cfbef4be"), new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc43bac5-0203-456e-8cbe-35223f895a5a"), null, new Guid("fbef72ad-12d2-4436-9854-7dffd6416fdc"), true, null, new Guid("6f3e6f0b-e245-4d8b-a685-9141b8efbc79") },
                    { new Guid("05a6410d-3d20-4f40-8159-89710eff8409"), new DateTime(2019, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc43bac5-0203-456e-8cbe-35223f895a5a"), null, new Guid("d4b640a5-70b2-4d1d-8b43-f6a16d4b957a"), false, null, new Guid("6f3e6f0b-e245-4d8b-a685-9141b8efbc79") }
                });

            migrationBuilder.InsertData(
                table: "StatsEntity",
                columns: new[] { "Id", "Created", "DamageDealt", "DamageReceived", "Deleted", "GameParticipationEntityId", "Kills", "Modified" },
                values: new object[,]
                {
                    { new Guid("17562946-6929-4e18-8bdb-cfc7095ab8e0"), new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 49, null, new Guid("39b5af36-1363-4b21-b428-ffa149608fec"), 0, null },
                    { new Guid("1d146ed3-10b8-4fe4-bd40-669bc203d073"), new DateTime(2019, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 11, null, new Guid("ebfe6d78-8d09-4194-a0ae-4989170052a2"), 1, null },
                    { new Guid("dde328da-8901-4422-8bae-51191fe1d346"), new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 22, null, new Guid("c2f6a555-1085-4193-83da-df84cfbef4be"), 1, null },
                    { new Guid("6194b58a-aa87-4c07-87c5-d7b7eb3a1dd9"), new DateTime(2019, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 88, null, new Guid("05a6410d-3d20-4f40-8159-89710eff8409"), 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeckEntity_UserId",
                table: "DeckEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameParticipationEntity_DeckId",
                table: "GameParticipationEntity",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_GameParticipationEntity_GameId",
                table: "GameParticipationEntity",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameParticipationEntity_UserId",
                table: "GameParticipationEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StatsEntity_GameParticipationEntityId",
                table: "StatsEntity",
                column: "GameParticipationEntityId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatsEntity");

            migrationBuilder.DropTable(
                name: "GameParticipationEntity");

            migrationBuilder.DropTable(
                name: "DeckEntity");

            migrationBuilder.DropTable(
                name: "GameEntity");

            migrationBuilder.DropTable(
                name: "UserEntity");
        }
    }
}
