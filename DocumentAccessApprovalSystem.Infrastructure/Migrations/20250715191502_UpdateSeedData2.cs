using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentAccessApprovalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccessRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 12, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "AccessRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 12, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Decisions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Comment", "DecidedAt" },
                values: new object[] { "Approved", new DateTime(2025, 7, 13, 12, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Decisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "DecidedAt",
                value: new DateTime(2025, 7, 13, 12, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 12, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 12, 0, 0, 0, DateTimeKind.Utc));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccessRequests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 15, 18, 31, 16, 801, DateTimeKind.Local).AddTicks(4206));

            migrationBuilder.UpdateData(
                table: "AccessRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 15, 18, 31, 16, 801, DateTimeKind.Local).AddTicks(4465));

            migrationBuilder.UpdateData(
                table: "Decisions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Comment", "DecidedAt" },
                values: new object[] { "Approved - Access granted for project review", new DateTime(2025, 7, 15, 18, 31, 16, 801, DateTimeKind.Local).AddTicks(6094) });

            migrationBuilder.UpdateData(
                table: "Decisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "DecidedAt",
                value: new DateTime(2025, 7, 15, 18, 31, 16, 801, DateTimeKind.Local).AddTicks(6345));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 15, 18, 31, 16, 798, DateTimeKind.Local).AddTicks(2027));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 15, 18, 31, 16, 800, DateTimeKind.Local).AddTicks(5176));
        }
    }
}
