﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBattleLibrary.Data.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class RemovedSalt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Users",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
