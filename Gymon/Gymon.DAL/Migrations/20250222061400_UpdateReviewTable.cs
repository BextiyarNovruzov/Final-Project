using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymon.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReviewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Reviews",
                newName: "Comment");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Review_Rating",
                table: "Reviews",
                sql: "[Rating] BETWEEN 1 AND 5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Review_Rating",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Reviews",
                newName: "Content");
        }
    }
}
