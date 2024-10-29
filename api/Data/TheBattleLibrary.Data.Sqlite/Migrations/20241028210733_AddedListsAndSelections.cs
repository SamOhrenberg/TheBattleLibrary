
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBattleLibrary.Data.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class AddedListsAndSelections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BattleLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Faction = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Selections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ParentListId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ParentSelectionId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Selections_BattleLists_ParentListId",
                        column: x => x.ParentListId,
                        principalTable: "BattleLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Selections_Selections_ParentSelectionId",
                        column: x => x.ParentSelectionId,
                        principalTable: "Selections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Selections_ParentListId",
                table: "Selections",
                column: "ParentListId");

            migrationBuilder.CreateIndex(
                name: "IX_Selections_ParentSelectionId",
                table: "Selections",
                column: "ParentSelectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Selections");

            migrationBuilder.DropTable(
                name: "BattleLists");
        }
    }
}
