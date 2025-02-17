using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymon.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTrainerScheduleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "TrainerSchedule",
                newName: "IsBooked");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "TrainerSchedule",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "TrainerSchedule",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "AvailableDate",
                table: "TrainerSchedule",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableDate",
                table: "TrainerSchedule");

            migrationBuilder.RenameColumn(
                name: "IsBooked",
                table: "TrainerSchedule",
                newName: "IsAvailable");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "TrainerSchedule",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "TrainerSchedule",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }
    }
}
