using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations.Postgres
{
    /// <inheritdoc />
    public partial class AddUpdateToNotificationToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "NotificationTokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "NotificationTokens",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad998bc7-ff1f-4957-bf09-4e57aa7ff110", new DateTime(2026, 1, 15, 7, 19, 46, 395, DateTimeKind.Utc).AddTicks(2957), "AQAAAAIAAYagAAAAEOpC/YjO81JnO4UiVwgZnteIvr7Zv578a4skChy14+QAJz3ybF3MFhfjwbiO/RZgQA==", "1debd532-1ea9-43ef-ae20-007e5d216180" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a16b84b8-b9b3-4936-b072-3584126dfce3", new DateTime(2026, 1, 15, 7, 19, 46, 432, DateTimeKind.Utc).AddTicks(8565), "AQAAAAIAAYagAAAAENLHwnr1cmkvihwz19pw2Lfvj3MldofYRDCme4vYZ0SdrrUYtgK7KxwzrQfy5fC49A==", "d3efb273-dcd5-4dce-bd7f-73afb412b696" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "NotificationTokens");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "NotificationTokens",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

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
        }
    }
}
