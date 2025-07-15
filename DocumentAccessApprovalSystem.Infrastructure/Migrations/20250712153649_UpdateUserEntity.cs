using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentAccessApprovalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AccessRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "Reason",
                value: "Need to review project requirements");

            migrationBuilder.UpdateData(
                table: "AccessRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "Reason",
                value: "Financial analysis for budget planning");

            migrationBuilder.UpdateData(
                table: "Decisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Comment",
                value: "Approved - Access granted for project review");

            migrationBuilder.UpdateData(
                table: "Decisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Comment",
                value: "Rejected - Edit access not allowed for confidential documents");

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
                columns: new[] { "Description", "Name" },
                values: new object[] { "Q4 financial report", "Quarterly Report" });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "Classification", "Description", "Name" },
                values: new object[] { 3, "Internal", "Human resources policies and procedures", "HR Policies" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "Name", "Role" },
                values: new object[] { new DateTime(2024, 7, 11, 19, 0, 0, 0, DateTimeKind.Utc), "john.doe@company.com", "John Doe", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Email", "Name", "Role" },
                values: new object[] { new DateTime(2024, 7, 11, 19, 0, 0, 0, DateTimeKind.Utc), "jane.smith@company.com", "Jane Smith", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Role" },
                values: new object[] { 3, new DateTime(2024, 7, 11, 19, 0, 0, 0, DateTimeKind.Utc), "admin@company.com", "Admin User", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "UserName");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "AccessRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "Reason",
                value: "Need for work");

            migrationBuilder.UpdateData(
                table: "AccessRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "Reason",
                value: "Data analysis");

            migrationBuilder.UpdateData(
                table: "Decisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Comment",
                value: "Approved");

            migrationBuilder.UpdateData(
                table: "Decisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Comment",
                value: "No permission");

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Project specification", "Specification" });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Quarterly report", "Report" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Role", "UserName" },
                values: new object[] { "User", "user1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Role", "UserName" },
                values: new object[] { "Approver", "approver1" });
        }
    }
}
