using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace labnet.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 12, "Google" },
                    { 13, "Netflix" },
                    { 14, "Danone" }
                });

            migrationBuilder.InsertData(
                table: "JobOfers",
                columns: new[] { "Id", "Company", "EndDate", "JobDescription", "JobTitle", "Location", "SalaryFrom", "SalaryTo", "StartDate" },
                values: new object[,]
                {
                    { 8, "Sharlotta", new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "We are looking for cooker", "Cooker", "Warszaw", 8000, 10000, new DateTime(2020, 1, 16, 1, 13, 35, 456, DateTimeKind.Local) },
                    { 9, "Netflix", new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "We are looking for Designer", "Designer", "New York", 18000, 20000, new DateTime(2020, 1, 16, 1, 13, 35, 459, DateTimeKind.Local) },
                    { 10, "Netflix", new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "We are looking for manager", "Manager", "New York", 16000, 19000, new DateTime(2020, 1, 16, 1, 13, 35, 459, DateTimeKind.Local) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "JobOfers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "JobOfers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "JobOfers",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
