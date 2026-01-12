using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedToIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Issues",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "830a4107-8c4f-4495-8c1b-e57f835c5f13", new DateTime(2026, 1, 11, 21, 4, 58, 150, DateTimeKind.Utc).AddTicks(4626), "AQAAAAIAAYagAAAAEKuCx8U5OGT92mWchD4pFoh5cvqP2t0OhAn3jW2ppX5lk0LOfVsLqPgei5WB5uFcLw==", "2f9ffbee-c563-42e2-8ca8-e29c14b9e5ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d33c98f-b68d-439a-9eaa-4640e20b8347", new DateTime(2026, 1, 11, 21, 4, 58, 186, DateTimeKind.Utc).AddTicks(5077), "AQAAAAIAAYagAAAAEMWr6PC37ffDsu0XB05U9SZDryX5YocrLhhKRgeoXYE5wEGzSgM1IDEJG+l1AmnXJg==", "b9d83ff7-3a52-4871-9ddd-78a7e6238c40" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
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
    }
}
