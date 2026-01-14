using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations.Postgres
{
    /// <inheritdoc />
    public partial class AddRowVerisonToLaundrySlot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9892cb28-3924-4a82-9de3-1d1ab4a33bf3", new DateTime(2026, 1, 14, 12, 46, 28, 182, DateTimeKind.Utc).AddTicks(3281), "AQAAAAIAAYagAAAAEEHxGsTDmIaf8/nB592DdoyFAUFxA/gy5MTvPVn72yWgW+3lMApC8SR78MXrR29teA==", "2affd4fb-79be-49c3-9cc8-de56fcecd006" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "640cac27-c240-44d2-b5b4-14938457d68b", new DateTime(2026, 1, 14, 12, 46, 28, 257, DateTimeKind.Utc).AddTicks(9451), "AQAAAAIAAYagAAAAEDchSk+5fyagaMc0n2cNEqaFFrXWdo+fvBzTAvxxE6AyfW+jZf0jrM3GJMsuej7BiA==", "09f4e9cf-394e-44e6-a618-5b67ac67e29a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3367641-5a34-418a-9f54-619ff4a24745", new DateTime(2026, 1, 14, 12, 43, 56, 58, DateTimeKind.Utc).AddTicks(4095), "AQAAAAIAAYagAAAAEJMYYux8LE4AhNx8PACdBqLfSSntnmZwLZppVPfnnmIqs2NPaM/czAAZl6UdGFS1Mw==", "b8926bbc-c2eb-4548-a8f4-e5d03688315f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee25ecd5-80b5-4a6b-87c6-775fdf53ea56", new DateTime(2026, 1, 14, 12, 43, 56, 133, DateTimeKind.Utc).AddTicks(2571), "AQAAAAIAAYagAAAAEMp0lEryjJhHtVE9Bdlwf4nThT8Rc/FDDY3DpG3Rs/Iu18MqHAxI+9Wj/IBHKKvCMQ==", "55515eec-5cce-477f-908d-0c6d9f249dd2" });
        }
    }
}
