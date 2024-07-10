using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class chaningworkitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_Users_UserId",
                table: "WorkItems");

            migrationBuilder.DropIndex(
                name: "IX_WorkItems_UserId",
                table: "WorkItems");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "WorkItems",
                newName: "StoryPoints");

            migrationBuilder.AddColumn<int>(
                name: "AssigneeId",
                table: "WorkItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReporterId",
                table: "WorkItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkItems_AssigneeId",
                table: "WorkItems",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItems_ReporterId",
                table: "WorkItems",
                column: "ReporterId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_Users_AssigneeId",
                table: "WorkItems",
                column: "AssigneeId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_Users_ReporterId",
                table: "WorkItems",
                column: "ReporterId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_Users_AssigneeId",
                table: "WorkItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_Users_ReporterId",
                table: "WorkItems");

            migrationBuilder.DropIndex(
                name: "IX_WorkItems_AssigneeId",
                table: "WorkItems");

            migrationBuilder.DropIndex(
                name: "IX_WorkItems_ReporterId",
                table: "WorkItems");

            migrationBuilder.DropColumn(
                name: "AssigneeId",
                table: "WorkItems");

            migrationBuilder.DropColumn(
                name: "ReporterId",
                table: "WorkItems");

            migrationBuilder.RenameColumn(
                name: "StoryPoints",
                table: "WorkItems",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItems_UserId",
                table: "WorkItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_Users_UserId",
                table: "WorkItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
