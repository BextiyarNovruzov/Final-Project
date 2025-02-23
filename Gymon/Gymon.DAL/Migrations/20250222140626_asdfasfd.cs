using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymon.DAL.Migrations
{
    /// <inheritdoc />
    public partial class asdfasfd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Reviews",
                newName: "ReviewerName");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ReviewerName",
                table: "Reviews",
                newName: "UserName");
        }
    }
}
