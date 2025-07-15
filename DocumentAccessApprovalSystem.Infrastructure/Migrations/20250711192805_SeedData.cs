using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentAccessApprovalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccessRequests",
                columns: new[] { "Id", "CreatedAt", "DocumentId", "Reason", "RequestedAccessType", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 11, 20, 0, 0, 0, DateTimeKind.Utc), 1, "Need for work", 0, 0, 1 },
                    { 2, new DateTime(2024, 7, 11, 20, 5, 0, 0, DateTimeKind.Utc), 2, "Data analysis", 1, 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "Classification", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Internal", "Project specification", "Specification" },
                    { 2, "Confidential", "Quarterly report", "Report" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "User", "user1" },
                    { 2, "Approver", "approver1" }
                });

            migrationBuilder.InsertData(
                table: "Decisions",
                columns: new[] { "Id", "AccessRequestId", "ApproverId", "Comment", "DecidedAt", "IsApproved" },
                values: new object[,]
                {
                    { 1, 1, 2, "Approved", new DateTime(2024, 7, 11, 21, 0, 0, 0, DateTimeKind.Utc), true },
                    { 2, 2, 2, "No permission", new DateTime(2024, 7, 11, 21, 5, 0, 0, DateTimeKind.Utc), false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Decisions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Decisions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AccessRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccessRequests",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
