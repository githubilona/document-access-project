using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentAccessApprovalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AccessRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Reason" },
                values: new object[] { new DateTime(2025, 7, 15, 18, 31, 16, 801, DateTimeKind.Local).AddTicks(4206), "review finanical report " });

            migrationBuilder.UpdateData(
                table: "AccessRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Reason" },
                values: new object[] { new DateTime(2025, 7, 15, 18, 31, 16, 801, DateTimeKind.Local).AddTicks(4465), "edit financial report" });

            migrationBuilder.UpdateData(
                table: "Decisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DecidedAt",
                value: new DateTime(2025, 7, 15, 18, 31, 16, 801, DateTimeKind.Local).AddTicks(6094));

            migrationBuilder.UpdateData(
                table: "Decisions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Comment", "DecidedAt" },
                values: new object[] { "Rejected -  user not allowed", new DateTime(2025, 7, 15, 18, 31, 16, 801, DateTimeKind.Local).AddTicks(6345) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "BankApp project documentatation", "Project_documentation.docx" });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Quarterly_Report.xlsx");

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "Name" },
                values: new object[] { new DateTime(2025, 7, 15, 18, 31, 16, 798, DateTimeKind.Local).AddTicks(2027), "user@user.com", "user" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Email", "Name" },
                values: new object[] { new DateTime(2025, 7, 15, 18, 31, 16, 800, DateTimeKind.Local).AddTicks(5176), "approver@approver.com", "approver" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccessRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Reason" },
                values: new object[] { new DateTime(2024, 7, 11, 20, 0, 0, 0, DateTimeKind.Utc), "Need to review project requirements" });

            migrationBuilder.UpdateData(
                table: "AccessRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Reason" },
                values: new object[] { new DateTime(2024, 7, 11, 20, 5, 0, 0, DateTimeKind.Utc), "Financial analysis for budget planning" });

            migrationBuilder.UpdateData(
                table: "Decisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DecidedAt",
                value: new DateTime(2024, 7, 11, 21, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Decisions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Comment", "DecidedAt" },
                values: new object[] { "Rejected - Edit access not allowed for confidential documents", new DateTime(2024, 7, 11, 21, 5, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Technical specification for the new project", "Project Specification" });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Quarterly Report");

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "HR Policies");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "Name" },
                values: new object[] { new DateTime(2024, 7, 11, 19, 0, 0, 0, DateTimeKind.Utc), "john.doe@company.com", "John Doe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Email", "Name" },
                values: new object[] { new DateTime(2024, 7, 11, 19, 0, 0, 0, DateTimeKind.Utc), "jane.smith@company.com", "Jane Smith" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Role" },
                values: new object[] { 3, new DateTime(2024, 7, 11, 19, 0, 0, 0, DateTimeKind.Utc), "admin@company.com", "Admin User", 2 });
        }
    }
}
