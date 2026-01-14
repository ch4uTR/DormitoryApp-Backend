using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations.MSSQL
{
    /// <inheritdoc />
    public partial class AddNotificationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FcmToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e39cd03-0abf-42d3-8961-9d7295a246c3", new DateTime(2026, 1, 14, 17, 26, 30, 21, DateTimeKind.Utc).AddTicks(2655), "AQAAAAIAAYagAAAAEI7jzihjS+TxWkYNKN477FUBpHrCD38Yup4zHUws2cwk6oEdK0n1ARAUxyvzh96rNw==", "786d3d30-8a5e-40cc-b766-98eb17ecd7f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3baa824d-1a0e-439b-84e1-dcc703853d7e", new DateTime(2026, 1, 14, 17, 26, 30, 59, DateTimeKind.Utc).AddTicks(3308), "AQAAAAIAAYagAAAAEOrT3etih7boBhbQbAuqybrtmImigc4Wpr+wJSiAWC7MW0XxMyohnkgr527rTFbPgA==", "c1d05476-68af-4c15-8be6-ca237ba42b5c" });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTokens_UserId",
                table: "NotificationTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationTokens");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3efb40ed-abfc-4006-adcd-6eb086da1abb", new DateTime(2026, 1, 14, 13, 5, 12, 893, DateTimeKind.Utc).AddTicks(9438), "AQAAAAIAAYagAAAAEDjiAkVIV8tfOyGTGihYAChzqzTPuYOgnntAXPIY8K3ojIwy7KVMLpI2E7BdFhezsA==", "1e98243f-70e8-456b-922e-d2bccb9111a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "222e1a89-f158-486f-869a-d368cfaf9eed", new DateTime(2026, 1, 14, 13, 5, 12, 973, DateTimeKind.Utc).AddTicks(3942), "AQAAAAIAAYagAAAAEID1pSgscdJ96SyLSM6LgUKs93N6jXE+1FQi2Ve5s+Y+99CqQYfIfWfK4aBOrsFpcQ==", "5111af19-cd47-4fda-94b9-abf9521adf91" });
        }
    }
}
