using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManager.Migrations
{
    /// <inheritdoc />
    public partial class AddTrainerRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5959), new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5960) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5962), new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5963) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 103,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt", "UserName" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5965), "martintrainer@gmail.com", new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5965), "MartinTrainer" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 104,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt", "UserName" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5967), "erentrainer@gmail.com", new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5967), "ErenTrainer" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 105,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt", "UserName" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5969), "paveltrainer@gmail.com", new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5969), "PavelTrainer" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 106,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt", "UserName" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5971), "mishotrainer@gmail.com", new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5971), "MishoTrainer" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 107,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt", "UserName" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5973), "mirotrainer@gmail.com", new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5973), "MiroTrainer" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 108,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt", "UserName" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5975), "julytrainer@gmail.com", new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5975), "JulyTrainer" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(992), new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(993) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(995), new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(995) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 103,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt", "UserName" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(997), "trainer3@gmail.com", new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(998), "Trainer3" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 104,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt", "UserName" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(999), "trainer4@gmail.com", new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(1000), "Trainer4" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 105,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt", "UserName" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(1001), "trainer5@gmail.com", new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(1002), "Trainer5" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 106,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt", "UserName" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(1003), "trainer6@gmail.com", new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(1003), "Trainer6" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 107,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt", "UserName" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(1005), "trainer7@gmail.com", new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(1005), "Trainer7" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 108,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt", "UserName" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(1007), "trainer8@gmail.com", new DateTime(2025, 2, 25, 18, 22, 28, 315, DateTimeKind.Utc).AddTicks(1007), "Trainer8" });
        }
    }
}
