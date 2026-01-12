using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class FixRoomAssignmentIsActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91a7885a-99ab-4ed0-bd9a-9ce0221b9cfc", new DateTime(2026, 1, 9, 17, 38, 32, 84, DateTimeKind.Utc).AddTicks(8168), "AQAAAAIAAYagAAAAEPfteACnsdbDpKTw0omW3RKtxyg2qRh1yIt8avUmW4zocrjRzyGsgH5iNzD3ZDxs4A==", "84ae2e98-9a97-4a32-b009-6f715e4dc4b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe4dde90-abc6-42d1-a392-d6b1b16483d9", new DateTime(2026, 1, 9, 17, 38, 32, 126, DateTimeKind.Utc).AddTicks(7646), "AQAAAAIAAYagAAAAEGdf5LbG0y0FHgra7j6yWynhYi/9AwChT5xutkc/SCMOZRrrvyposqmE7PwoKZEi4g==", "db33b808-3f41-44ee-a247-18e828449ddf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4e15276-a3be-48cf-8d79-f21260918048", new DateTime(2026, 1, 9, 17, 11, 20, 824, DateTimeKind.Utc).AddTicks(1530), "AQAAAAIAAYagAAAAEDbh9cpPZb3JAryUwpSuQdEOR7N+hwLfbLkTylqQ8G+uqW2xSe1krSvVgQ137e47sg==", "76970c5e-6e8a-469e-89a9-cb41e83eacb9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8df5b121-034d-4ca6-9705-bf9233894893", new DateTime(2026, 1, 9, 17, 11, 20, 896, DateTimeKind.Utc).AddTicks(2576), "AQAAAAIAAYagAAAAEGp33x3/qdB/j4puGdMKuFSzSI1V8ku0kP3H5HdkWm+0TT1jyxDXv5/iMf98fd6E+g==", "3eb2d70d-cd72-4dda-b756-19251e035df0" });
        }
    }
}
