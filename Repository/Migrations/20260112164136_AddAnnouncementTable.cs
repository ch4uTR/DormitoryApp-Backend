using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddAnnouncementTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlockId = table.Column<int>(type: "int", nullable: true),
                    FloorId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

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
    }
}
