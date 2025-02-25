using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymManager.Migrations
{
    /// <inheritdoc />
    public partial class SeedTrainerAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "RoleType" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Trainer" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Age", "CreatedAt", "Email", "IsEmailConfirmed", "PasswordHash", "PasswordSalt", "RoleID", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { 101, 30, new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(992), "qsentrainer@gmail.com", false, "dummy", "dummy", 2, new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(993), "QsenTrainer" },
                    { 102, 30, new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(995), "kamentrainer@gmail.com", false, "dummy", "dummy", 2, new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(995), "KamenTrainer" },
                    { 103, 30, new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(997), "trainer3@gmail.com", false, "dummy", "dummy", 2, new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(998), "Trainer3" },
                    { 104, 30, new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(999), "trainer4@gmail.com", false, "dummy", "dummy", 2, new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(1000), "Trainer4" },
                    { 105, 30, new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(1001), "trainer5@gmail.com", false, "dummy", "dummy", 2, new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(1002), "Trainer5" },
                    { 106, 30, new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(1003), "trainer6@gmail.com", false, "dummy", "dummy", 2, new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(1003), "Trainer6" },
                    { 107, 30, new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(1005), "trainer7@gmail.com", false, "dummy", "dummy", 2, new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(1005), "Trainer7" },
                    { 108, 30, new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(1007), "trainer8@gmail.com", false, "dummy", "dummy", 2, new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(1007), "Trainer8" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleID",
                keyValue: 2);
        }
    }
}
