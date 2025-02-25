using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymManager.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDuplicateRoleSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 101,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "RoleID", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9180), "1245", "1245", 1, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9181) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 102,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "RoleID", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9183), "1245", "1245", 1, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 103,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "RoleID", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9185), "1245", "1245", 1, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9186) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 104,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "RoleID", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9187), "1245", "1245", 1, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9188) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 105,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "RoleID", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9190), "1245", "1245", 1, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9190) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 106,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "RoleID", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9192), "1245", "1245", 1, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9192) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 107,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "RoleID", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9194), "1245", "1245", 1, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9194) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 108,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "RoleID", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9195), "1245", "1245", 1, new DateTime(2025, 2, 25, 18, 45, 52, 513, DateTimeKind.Utc).AddTicks(9196) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "RoleType" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Trainer" }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 101,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "RoleID", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5959), "dummy", "dummy", 2, new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5960) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 102,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "RoleID", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5962), "dummy", "dummy", 2, new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5963) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 103,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "RoleID", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5965), "dummy", "dummy", 2, new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5965) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 104,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "RoleID", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5967), "dummy", "dummy", 2, new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5967) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 105,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "RoleID", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5969), "dummy", "dummy", 2, new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5969) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 106,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "RoleID", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5971), "dummy", "dummy", 2, new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5971) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 107,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "RoleID", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5973), "dummy", "dummy", 2, new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5973) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 108,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt", "RoleID", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5975), "dummy", "dummy", 2, new DateTime(2025, 2, 25, 18, 27, 48, 557, DateTimeKind.Utc).AddTicks(5975) });
        }
    }
}
