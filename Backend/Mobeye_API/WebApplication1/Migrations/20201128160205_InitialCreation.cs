using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mobeye_API.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneIMEI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationPrivateKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthPrivateKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlarmId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alarms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Devicename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alarmtext = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Set_Reset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    TimeOfAlarm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Escalation = table.Column<bool>(type: "bit", nullable: false),
                    Confirmed_Denied = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Confirmed_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContactUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alarms_Users_AccountUserId",
                        column: x => x.AccountUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alarms_Users_ContactUserId",
                        column: x => x.ContactUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alarms_AccountUserId",
                table: "Alarms",
                column: "AccountUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Alarms_ContactUserId",
                table: "Alarms",
                column: "ContactUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AlarmId",
                table: "Users",
                column: "AlarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Alarms_AlarmId",
                table: "Users",
                column: "AlarmId",
                principalTable: "Alarms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alarms_Users_AccountUserId",
                table: "Alarms");

            migrationBuilder.DropForeignKey(
                name: "FK_Alarms_Users_ContactUserId",
                table: "Alarms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Alarms");
        }
    }
}
