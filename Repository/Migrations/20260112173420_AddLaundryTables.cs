using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddLaundryTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LaundrySlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TotalCapacity = table.Column<int>(type: "int", nullable: false),
                    ReservedCount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaundrySlots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaundryReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SlotId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaundryReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaundryReservations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaundryReservations_LaundrySlots_SlotId",
                        column: x => x.SlotId,
                        principalTable: "LaundrySlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d601c2a-3a4e-4a09-b761-41409d2ddb45", new DateTime(2026, 1, 12, 17, 34, 20, 286, DateTimeKind.Utc).AddTicks(5967), "AQAAAAIAAYagAAAAEMZuqaSS93eFSdvBA7V1TFYGtIRwJvNS+VSDiHj2qeArU5Fnwx9OdiEVkAxP26KH7w==", "93b2860d-e368-4a1e-96de-46976589545f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae93e51a-286e-4517-aaaa-03907af1e1b5", new DateTime(2026, 1, 12, 17, 34, 20, 323, DateTimeKind.Utc).AddTicks(7408), "AQAAAAIAAYagAAAAEDDhjokp+qLch1ahRh5o4lGIAg9bSLlpTNjFjpodPOr0SYjrzsBU8EmBDD7rm82iCg==", "50626a5e-7248-497f-9a44-943e2539edc2" });

            migrationBuilder.CreateIndex(
                name: "IX_LaundryReservations_SlotId",
                table: "LaundryReservations",
                column: "SlotId");

            migrationBuilder.CreateIndex(
                name: "IX_LaundryReservations_UserId",
                table: "LaundryReservations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LaundryReservations");

            migrationBuilder.DropTable(
                name: "LaundrySlots");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2bc93abb-6af2-471e-84bf-307978b71c5a", new DateTime(2026, 1, 12, 16, 41, 36, 98, DateTimeKind.Utc).AddTicks(9679), "AQAAAAIAAYagAAAAEOFvFgGC39RISnU9f/VQTs6mC5/5ta0sjziNKufiFQk6WeKPhioGkMgnFPZo5VgGOA==", "20165d66-834c-4909-8f61-38748a2147d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbfdf7f4-8907-49a3-92b9-b831f21f53c3", new DateTime(2026, 1, 12, 16, 41, 36, 136, DateTimeKind.Utc).AddTicks(2771), "AQAAAAIAAYagAAAAEGdW9rZ/bVQjPtquIxD6o9m0yfqd0FcpWhjsl2AciSIAa42O4arPsN9YcQOv36XEbw==", "e13bfbd8-7e92-4aed-94e4-80b587106090" });
        }
    }
}
