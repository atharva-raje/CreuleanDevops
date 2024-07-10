using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class changestodelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_WorkItems_WorkItemId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkitemLinks_WorkItems_SourceWorkItemId",
                table: "WorkitemLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkitemLinks_WorkItems_TargetWorkItemId",
                table: "WorkitemLinks");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_WorkItems_WorkItemId",
                table: "Comments",
                column: "WorkItemId",
                principalTable: "WorkItems",
                principalColumn: "WorkItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkitemLinks_WorkItems_SourceWorkItemId",
                table: "WorkitemLinks",
                column: "SourceWorkItemId",
                principalTable: "WorkItems",
                principalColumn: "WorkItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkitemLinks_WorkItems_TargetWorkItemId",
                table: "WorkitemLinks",
                column: "TargetWorkItemId",
                principalTable: "WorkItems",
                principalColumn: "WorkItemId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_WorkItems_WorkItemId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkitemLinks_WorkItems_SourceWorkItemId",
                table: "WorkitemLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkitemLinks_WorkItems_TargetWorkItemId",
                table: "WorkitemLinks");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_WorkItems_WorkItemId",
                table: "Comments",
                column: "WorkItemId",
                principalTable: "WorkItems",
                principalColumn: "WorkItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkitemLinks_WorkItems_SourceWorkItemId",
                table: "WorkitemLinks",
                column: "SourceWorkItemId",
                principalTable: "WorkItems",
                principalColumn: "WorkItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkitemLinks_WorkItems_TargetWorkItemId",
                table: "WorkitemLinks",
                column: "TargetWorkItemId",
                principalTable: "WorkItems",
                principalColumn: "WorkItemId");
        }
    }
}
