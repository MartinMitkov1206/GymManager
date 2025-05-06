using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymManager.Migrations
{
    /// <inheritdoc />
    public partial class WorkoutDateUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduledAt",
                table: "Workout",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduledAt",
                table: "Workout");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Age", "CreatedAt", "Email", "IsEmailConfirmed", "PasswordHash", "PasswordSalt", "RoleID", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { 101, 30, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9180), "qsentrainer@gmail.com", false, "1245", "1245", 1, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9181), "QsenTrainer" },
                    { 102, 30, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9183), "kamentrainer@gmail.com", false, "1245", "1245", 1, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9184), "KamenTrainer" },
                    { 103, 30, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9185), "martintrainer@gmail.com", false, "1245", "1245", 1, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9186), "MartinTrainer" },
                    { 104, 30, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9187), "erentrainer@gmail.com", false, "1245", "1245", 1, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9188), "ErenTrainer" },
                    { 105, 30, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9190), "paveltrainer@gmail.com", false, "1245", "1245", 1, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9190), "PavelTrainer" },
                    { 106, 30, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9192), "mishotrainer@gmail.com", false, "1245", "1245", 1, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9192), "MishoTrainer" },
                    { 107, 30, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9194), "mirotrainer@gmail.com", false, "1245", "1245", 1, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9194), "MiroTrainer" },
                    { 108, 30, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9195), "julytrainer@gmail.com", false, "1245", "1245", 1, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9196), "JulyTrainer" }
                });
        }
    }
}
