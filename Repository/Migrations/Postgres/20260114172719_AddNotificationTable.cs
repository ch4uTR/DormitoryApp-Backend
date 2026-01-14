using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Repository.Migrations.Postgres
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    FcmToken = table.Column<string>(type: "text", nullable: false),
                    DeviceInfo = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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
                values: new object[] { "43d96a17-96bc-408e-82c1-877f0bfa1709", new DateTime(2026, 1, 14, 17, 27, 19, 297, DateTimeKind.Utc).AddTicks(2403), "AQAAAAIAAYagAAAAEPWpoJaxDZOkS1x3ulwChjc0DDQ9Clc9Lrg/EsQ7gDdPTs+x/xecD5RJFxtPjjiUlQ==", "6ae18678-8238-4c38-817c-10344b7cd308" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "777c02c2-502a-4b16-8ebc-00e9b24f2811", new DateTime(2026, 1, 14, 17, 27, 19, 334, DateTimeKind.Utc).AddTicks(2236), "AQAAAAIAAYagAAAAENE7DLyWKoK7Q20DiypaoWifW3elWS1WMRcw+BkdiWlfNFB8Xxvm7MiQFmaiD1Y6WA==", "6ef7b108-9c38-4d1c-b5ef-a63a7a57b7f3" });

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
                values: new object[] { "8ce380a8-d5d7-48b1-936d-8c4974339ea5", new DateTime(2026, 1, 14, 13, 5, 25, 718, DateTimeKind.Utc).AddTicks(3658), "AQAAAAIAAYagAAAAELXYgg1m1JA//IcPLjtRI4rOuB+PygxjX9plaewIHNCaJR/XwXTJ0+rcPBXLN+/Fyw==", "2b05e055-2dea-47f3-90ac-3ba8f989903f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "684e18eb-0ddc-40cd-8f52-7d9515bd2e64", new DateTime(2026, 1, 14, 13, 5, 25, 789, DateTimeKind.Utc).AddTicks(4077), "AQAAAAIAAYagAAAAELhesrqmropGCM9L9iyaLP5TgfBpBpJKTi7aV1zNtA6JthhULo7mFil2lgGK7G2Rhw==", "7b1c91cb-3f4c-4bf0-801c-0ef6eb9a3e35" });
        }
    }
}
