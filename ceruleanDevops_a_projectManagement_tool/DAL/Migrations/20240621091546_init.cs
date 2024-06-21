using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkItemId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_WorkItemId",
                table: "Comments",
                column: "WorkItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_WorkItems_WorkItemId",
                table: "Comments",
                column: "WorkItemId",
                principalTable: "WorkItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_WorkItems_WorkItemId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_WorkItemId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "WorkItemId",
                table: "Comments");
        }
    }
}
