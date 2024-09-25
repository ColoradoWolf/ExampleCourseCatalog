using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseCatalogDb.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseDesc", "CourseName", "LastUpdatedOn_Utc" },
                values: new object[,]
                {
                    { 1, "This is Course #1", "Course #1", null },
                    { 2, "This is Course #2", "Course #2", null },
                    { 3, "This is Course #3", "Course #3", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "LastUpdatedOn_Utc", "ScreenName" },
                values: new object[,]
                {
                    { 1, "qwerty@some-email.org", null, "Qwerty McGee" },
                    { 2, "xyz@abc.net", null, "Joe Schmoe" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "SectionId", "CourseId", "LastUpdatedOn_Utc", "Order", "SectionDesc", "SectionName" },
                values: new object[,]
                {
                    { 1, 1, null, 1, "1st Section of Course #1", "Section #1" },
                    { 2, 1, null, 2, "2nd Section of Course #1", "Section #2" },
                    { 3, 2, null, 1, "1st Section of Course #2", "Section #3" },
                    { 4, 2, null, 2, "2nd Section of Course #2", "Section #4" },
                    { 5, 2, null, 3, "3rd Section of Course #2", "Section #5" },
                    { 6, 3, null, 1, "1st Section of Course #3", "Section #6" }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "LessonId", "LastUpdatedOn_Utc", "LessonDesc", "LessonName", "Order", "SectionId", "VideoLength", "VideoUrl" },
                values: new object[,]
                {
                    { 1, null, "1st Lesson of Section #1", "Lesson #1", 1, 1, new TimeSpan(0, 0, 30, 25, 0), "https://xyz.com/videos/lesson1.mp4" },
                    { 2, null, "1st Lesson of Section #2", "Lesson #2", 1, 2, new TimeSpan(0, 0, 15, 46, 0), "https://xyz.com/videos/lesson2.mp4" },
                    { 3, null, "1st Lesson of Section #3", "Lesson #3", 1, 3, new TimeSpan(0, 0, 45, 15, 0), "https://xyz.com/videos/lesson3.mp4" },
                    { 4, null, "1st Lesson of Section #4", "Lesson #4", 1, 4, new TimeSpan(0, 0, 20, 10, 0), "https://xyz.com/videos/lesson4.mp4" },
                    { 5, null, "1st Lesson of Section #5", "Lesson #5", 1, 5, new TimeSpan(0, 0, 18, 57, 0), "https://xyz.com/videos/lesson5.mp4" },
                    { 6, null, "1st Lesson of Section #6", "Lesson #6", 1, 6, new TimeSpan(0, 0, 10, 53, 0), "https://xyz.com/videos/lesson6.mp4" },
                    { 7, null, "2nd Lesson of Section #1", "Lesson #7", 2, 1, new TimeSpan(0, 0, 12, 33, 0), "https://xyz.com/videos/lesson7.mp4" },
                    { 8, null, "2nd Lesson of Section #2", "Lesson #8", 2, 2, new TimeSpan(0, 0, 16, 5, 0), "https://xyz.com/videos/lesson8.mp4" },
                    { 9, null, "2nd Lesson of Section #3", "Lesson #9", 2, 3, new TimeSpan(0, 0, 22, 9, 0), "https://xyz.com/videos/lesson9.mp4" },
                    { 10, null, "2nd Lesson of Section #4", "Lesson #10", 2, 4, new TimeSpan(0, 0, 21, 45, 0), "https://xyz.com/videos/lesson10.mp4" },
                    { 11, null, "2nd Lesson of Section #5", "Lesson #11", 2, 5, new TimeSpan(0, 0, 21, 22, 0), "https://xyz.com/videos/lesson11.mp4" },
                    { 12, null, "1st Lesson of Section #6", "Lesson #12", 2, 6, new TimeSpan(0, 0, 14, 28, 0), "https://xyz.com/videos/lesson12.mp4" },
                    { 13, null, "3rd Lesson of Section #6", "Lesson #13", 3, 6, new TimeSpan(0, 0, 16, 47, 0), "https://xyz.com/videos/lesson13.mp4" },
                    { 14, null, "3rd Lesson of Section #3", "Lesson #14", 3, 3, new TimeSpan(0, 0, 11, 9, 0), "https://xyz.com/videos/lesson14.mp4" },
                    { 15, null, "3rd Lesson of Section #2", "Lesson #15", 3, 2, new TimeSpan(0, 0, 19, 58, 0), "https://xyz.com/videos/lesson15.mp4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "LessonId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "SectionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "SectionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "SectionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "SectionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "SectionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "SectionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3);
        }
    }
}
