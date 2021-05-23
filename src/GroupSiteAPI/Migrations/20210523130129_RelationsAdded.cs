using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupSiteAPI.Migrations
{
    public partial class RelationsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ScheduleItems_SubjectId",
                table: "ScheduleItems",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleItems_Subjects_SubjectId",
                table: "ScheduleItems",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleItems_Subjects_SubjectId",
                table: "ScheduleItems");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleItems_SubjectId",
                table: "ScheduleItems");
        }
    }
}
