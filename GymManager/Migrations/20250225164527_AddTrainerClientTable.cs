using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManager.Migrations
{
    /// <inheritdoc />
    public partial class AddTrainerClientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainerClients",
                columns: table => new
                {
                    TrainerClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerClients", x => x.TrainerClientID);
                    table.ForeignKey(
                        name: "FK_TrainerClients_User_ClientID",
                        column: x => x.ClientID,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_TrainerClients_User_TrainerID",
                        column: x => x.TrainerID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainerClients_ClientID",
                table: "TrainerClients",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerClients_TrainerID",
                table: "TrainerClients",
                column: "TrainerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainerClients");
        }
    }
}
