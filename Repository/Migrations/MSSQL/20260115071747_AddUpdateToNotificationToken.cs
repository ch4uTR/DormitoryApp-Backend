using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations.MSSQL
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
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "NotificationTokens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6ce3184-48de-4e5d-9292-ef21eaddfaf2", new DateTime(2026, 1, 15, 7, 17, 46, 935, DateTimeKind.Utc).AddTicks(2807), "AQAAAAIAAYagAAAAEI4mxLQ4b+1VwcK5FDFT6rlxYlKF30Wqd58tyZO65VxUJ7kw631cKlhb7Kaxu5Eziw==", "60e9c94d-7aa2-42c8-906a-61ee7d693733" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0832ce2-9c61-47c6-a7d8-8c5f0e5b66e2", new DateTime(2026, 1, 15, 7, 17, 46, 972, DateTimeKind.Utc).AddTicks(4322), "AQAAAAIAAYagAAAAEAQ5gZhIkrM+VqGqoIcimHT8h7x1cHGghIMtqWkEdFCqNnxzzpn5pEKawDMFfdD7XA==", "1c4ecc1e-4981-4aae-b5db-2c91c388d018" });
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
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
        }
    }
}
