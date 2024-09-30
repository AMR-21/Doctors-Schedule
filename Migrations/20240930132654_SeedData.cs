using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DoctorsSchedule.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Days",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sunday" },
                    { 2, "Monday" },
                    { 3, "Tuesday" },
                    { 4, "Wednesday" },
                    { 5, "Thursday" },
                    { 6, "Friday" },
                    { 7, "Saturday" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mohamed" },
                    { 2, "Ahmed" }
                });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Id", "DayId", "DocId", "End", "Start" },
                values: new object[,]
                {
                    { 1, 2, 1, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 2, 2, 1, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 2, 0, 0, 0) },
                    { 3, 3, 1, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 4, 3, 1, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 2, 0, 0, 0) },
                    { 5, 3, 1, new TimeSpan(0, 21, 0, 0, 0), new TimeSpan(0, 20, 0, 0, 0) },
                    { 6, 4, 1, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 7, 4, 1, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 2, 0, 0, 0) },
                    { 8, 5, 1, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 2, 0, 0, 0) },
                    { 9, 6, 1, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 10, 2, 2, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 11, 3, 2, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 12, 3, 2, new TimeSpan(0, 21, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 13, 5, 2, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 2, 0, 0, 0) },
                    { 14, 6, 2, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
