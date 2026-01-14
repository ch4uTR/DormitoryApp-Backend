using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations.MSSQL
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
                values: new object[] { "cf878d70-6496-4298-ac83-d1eaa3e824b9", new DateTime(2026, 1, 14, 12, 46, 8, 406, DateTimeKind.Utc).AddTicks(4152), "AQAAAAIAAYagAAAAEKEz2JCDNDbAxWm4jx+vrI2aMa0LRED2dWY9GDkY66OIDgjoYZ3W895dQDqYHaDhUw==", "c2ca5483-e0b1-407f-bb85-72d92a3f1ffc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd75dd05-31f3-41d3-968c-0ce1546b5077", new DateTime(2026, 1, 14, 12, 46, 8, 475, DateTimeKind.Utc).AddTicks(2110), "AQAAAAIAAYagAAAAECRG2rwLjQqvAEF3MeL1LypfqN9ymskVBn4RESlbUEQrX4AbuBsoRqaU0BhDN0xDjw==", "a1f80d32-0fbd-409c-9300-53ce27cb253b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2f5a3df-cca4-45ad-b4fd-689eb60db114", new DateTime(2026, 1, 14, 12, 44, 50, 610, DateTimeKind.Utc).AddTicks(9359), "AQAAAAIAAYagAAAAEDQrcp1gsOJdsvHpBEkNgyYsEkT97DoYfaAnehBG64tPB/9ignIyeI86aFsmT25CwQ==", "d0762572-9f59-485a-b0a1-53f09653b90a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58970ba9-1c73-486b-bde1-dc4b967ad91f", new DateTime(2026, 1, 14, 12, 44, 50, 687, DateTimeKind.Utc).AddTicks(4133), "AQAAAAIAAYagAAAAEJakeDoQDXcKKgQbpWBvE3dgjno36D98tfUUSS/LM7tg1XGYE/GVh8egwGVRM8a9SQ==", "9b93ba10-97df-4c6f-bc5b-25db50b4f872" });
        }
    }
}
