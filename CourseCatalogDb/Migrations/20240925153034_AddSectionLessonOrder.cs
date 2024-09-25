using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseCatalogDb.Migrations
{
    /// <inheritdoc />
    public partial class AddSectionLessonOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sections_CourseId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_SectionId",
                table: "Lessons");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CourseId_Order",
                table: "Sections",
                columns: new[] { "CourseId", "Order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_SectionId_Order",
                table: "Lessons",
                columns: new[] { "SectionId", "Order" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sections_CourseId_Order",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_SectionId_Order",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Lessons");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CourseId",
                table: "Sections",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_SectionId",
                table: "Lessons",
                column: "SectionId");
        }
    }
}
