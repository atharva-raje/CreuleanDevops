using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class changeworkitemnew4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Types",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Statuses",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Priorities",
                newName: "PriorityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Iterations",
                newName: "IterationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Types",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Statuses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PriorityId",
                table: "Priorities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IterationId",
                table: "Iterations",
                newName: "Id");
        }
    }
}
