using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseCatalogDb.Migrations
{
    /// <inheritdoc />
    public partial class AddCreateUpdateTimestamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn_Utc",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedOn_Utc",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn_Utc",
                table: "UserLessons",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedOn_Utc",
                table: "UserLessons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn_Utc",
                table: "Sections",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedOn_Utc",
                table: "Sections",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn_Utc",
                table: "Lessons",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedOn_Utc",
                table: "Lessons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn_Utc",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedOn_Utc",
                table: "Courses",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn_Utc",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastUpdatedOn_Utc",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedOn_Utc",
                table: "UserLessons");

            migrationBuilder.DropColumn(
                name: "LastUpdatedOn_Utc",
                table: "UserLessons");

            migrationBuilder.DropColumn(
                name: "CreatedOn_Utc",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "LastUpdatedOn_Utc",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "CreatedOn_Utc",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "LastUpdatedOn_Utc",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "CreatedOn_Utc",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LastUpdatedOn_Utc",
                table: "Courses");
        }
    }
}
