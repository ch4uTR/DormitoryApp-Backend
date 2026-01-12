using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class FixDateTimeNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Issues",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastModifiedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3778f24-2a46-42aa-bf5d-184a34ea2691", new DateTime(2026, 1, 9, 13, 13, 8, 938, DateTimeKind.Utc).AddTicks(9980), null, "AQAAAAIAAYagAAAAEP5nYBA5/no1KFRF4HG76oK35LKg7L4QsVi6qYaG5/3vOTkJh5Gcu4Y4L7O6tuDA1w==", "55a5bbe1-f506-46f7-b0aa-64347d3b2531" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastModifiedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9c09576-58b4-4af7-99ce-c6eb6a7d0708", new DateTime(2026, 1, 9, 13, 13, 8, 975, DateTimeKind.Utc).AddTicks(1526), null, "AQAAAAIAAYagAAAAEEPg6DUMR+leT/CiZ/0PyrGWXwlKTYW/G4b2XkCwJ3Js5TtKZ8eitgus5HX0LwZb3g==", "b9af9977-64f2-4e1d-b2e0-1fd58e0c20cf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Issues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastModifiedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "055e01c1-d3d2-4dc2-9465-8252ef3d2411", new DateTime(2026, 1, 5, 16, 34, 25, 578, DateTimeKind.Utc).AddTicks(9225), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAIAAYagAAAAELXYksRIxH6s38II4W03ieQqoRxJ0CuSuO51CURa5n3eosXjCso62Yfv2edfliY5YQ==", "dd12c5a3-0f44-41e3-ab63-c37918e20e44" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastModifiedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39a24e89-d283-49bf-a177-e04719bcd1e2", new DateTime(2026, 1, 5, 16, 34, 25, 614, DateTimeKind.Utc).AddTicks(9381), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAIAAYagAAAAEAQF8MzmY1DU+sKmxnhu2n1eloL9fZRtGebU9BaaxiuAe8A15m8wg0Xf6v9QuvoFdw==", "a0aaea5b-96ee-4449-bc1a-2bbbf12c8ecf" });
        }
    }
}
