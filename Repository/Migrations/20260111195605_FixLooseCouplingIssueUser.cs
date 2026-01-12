using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class FixLooseCouplingIssueUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_AspNetUsers_AdminId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_AspNetUsers_LaundryManId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_AdminId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_LaundryManId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "LaundryManId",
                table: "Issues");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03cd4d09-771b-495f-9ad5-c6f157a34cc6", new DateTime(2026, 1, 11, 19, 56, 5, 181, DateTimeKind.Utc).AddTicks(4554), "AQAAAAIAAYagAAAAEPM+rmDgCn5GNR3hJykBu0hx6sSev7peDDXL7G5LSHdQyObADEN/SuXcOaf1bT63nA==", "1e5406c5-04bb-4708-8983-4657c9a48272" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "019351f9-5b2d-4326-bf5a-1d4eb19f4d83", new DateTime(2026, 1, 11, 19, 56, 5, 218, DateTimeKind.Utc).AddTicks(2359), "AQAAAAIAAYagAAAAEE44qpRjS2+gZzcBhhD5/h5fAT2aS787HWbtVip6Vs2sHVFpFLVvi2urSs7HNSc4ag==", "0d1295d7-d143-4244-a60c-51056f5e08bd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminId",
                table: "Issues",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LaundryManId",
                table: "Issues",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Issues_AdminId",
                table: "Issues",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_LaundryManId",
                table: "Issues",
                column: "LaundryManId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_AspNetUsers_AdminId",
                table: "Issues",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_AspNetUsers_LaundryManId",
                table: "Issues",
                column: "LaundryManId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
