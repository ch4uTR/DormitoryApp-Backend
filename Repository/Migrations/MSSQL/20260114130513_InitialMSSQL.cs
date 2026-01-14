using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations.MSSQL
{
    /// <inheritdoc />
    public partial class InitialMSSQL : Migration
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

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlockName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaundrySlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TotalCapacity = table.Column<int>(type: "int", nullable: false),
                    ReservedCount = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaundrySlots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorNumber = table.Column<int>(type: "int", nullable: false),
                    BlockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floors_Blocks_BlockId",
                        column: x => x.BlockId,
                        principalTable: "Blocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    FloorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    StudentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issues_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Issues_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LaundryReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SlotId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaundryReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaundryReservations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaundryReservations_LaundrySlots_SlotId",
                        column: x => x.SlotId,
                        principalTable: "LaundrySlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomAssignments_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomAssignments_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssueVotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VotedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueVotes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueVotes_Issues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ac675ca-05b1-4fce-b9dd-7f1f98ab8ce0", null, "LaundryMan", "LAUNDRYMAN" },
                    { "ab1e6881-efaf-4d83-9fb2-db9ddd61990a", null, "Admin", "ADMIN" },
                    { "aba0f76e-42b4-40e1-838f-bb7108b81941", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastModifiedAt", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "3efb40ed-abfc-4006-adcd-6eb086da1abb", new DateTime(2026, 1, 14, 13, 5, 12, 893, DateTimeKind.Utc).AddTicks(9438), "admin@yudorm.com", true, "Sistem", null, "Yöneticisi", false, null, "ADMIN@YUDORM.COM", "ADMIN@YUDORM.COM", "AQAAAAIAAYagAAAAEDjiAkVIV8tfOyGTGihYAChzqzTPuYOgnntAXPIY8K3ojIwy7KVMLpI2E7BdFhezsA==", null, false, "1e98243f-70e8-456b-922e-d2bccb9111a7", false, "admin@yudorm.com", "Admin" },
                    { "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468", 0, "222e1a89-f158-486f-869a-d368cfaf9eed", new DateTime(2026, 1, 14, 13, 5, 12, 973, DateTimeKind.Utc).AddTicks(3942), "laundryman@yudorm.com", true, "Laundry", null, "Service", false, null, "LAUNDRYMAN@YUDORM.COM", "LAUNDRYMAN", "AQAAAAIAAYagAAAAEID1pSgscdJ96SyLSM6LgUKs93N6jXE+1FQi2Ve5s+Y+99CqQYfIfWfK4aBOrsFpcQ==", null, false, "5111af19-cd47-4fda-94b9-abf9521adf91", false, "LAUNDRYMAN@YUDORM.COM", "LaundryMan" }
                });

            migrationBuilder.InsertData(
                table: "Blocks",
                columns: new[] { "Id", "BlockName" },
                values: new object[,]
                {
                    { 1, "A" },
                    { 2, "B" },
                    { 3, "C" },
                    { 4, "D" },
                    { 5, "E" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ab1e6881-efaf-4d83-9fb2-db9ddd61990a", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "2ac675ca-05b1-4fce-b9dd-7f1f98ab8ce0", "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468" }
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "Id", "BlockId", "FloorNumber" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 2, 1, 1 },
                    { 3, 1, 2 },
                    { 4, 1, 3 },
                    { 5, 1, 4 },
                    { 6, 1, 5 },
                    { 7, 1, 6 },
                    { 8, 1, 7 },
                    { 9, 1, 8 },
                    { 10, 1, 9 },
                    { 11, 1, 10 },
                    { 12, 1, 11 },
                    { 13, 1, 12 },
                    { 14, 2, 0 },
                    { 15, 2, 1 },
                    { 16, 2, 2 },
                    { 17, 2, 3 },
                    { 18, 2, 4 },
                    { 19, 2, 5 },
                    { 20, 2, 6 },
                    { 21, 2, 7 },
                    { 22, 2, 8 },
                    { 23, 2, 9 },
                    { 24, 2, 10 },
                    { 25, 2, 11 },
                    { 26, 2, 12 },
                    { 27, 3, 0 },
                    { 28, 3, 1 },
                    { 29, 3, 2 },
                    { 30, 3, 3 },
                    { 31, 3, 4 },
                    { 32, 3, 5 },
                    { 33, 3, 6 },
                    { 34, 3, 7 },
                    { 35, 3, 8 },
                    { 36, 3, 9 },
                    { 37, 3, 10 },
                    { 38, 3, 11 },
                    { 39, 3, 12 },
                    { 40, 4, 0 },
                    { 41, 4, 1 },
                    { 42, 4, 2 },
                    { 43, 4, 3 },
                    { 44, 4, 4 },
                    { 45, 4, 5 },
                    { 46, 4, 6 },
                    { 47, 4, 7 },
                    { 48, 4, 8 },
                    { 49, 4, 9 },
                    { 50, 4, 10 },
                    { 51, 4, 11 },
                    { 52, 4, 12 },
                    { 53, 5, 0 },
                    { 54, 5, 1 },
                    { 55, 5, 2 },
                    { 56, 5, 3 },
                    { 57, 5, 4 },
                    { 58, 5, 5 },
                    { 59, 5, 6 },
                    { 60, 5, 7 },
                    { 61, 5, 8 },
                    { 62, 5, 9 },
                    { 63, 5, 10 },
                    { 64, 5, 11 },
                    { 65, 5, 12 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "FloorId", "RoomNumber" },
                values: new object[,]
                {
                    { 1, 2, 1, 1 },
                    { 2, 2, 1, 2 },
                    { 3, 2, 1, 3 },
                    { 4, 2, 1, 4 },
                    { 5, 2, 1, 5 },
                    { 6, 2, 1, 6 },
                    { 7, 2, 1, 7 },
                    { 8, 2, 1, 8 },
                    { 9, 2, 1, 9 },
                    { 10, 2, 1, 10 },
                    { 11, 2, 1, 11 },
                    { 12, 2, 1, 12 },
                    { 13, 2, 1, 13 },
                    { 14, 2, 1, 14 },
                    { 15, 2, 1, 15 },
                    { 16, 2, 2, 1 },
                    { 17, 2, 2, 2 },
                    { 18, 2, 2, 3 },
                    { 19, 2, 2, 4 },
                    { 20, 2, 2, 5 },
                    { 21, 2, 2, 6 },
                    { 22, 2, 2, 7 },
                    { 23, 2, 2, 8 },
                    { 24, 2, 2, 9 },
                    { 25, 2, 2, 10 },
                    { 26, 2, 2, 11 },
                    { 27, 2, 2, 12 },
                    { 28, 2, 2, 13 },
                    { 29, 2, 2, 14 },
                    { 30, 2, 2, 15 },
                    { 31, 2, 3, 1 },
                    { 32, 2, 3, 2 },
                    { 33, 2, 3, 3 },
                    { 34, 2, 3, 4 },
                    { 35, 2, 3, 5 },
                    { 36, 2, 3, 6 },
                    { 37, 2, 3, 7 },
                    { 38, 2, 3, 8 },
                    { 39, 2, 3, 9 },
                    { 40, 2, 3, 10 },
                    { 41, 2, 3, 11 },
                    { 42, 2, 3, 12 },
                    { 43, 2, 3, 13 },
                    { 44, 2, 3, 14 },
                    { 45, 2, 3, 15 },
                    { 46, 2, 4, 1 },
                    { 47, 2, 4, 2 },
                    { 48, 2, 4, 3 },
                    { 49, 2, 4, 4 },
                    { 50, 2, 4, 5 },
                    { 51, 2, 4, 6 },
                    { 52, 2, 4, 7 },
                    { 53, 2, 4, 8 },
                    { 54, 2, 4, 9 },
                    { 55, 2, 4, 10 },
                    { 56, 2, 4, 11 },
                    { 57, 2, 4, 12 },
                    { 58, 2, 4, 13 },
                    { 59, 2, 4, 14 },
                    { 60, 2, 4, 15 },
                    { 61, 2, 5, 1 },
                    { 62, 2, 5, 2 },
                    { 63, 2, 5, 3 },
                    { 64, 2, 5, 4 },
                    { 65, 2, 5, 5 },
                    { 66, 2, 5, 6 },
                    { 67, 2, 5, 7 },
                    { 68, 2, 5, 8 },
                    { 69, 2, 5, 9 },
                    { 70, 2, 5, 10 },
                    { 71, 2, 5, 11 },
                    { 72, 2, 5, 12 },
                    { 73, 2, 5, 13 },
                    { 74, 2, 5, 14 },
                    { 75, 2, 5, 15 },
                    { 76, 2, 6, 1 },
                    { 77, 2, 6, 2 },
                    { 78, 2, 6, 3 },
                    { 79, 2, 6, 4 },
                    { 80, 2, 6, 5 },
                    { 81, 2, 6, 6 },
                    { 82, 2, 6, 7 },
                    { 83, 2, 6, 8 },
                    { 84, 2, 6, 9 },
                    { 85, 2, 6, 10 },
                    { 86, 2, 6, 11 },
                    { 87, 2, 6, 12 },
                    { 88, 2, 6, 13 },
                    { 89, 2, 6, 14 },
                    { 90, 2, 6, 15 },
                    { 91, 2, 7, 1 },
                    { 92, 2, 7, 2 },
                    { 93, 2, 7, 3 },
                    { 94, 2, 7, 4 },
                    { 95, 2, 7, 5 },
                    { 96, 2, 7, 6 },
                    { 97, 2, 7, 7 },
                    { 98, 2, 7, 8 },
                    { 99, 2, 7, 9 },
                    { 100, 2, 7, 10 },
                    { 101, 2, 7, 11 },
                    { 102, 2, 7, 12 },
                    { 103, 2, 7, 13 },
                    { 104, 2, 7, 14 },
                    { 105, 2, 7, 15 },
                    { 106, 2, 8, 1 },
                    { 107, 2, 8, 2 },
                    { 108, 2, 8, 3 },
                    { 109, 2, 8, 4 },
                    { 110, 2, 8, 5 },
                    { 111, 2, 8, 6 },
                    { 112, 2, 8, 7 },
                    { 113, 2, 8, 8 },
                    { 114, 2, 8, 9 },
                    { 115, 2, 8, 10 },
                    { 116, 2, 8, 11 },
                    { 117, 2, 8, 12 },
                    { 118, 2, 8, 13 },
                    { 119, 2, 8, 14 },
                    { 120, 2, 8, 15 },
                    { 121, 2, 9, 1 },
                    { 122, 2, 9, 2 },
                    { 123, 2, 9, 3 },
                    { 124, 2, 9, 4 },
                    { 125, 2, 9, 5 },
                    { 126, 2, 9, 6 },
                    { 127, 2, 9, 7 },
                    { 128, 2, 9, 8 },
                    { 129, 2, 9, 9 },
                    { 130, 2, 9, 10 },
                    { 131, 2, 9, 11 },
                    { 132, 2, 9, 12 },
                    { 133, 2, 9, 13 },
                    { 134, 2, 9, 14 },
                    { 135, 2, 9, 15 },
                    { 136, 2, 10, 1 },
                    { 137, 2, 10, 2 },
                    { 138, 2, 10, 3 },
                    { 139, 2, 10, 4 },
                    { 140, 2, 10, 5 },
                    { 141, 2, 10, 6 },
                    { 142, 2, 10, 7 },
                    { 143, 2, 10, 8 },
                    { 144, 2, 10, 9 },
                    { 145, 2, 10, 10 },
                    { 146, 2, 10, 11 },
                    { 147, 2, 10, 12 },
                    { 148, 2, 10, 13 },
                    { 149, 2, 10, 14 },
                    { 150, 2, 10, 15 },
                    { 151, 2, 11, 1 },
                    { 152, 2, 11, 2 },
                    { 153, 2, 11, 3 },
                    { 154, 2, 11, 4 },
                    { 155, 2, 11, 5 },
                    { 156, 2, 11, 6 },
                    { 157, 2, 11, 7 },
                    { 158, 2, 11, 8 },
                    { 159, 2, 11, 9 },
                    { 160, 2, 11, 10 },
                    { 161, 2, 11, 11 },
                    { 162, 2, 11, 12 },
                    { 163, 2, 11, 13 },
                    { 164, 2, 11, 14 },
                    { 165, 2, 11, 15 },
                    { 166, 2, 12, 1 },
                    { 167, 2, 12, 2 },
                    { 168, 2, 12, 3 },
                    { 169, 2, 12, 4 },
                    { 170, 2, 12, 5 },
                    { 171, 2, 12, 6 },
                    { 172, 2, 12, 7 },
                    { 173, 2, 12, 8 },
                    { 174, 2, 12, 9 },
                    { 175, 2, 12, 10 },
                    { 176, 2, 12, 11 },
                    { 177, 2, 12, 12 },
                    { 178, 2, 12, 13 },
                    { 179, 2, 12, 14 },
                    { 180, 2, 12, 15 },
                    { 181, 2, 13, 1 },
                    { 182, 2, 13, 2 },
                    { 183, 2, 13, 3 },
                    { 184, 2, 13, 4 },
                    { 185, 2, 13, 5 },
                    { 186, 2, 13, 6 },
                    { 187, 2, 13, 7 },
                    { 188, 2, 13, 8 },
                    { 189, 2, 13, 9 },
                    { 190, 2, 13, 10 },
                    { 191, 2, 13, 11 },
                    { 192, 2, 13, 12 },
                    { 193, 2, 13, 13 },
                    { 194, 2, 13, 14 },
                    { 195, 2, 13, 15 },
                    { 196, 2, 14, 1 },
                    { 197, 2, 14, 2 },
                    { 198, 2, 14, 3 },
                    { 199, 2, 14, 4 },
                    { 200, 2, 14, 5 },
                    { 201, 2, 14, 6 },
                    { 202, 2, 14, 7 },
                    { 203, 2, 14, 8 },
                    { 204, 2, 14, 9 },
                    { 205, 2, 14, 10 },
                    { 206, 2, 14, 11 },
                    { 207, 2, 14, 12 },
                    { 208, 2, 14, 13 },
                    { 209, 2, 14, 14 },
                    { 210, 2, 14, 15 },
                    { 211, 2, 15, 1 },
                    { 212, 2, 15, 2 },
                    { 213, 2, 15, 3 },
                    { 214, 2, 15, 4 },
                    { 215, 2, 15, 5 },
                    { 216, 2, 15, 6 },
                    { 217, 2, 15, 7 },
                    { 218, 2, 15, 8 },
                    { 219, 2, 15, 9 },
                    { 220, 2, 15, 10 },
                    { 221, 2, 15, 11 },
                    { 222, 2, 15, 12 },
                    { 223, 2, 15, 13 },
                    { 224, 2, 15, 14 },
                    { 225, 2, 15, 15 },
                    { 226, 2, 16, 1 },
                    { 227, 2, 16, 2 },
                    { 228, 2, 16, 3 },
                    { 229, 2, 16, 4 },
                    { 230, 2, 16, 5 },
                    { 231, 2, 16, 6 },
                    { 232, 2, 16, 7 },
                    { 233, 2, 16, 8 },
                    { 234, 2, 16, 9 },
                    { 235, 2, 16, 10 },
                    { 236, 2, 16, 11 },
                    { 237, 2, 16, 12 },
                    { 238, 2, 16, 13 },
                    { 239, 2, 16, 14 },
                    { 240, 2, 16, 15 },
                    { 241, 2, 17, 1 },
                    { 242, 2, 17, 2 },
                    { 243, 2, 17, 3 },
                    { 244, 2, 17, 4 },
                    { 245, 2, 17, 5 },
                    { 246, 2, 17, 6 },
                    { 247, 2, 17, 7 },
                    { 248, 2, 17, 8 },
                    { 249, 2, 17, 9 },
                    { 250, 2, 17, 10 },
                    { 251, 2, 17, 11 },
                    { 252, 2, 17, 12 },
                    { 253, 2, 17, 13 },
                    { 254, 2, 17, 14 },
                    { 255, 2, 17, 15 },
                    { 256, 2, 18, 1 },
                    { 257, 2, 18, 2 },
                    { 258, 2, 18, 3 },
                    { 259, 2, 18, 4 },
                    { 260, 2, 18, 5 },
                    { 261, 2, 18, 6 },
                    { 262, 2, 18, 7 },
                    { 263, 2, 18, 8 },
                    { 264, 2, 18, 9 },
                    { 265, 2, 18, 10 },
                    { 266, 2, 18, 11 },
                    { 267, 2, 18, 12 },
                    { 268, 2, 18, 13 },
                    { 269, 2, 18, 14 },
                    { 270, 2, 18, 15 },
                    { 271, 2, 19, 1 },
                    { 272, 2, 19, 2 },
                    { 273, 2, 19, 3 },
                    { 274, 2, 19, 4 },
                    { 275, 2, 19, 5 },
                    { 276, 2, 19, 6 },
                    { 277, 2, 19, 7 },
                    { 278, 2, 19, 8 },
                    { 279, 2, 19, 9 },
                    { 280, 2, 19, 10 },
                    { 281, 2, 19, 11 },
                    { 282, 2, 19, 12 },
                    { 283, 2, 19, 13 },
                    { 284, 2, 19, 14 },
                    { 285, 2, 19, 15 },
                    { 286, 2, 20, 1 },
                    { 287, 2, 20, 2 },
                    { 288, 2, 20, 3 },
                    { 289, 2, 20, 4 },
                    { 290, 2, 20, 5 },
                    { 291, 2, 20, 6 },
                    { 292, 2, 20, 7 },
                    { 293, 2, 20, 8 },
                    { 294, 2, 20, 9 },
                    { 295, 2, 20, 10 },
                    { 296, 2, 20, 11 },
                    { 297, 2, 20, 12 },
                    { 298, 2, 20, 13 },
                    { 299, 2, 20, 14 },
                    { 300, 2, 20, 15 },
                    { 301, 2, 21, 1 },
                    { 302, 2, 21, 2 },
                    { 303, 2, 21, 3 },
                    { 304, 2, 21, 4 },
                    { 305, 2, 21, 5 },
                    { 306, 2, 21, 6 },
                    { 307, 2, 21, 7 },
                    { 308, 2, 21, 8 },
                    { 309, 2, 21, 9 },
                    { 310, 2, 21, 10 },
                    { 311, 2, 21, 11 },
                    { 312, 2, 21, 12 },
                    { 313, 2, 21, 13 },
                    { 314, 2, 21, 14 },
                    { 315, 2, 21, 15 },
                    { 316, 2, 22, 1 },
                    { 317, 2, 22, 2 },
                    { 318, 2, 22, 3 },
                    { 319, 2, 22, 4 },
                    { 320, 2, 22, 5 },
                    { 321, 2, 22, 6 },
                    { 322, 2, 22, 7 },
                    { 323, 2, 22, 8 },
                    { 324, 2, 22, 9 },
                    { 325, 2, 22, 10 },
                    { 326, 2, 22, 11 },
                    { 327, 2, 22, 12 },
                    { 328, 2, 22, 13 },
                    { 329, 2, 22, 14 },
                    { 330, 2, 22, 15 },
                    { 331, 2, 23, 1 },
                    { 332, 2, 23, 2 },
                    { 333, 2, 23, 3 },
                    { 334, 2, 23, 4 },
                    { 335, 2, 23, 5 },
                    { 336, 2, 23, 6 },
                    { 337, 2, 23, 7 },
                    { 338, 2, 23, 8 },
                    { 339, 2, 23, 9 },
                    { 340, 2, 23, 10 },
                    { 341, 2, 23, 11 },
                    { 342, 2, 23, 12 },
                    { 343, 2, 23, 13 },
                    { 344, 2, 23, 14 },
                    { 345, 2, 23, 15 },
                    { 346, 2, 24, 1 },
                    { 347, 2, 24, 2 },
                    { 348, 2, 24, 3 },
                    { 349, 2, 24, 4 },
                    { 350, 2, 24, 5 },
                    { 351, 2, 24, 6 },
                    { 352, 2, 24, 7 },
                    { 353, 2, 24, 8 },
                    { 354, 2, 24, 9 },
                    { 355, 2, 24, 10 },
                    { 356, 2, 24, 11 },
                    { 357, 2, 24, 12 },
                    { 358, 2, 24, 13 },
                    { 359, 2, 24, 14 },
                    { 360, 2, 24, 15 },
                    { 361, 2, 25, 1 },
                    { 362, 2, 25, 2 },
                    { 363, 2, 25, 3 },
                    { 364, 2, 25, 4 },
                    { 365, 2, 25, 5 },
                    { 366, 2, 25, 6 },
                    { 367, 2, 25, 7 },
                    { 368, 2, 25, 8 },
                    { 369, 2, 25, 9 },
                    { 370, 2, 25, 10 },
                    { 371, 2, 25, 11 },
                    { 372, 2, 25, 12 },
                    { 373, 2, 25, 13 },
                    { 374, 2, 25, 14 },
                    { 375, 2, 25, 15 },
                    { 376, 2, 26, 1 },
                    { 377, 2, 26, 2 },
                    { 378, 2, 26, 3 },
                    { 379, 2, 26, 4 },
                    { 380, 2, 26, 5 },
                    { 381, 2, 26, 6 },
                    { 382, 2, 26, 7 },
                    { 383, 2, 26, 8 },
                    { 384, 2, 26, 9 },
                    { 385, 2, 26, 10 },
                    { 386, 2, 26, 11 },
                    { 387, 2, 26, 12 },
                    { 388, 2, 26, 13 },
                    { 389, 2, 26, 14 },
                    { 390, 2, 26, 15 },
                    { 391, 2, 27, 1 },
                    { 392, 2, 27, 2 },
                    { 393, 2, 27, 3 },
                    { 394, 2, 27, 4 },
                    { 395, 2, 27, 5 },
                    { 396, 2, 27, 6 },
                    { 397, 2, 27, 7 },
                    { 398, 2, 27, 8 },
                    { 399, 2, 27, 9 },
                    { 400, 2, 27, 10 },
                    { 401, 2, 27, 11 },
                    { 402, 2, 27, 12 },
                    { 403, 2, 27, 13 },
                    { 404, 2, 27, 14 },
                    { 405, 2, 27, 15 },
                    { 406, 2, 28, 1 },
                    { 407, 2, 28, 2 },
                    { 408, 2, 28, 3 },
                    { 409, 2, 28, 4 },
                    { 410, 2, 28, 5 },
                    { 411, 2, 28, 6 },
                    { 412, 2, 28, 7 },
                    { 413, 2, 28, 8 },
                    { 414, 2, 28, 9 },
                    { 415, 2, 28, 10 },
                    { 416, 2, 28, 11 },
                    { 417, 2, 28, 12 },
                    { 418, 2, 28, 13 },
                    { 419, 2, 28, 14 },
                    { 420, 2, 28, 15 },
                    { 421, 2, 29, 1 },
                    { 422, 2, 29, 2 },
                    { 423, 2, 29, 3 },
                    { 424, 2, 29, 4 },
                    { 425, 2, 29, 5 },
                    { 426, 2, 29, 6 },
                    { 427, 2, 29, 7 },
                    { 428, 2, 29, 8 },
                    { 429, 2, 29, 9 },
                    { 430, 2, 29, 10 },
                    { 431, 2, 29, 11 },
                    { 432, 2, 29, 12 },
                    { 433, 2, 29, 13 },
                    { 434, 2, 29, 14 },
                    { 435, 2, 29, 15 },
                    { 436, 2, 30, 1 },
                    { 437, 2, 30, 2 },
                    { 438, 2, 30, 3 },
                    { 439, 2, 30, 4 },
                    { 440, 2, 30, 5 },
                    { 441, 2, 30, 6 },
                    { 442, 2, 30, 7 },
                    { 443, 2, 30, 8 },
                    { 444, 2, 30, 9 },
                    { 445, 2, 30, 10 },
                    { 446, 2, 30, 11 },
                    { 447, 2, 30, 12 },
                    { 448, 2, 30, 13 },
                    { 449, 2, 30, 14 },
                    { 450, 2, 30, 15 },
                    { 451, 2, 31, 1 },
                    { 452, 2, 31, 2 },
                    { 453, 2, 31, 3 },
                    { 454, 2, 31, 4 },
                    { 455, 2, 31, 5 },
                    { 456, 2, 31, 6 },
                    { 457, 2, 31, 7 },
                    { 458, 2, 31, 8 },
                    { 459, 2, 31, 9 },
                    { 460, 2, 31, 10 },
                    { 461, 2, 31, 11 },
                    { 462, 2, 31, 12 },
                    { 463, 2, 31, 13 },
                    { 464, 2, 31, 14 },
                    { 465, 2, 31, 15 },
                    { 466, 2, 32, 1 },
                    { 467, 2, 32, 2 },
                    { 468, 2, 32, 3 },
                    { 469, 2, 32, 4 },
                    { 470, 2, 32, 5 },
                    { 471, 2, 32, 6 },
                    { 472, 2, 32, 7 },
                    { 473, 2, 32, 8 },
                    { 474, 2, 32, 9 },
                    { 475, 2, 32, 10 },
                    { 476, 2, 32, 11 },
                    { 477, 2, 32, 12 },
                    { 478, 2, 32, 13 },
                    { 479, 2, 32, 14 },
                    { 480, 2, 32, 15 },
                    { 481, 2, 33, 1 },
                    { 482, 2, 33, 2 },
                    { 483, 2, 33, 3 },
                    { 484, 2, 33, 4 },
                    { 485, 2, 33, 5 },
                    { 486, 2, 33, 6 },
                    { 487, 2, 33, 7 },
                    { 488, 2, 33, 8 },
                    { 489, 2, 33, 9 },
                    { 490, 2, 33, 10 },
                    { 491, 2, 33, 11 },
                    { 492, 2, 33, 12 },
                    { 493, 2, 33, 13 },
                    { 494, 2, 33, 14 },
                    { 495, 2, 33, 15 },
                    { 496, 2, 34, 1 },
                    { 497, 2, 34, 2 },
                    { 498, 2, 34, 3 },
                    { 499, 2, 34, 4 },
                    { 500, 2, 34, 5 },
                    { 501, 2, 34, 6 },
                    { 502, 2, 34, 7 },
                    { 503, 2, 34, 8 },
                    { 504, 2, 34, 9 },
                    { 505, 2, 34, 10 },
                    { 506, 2, 34, 11 },
                    { 507, 2, 34, 12 },
                    { 508, 2, 34, 13 },
                    { 509, 2, 34, 14 },
                    { 510, 2, 34, 15 },
                    { 511, 2, 35, 1 },
                    { 512, 2, 35, 2 },
                    { 513, 2, 35, 3 },
                    { 514, 2, 35, 4 },
                    { 515, 2, 35, 5 },
                    { 516, 2, 35, 6 },
                    { 517, 2, 35, 7 },
                    { 518, 2, 35, 8 },
                    { 519, 2, 35, 9 },
                    { 520, 2, 35, 10 },
                    { 521, 2, 35, 11 },
                    { 522, 2, 35, 12 },
                    { 523, 2, 35, 13 },
                    { 524, 2, 35, 14 },
                    { 525, 2, 35, 15 },
                    { 526, 2, 36, 1 },
                    { 527, 2, 36, 2 },
                    { 528, 2, 36, 3 },
                    { 529, 2, 36, 4 },
                    { 530, 2, 36, 5 },
                    { 531, 2, 36, 6 },
                    { 532, 2, 36, 7 },
                    { 533, 2, 36, 8 },
                    { 534, 2, 36, 9 },
                    { 535, 2, 36, 10 },
                    { 536, 2, 36, 11 },
                    { 537, 2, 36, 12 },
                    { 538, 2, 36, 13 },
                    { 539, 2, 36, 14 },
                    { 540, 2, 36, 15 },
                    { 541, 2, 37, 1 },
                    { 542, 2, 37, 2 },
                    { 543, 2, 37, 3 },
                    { 544, 2, 37, 4 },
                    { 545, 2, 37, 5 },
                    { 546, 2, 37, 6 },
                    { 547, 2, 37, 7 },
                    { 548, 2, 37, 8 },
                    { 549, 2, 37, 9 },
                    { 550, 2, 37, 10 },
                    { 551, 2, 37, 11 },
                    { 552, 2, 37, 12 },
                    { 553, 2, 37, 13 },
                    { 554, 2, 37, 14 },
                    { 555, 2, 37, 15 },
                    { 556, 2, 38, 1 },
                    { 557, 2, 38, 2 },
                    { 558, 2, 38, 3 },
                    { 559, 2, 38, 4 },
                    { 560, 2, 38, 5 },
                    { 561, 2, 38, 6 },
                    { 562, 2, 38, 7 },
                    { 563, 2, 38, 8 },
                    { 564, 2, 38, 9 },
                    { 565, 2, 38, 10 },
                    { 566, 2, 38, 11 },
                    { 567, 2, 38, 12 },
                    { 568, 2, 38, 13 },
                    { 569, 2, 38, 14 },
                    { 570, 2, 38, 15 },
                    { 571, 2, 39, 1 },
                    { 572, 2, 39, 2 },
                    { 573, 2, 39, 3 },
                    { 574, 2, 39, 4 },
                    { 575, 2, 39, 5 },
                    { 576, 2, 39, 6 },
                    { 577, 2, 39, 7 },
                    { 578, 2, 39, 8 },
                    { 579, 2, 39, 9 },
                    { 580, 2, 39, 10 },
                    { 581, 2, 39, 11 },
                    { 582, 2, 39, 12 },
                    { 583, 2, 39, 13 },
                    { 584, 2, 39, 14 },
                    { 585, 2, 39, 15 },
                    { 586, 2, 40, 1 },
                    { 587, 2, 40, 2 },
                    { 588, 2, 40, 3 },
                    { 589, 2, 40, 4 },
                    { 590, 2, 40, 5 },
                    { 591, 2, 40, 6 },
                    { 592, 2, 40, 7 },
                    { 593, 2, 40, 8 },
                    { 594, 2, 40, 9 },
                    { 595, 2, 40, 10 },
                    { 596, 2, 40, 11 },
                    { 597, 2, 40, 12 },
                    { 598, 2, 40, 13 },
                    { 599, 2, 40, 14 },
                    { 600, 2, 40, 15 },
                    { 601, 2, 41, 1 },
                    { 602, 2, 41, 2 },
                    { 603, 2, 41, 3 },
                    { 604, 2, 41, 4 },
                    { 605, 2, 41, 5 },
                    { 606, 2, 41, 6 },
                    { 607, 2, 41, 7 },
                    { 608, 2, 41, 8 },
                    { 609, 2, 41, 9 },
                    { 610, 2, 41, 10 },
                    { 611, 2, 41, 11 },
                    { 612, 2, 41, 12 },
                    { 613, 2, 41, 13 },
                    { 614, 2, 41, 14 },
                    { 615, 2, 41, 15 },
                    { 616, 2, 42, 1 },
                    { 617, 2, 42, 2 },
                    { 618, 2, 42, 3 },
                    { 619, 2, 42, 4 },
                    { 620, 2, 42, 5 },
                    { 621, 2, 42, 6 },
                    { 622, 2, 42, 7 },
                    { 623, 2, 42, 8 },
                    { 624, 2, 42, 9 },
                    { 625, 2, 42, 10 },
                    { 626, 2, 42, 11 },
                    { 627, 2, 42, 12 },
                    { 628, 2, 42, 13 },
                    { 629, 2, 42, 14 },
                    { 630, 2, 42, 15 },
                    { 631, 2, 43, 1 },
                    { 632, 2, 43, 2 },
                    { 633, 2, 43, 3 },
                    { 634, 2, 43, 4 },
                    { 635, 2, 43, 5 },
                    { 636, 2, 43, 6 },
                    { 637, 2, 43, 7 },
                    { 638, 2, 43, 8 },
                    { 639, 2, 43, 9 },
                    { 640, 2, 43, 10 },
                    { 641, 2, 43, 11 },
                    { 642, 2, 43, 12 },
                    { 643, 2, 43, 13 },
                    { 644, 2, 43, 14 },
                    { 645, 2, 43, 15 },
                    { 646, 2, 44, 1 },
                    { 647, 2, 44, 2 },
                    { 648, 2, 44, 3 },
                    { 649, 2, 44, 4 },
                    { 650, 2, 44, 5 },
                    { 651, 2, 44, 6 },
                    { 652, 2, 44, 7 },
                    { 653, 2, 44, 8 },
                    { 654, 2, 44, 9 },
                    { 655, 2, 44, 10 },
                    { 656, 2, 44, 11 },
                    { 657, 2, 44, 12 },
                    { 658, 2, 44, 13 },
                    { 659, 2, 44, 14 },
                    { 660, 2, 44, 15 },
                    { 661, 2, 45, 1 },
                    { 662, 2, 45, 2 },
                    { 663, 2, 45, 3 },
                    { 664, 2, 45, 4 },
                    { 665, 2, 45, 5 },
                    { 666, 2, 45, 6 },
                    { 667, 2, 45, 7 },
                    { 668, 2, 45, 8 },
                    { 669, 2, 45, 9 },
                    { 670, 2, 45, 10 },
                    { 671, 2, 45, 11 },
                    { 672, 2, 45, 12 },
                    { 673, 2, 45, 13 },
                    { 674, 2, 45, 14 },
                    { 675, 2, 45, 15 },
                    { 676, 2, 46, 1 },
                    { 677, 2, 46, 2 },
                    { 678, 2, 46, 3 },
                    { 679, 2, 46, 4 },
                    { 680, 2, 46, 5 },
                    { 681, 2, 46, 6 },
                    { 682, 2, 46, 7 },
                    { 683, 2, 46, 8 },
                    { 684, 2, 46, 9 },
                    { 685, 2, 46, 10 },
                    { 686, 2, 46, 11 },
                    { 687, 2, 46, 12 },
                    { 688, 2, 46, 13 },
                    { 689, 2, 46, 14 },
                    { 690, 2, 46, 15 },
                    { 691, 2, 47, 1 },
                    { 692, 2, 47, 2 },
                    { 693, 2, 47, 3 },
                    { 694, 2, 47, 4 },
                    { 695, 2, 47, 5 },
                    { 696, 2, 47, 6 },
                    { 697, 2, 47, 7 },
                    { 698, 2, 47, 8 },
                    { 699, 2, 47, 9 },
                    { 700, 2, 47, 10 },
                    { 701, 2, 47, 11 },
                    { 702, 2, 47, 12 },
                    { 703, 2, 47, 13 },
                    { 704, 2, 47, 14 },
                    { 705, 2, 47, 15 },
                    { 706, 2, 48, 1 },
                    { 707, 2, 48, 2 },
                    { 708, 2, 48, 3 },
                    { 709, 2, 48, 4 },
                    { 710, 2, 48, 5 },
                    { 711, 2, 48, 6 },
                    { 712, 2, 48, 7 },
                    { 713, 2, 48, 8 },
                    { 714, 2, 48, 9 },
                    { 715, 2, 48, 10 },
                    { 716, 2, 48, 11 },
                    { 717, 2, 48, 12 },
                    { 718, 2, 48, 13 },
                    { 719, 2, 48, 14 },
                    { 720, 2, 48, 15 },
                    { 721, 2, 49, 1 },
                    { 722, 2, 49, 2 },
                    { 723, 2, 49, 3 },
                    { 724, 2, 49, 4 },
                    { 725, 2, 49, 5 },
                    { 726, 2, 49, 6 },
                    { 727, 2, 49, 7 },
                    { 728, 2, 49, 8 },
                    { 729, 2, 49, 9 },
                    { 730, 2, 49, 10 },
                    { 731, 2, 49, 11 },
                    { 732, 2, 49, 12 },
                    { 733, 2, 49, 13 },
                    { 734, 2, 49, 14 },
                    { 735, 2, 49, 15 },
                    { 736, 2, 50, 1 },
                    { 737, 2, 50, 2 },
                    { 738, 2, 50, 3 },
                    { 739, 2, 50, 4 },
                    { 740, 2, 50, 5 },
                    { 741, 2, 50, 6 },
                    { 742, 2, 50, 7 },
                    { 743, 2, 50, 8 },
                    { 744, 2, 50, 9 },
                    { 745, 2, 50, 10 },
                    { 746, 2, 50, 11 },
                    { 747, 2, 50, 12 },
                    { 748, 2, 50, 13 },
                    { 749, 2, 50, 14 },
                    { 750, 2, 50, 15 },
                    { 751, 2, 51, 1 },
                    { 752, 2, 51, 2 },
                    { 753, 2, 51, 3 },
                    { 754, 2, 51, 4 },
                    { 755, 2, 51, 5 },
                    { 756, 2, 51, 6 },
                    { 757, 2, 51, 7 },
                    { 758, 2, 51, 8 },
                    { 759, 2, 51, 9 },
                    { 760, 2, 51, 10 },
                    { 761, 2, 51, 11 },
                    { 762, 2, 51, 12 },
                    { 763, 2, 51, 13 },
                    { 764, 2, 51, 14 },
                    { 765, 2, 51, 15 },
                    { 766, 2, 52, 1 },
                    { 767, 2, 52, 2 },
                    { 768, 2, 52, 3 },
                    { 769, 2, 52, 4 },
                    { 770, 2, 52, 5 },
                    { 771, 2, 52, 6 },
                    { 772, 2, 52, 7 },
                    { 773, 2, 52, 8 },
                    { 774, 2, 52, 9 },
                    { 775, 2, 52, 10 },
                    { 776, 2, 52, 11 },
                    { 777, 2, 52, 12 },
                    { 778, 2, 52, 13 },
                    { 779, 2, 52, 14 },
                    { 780, 2, 52, 15 },
                    { 781, 2, 53, 1 },
                    { 782, 2, 53, 2 },
                    { 783, 2, 53, 3 },
                    { 784, 2, 53, 4 },
                    { 785, 2, 53, 5 },
                    { 786, 2, 53, 6 },
                    { 787, 2, 53, 7 },
                    { 788, 2, 53, 8 },
                    { 789, 2, 53, 9 },
                    { 790, 2, 53, 10 },
                    { 791, 2, 53, 11 },
                    { 792, 2, 53, 12 },
                    { 793, 2, 53, 13 },
                    { 794, 2, 53, 14 },
                    { 795, 2, 53, 15 },
                    { 796, 2, 54, 1 },
                    { 797, 2, 54, 2 },
                    { 798, 2, 54, 3 },
                    { 799, 2, 54, 4 },
                    { 800, 2, 54, 5 },
                    { 801, 2, 54, 6 },
                    { 802, 2, 54, 7 },
                    { 803, 2, 54, 8 },
                    { 804, 2, 54, 9 },
                    { 805, 2, 54, 10 },
                    { 806, 2, 54, 11 },
                    { 807, 2, 54, 12 },
                    { 808, 2, 54, 13 },
                    { 809, 2, 54, 14 },
                    { 810, 2, 54, 15 },
                    { 811, 2, 55, 1 },
                    { 812, 2, 55, 2 },
                    { 813, 2, 55, 3 },
                    { 814, 2, 55, 4 },
                    { 815, 2, 55, 5 },
                    { 816, 2, 55, 6 },
                    { 817, 2, 55, 7 },
                    { 818, 2, 55, 8 },
                    { 819, 2, 55, 9 },
                    { 820, 2, 55, 10 },
                    { 821, 2, 55, 11 },
                    { 822, 2, 55, 12 },
                    { 823, 2, 55, 13 },
                    { 824, 2, 55, 14 },
                    { 825, 2, 55, 15 },
                    { 826, 2, 56, 1 },
                    { 827, 2, 56, 2 },
                    { 828, 2, 56, 3 },
                    { 829, 2, 56, 4 },
                    { 830, 2, 56, 5 },
                    { 831, 2, 56, 6 },
                    { 832, 2, 56, 7 },
                    { 833, 2, 56, 8 },
                    { 834, 2, 56, 9 },
                    { 835, 2, 56, 10 },
                    { 836, 2, 56, 11 },
                    { 837, 2, 56, 12 },
                    { 838, 2, 56, 13 },
                    { 839, 2, 56, 14 },
                    { 840, 2, 56, 15 },
                    { 841, 2, 57, 1 },
                    { 842, 2, 57, 2 },
                    { 843, 2, 57, 3 },
                    { 844, 2, 57, 4 },
                    { 845, 2, 57, 5 },
                    { 846, 2, 57, 6 },
                    { 847, 2, 57, 7 },
                    { 848, 2, 57, 8 },
                    { 849, 2, 57, 9 },
                    { 850, 2, 57, 10 },
                    { 851, 2, 57, 11 },
                    { 852, 2, 57, 12 },
                    { 853, 2, 57, 13 },
                    { 854, 2, 57, 14 },
                    { 855, 2, 57, 15 },
                    { 856, 2, 58, 1 },
                    { 857, 2, 58, 2 },
                    { 858, 2, 58, 3 },
                    { 859, 2, 58, 4 },
                    { 860, 2, 58, 5 },
                    { 861, 2, 58, 6 },
                    { 862, 2, 58, 7 },
                    { 863, 2, 58, 8 },
                    { 864, 2, 58, 9 },
                    { 865, 2, 58, 10 },
                    { 866, 2, 58, 11 },
                    { 867, 2, 58, 12 },
                    { 868, 2, 58, 13 },
                    { 869, 2, 58, 14 },
                    { 870, 2, 58, 15 },
                    { 871, 2, 59, 1 },
                    { 872, 2, 59, 2 },
                    { 873, 2, 59, 3 },
                    { 874, 2, 59, 4 },
                    { 875, 2, 59, 5 },
                    { 876, 2, 59, 6 },
                    { 877, 2, 59, 7 },
                    { 878, 2, 59, 8 },
                    { 879, 2, 59, 9 },
                    { 880, 2, 59, 10 },
                    { 881, 2, 59, 11 },
                    { 882, 2, 59, 12 },
                    { 883, 2, 59, 13 },
                    { 884, 2, 59, 14 },
                    { 885, 2, 59, 15 },
                    { 886, 2, 60, 1 },
                    { 887, 2, 60, 2 },
                    { 888, 2, 60, 3 },
                    { 889, 2, 60, 4 },
                    { 890, 2, 60, 5 },
                    { 891, 2, 60, 6 },
                    { 892, 2, 60, 7 },
                    { 893, 2, 60, 8 },
                    { 894, 2, 60, 9 },
                    { 895, 2, 60, 10 },
                    { 896, 2, 60, 11 },
                    { 897, 2, 60, 12 },
                    { 898, 2, 60, 13 },
                    { 899, 2, 60, 14 },
                    { 900, 2, 60, 15 },
                    { 901, 2, 61, 1 },
                    { 902, 2, 61, 2 },
                    { 903, 2, 61, 3 },
                    { 904, 2, 61, 4 },
                    { 905, 2, 61, 5 },
                    { 906, 2, 61, 6 },
                    { 907, 2, 61, 7 },
                    { 908, 2, 61, 8 },
                    { 909, 2, 61, 9 },
                    { 910, 2, 61, 10 },
                    { 911, 2, 61, 11 },
                    { 912, 2, 61, 12 },
                    { 913, 2, 61, 13 },
                    { 914, 2, 61, 14 },
                    { 915, 2, 61, 15 },
                    { 916, 2, 62, 1 },
                    { 917, 2, 62, 2 },
                    { 918, 2, 62, 3 },
                    { 919, 2, 62, 4 },
                    { 920, 2, 62, 5 },
                    { 921, 2, 62, 6 },
                    { 922, 2, 62, 7 },
                    { 923, 2, 62, 8 },
                    { 924, 2, 62, 9 },
                    { 925, 2, 62, 10 },
                    { 926, 2, 62, 11 },
                    { 927, 2, 62, 12 },
                    { 928, 2, 62, 13 },
                    { 929, 2, 62, 14 },
                    { 930, 2, 62, 15 },
                    { 931, 2, 63, 1 },
                    { 932, 2, 63, 2 },
                    { 933, 2, 63, 3 },
                    { 934, 2, 63, 4 },
                    { 935, 2, 63, 5 },
                    { 936, 2, 63, 6 },
                    { 937, 2, 63, 7 },
                    { 938, 2, 63, 8 },
                    { 939, 2, 63, 9 },
                    { 940, 2, 63, 10 },
                    { 941, 2, 63, 11 },
                    { 942, 2, 63, 12 },
                    { 943, 2, 63, 13 },
                    { 944, 2, 63, 14 },
                    { 945, 2, 63, 15 },
                    { 946, 2, 64, 1 },
                    { 947, 2, 64, 2 },
                    { 948, 2, 64, 3 },
                    { 949, 2, 64, 4 },
                    { 950, 2, 64, 5 },
                    { 951, 2, 64, 6 },
                    { 952, 2, 64, 7 },
                    { 953, 2, 64, 8 },
                    { 954, 2, 64, 9 },
                    { 955, 2, 64, 10 },
                    { 956, 2, 64, 11 },
                    { 957, 2, 64, 12 },
                    { 958, 2, 64, 13 },
                    { 959, 2, 64, 14 },
                    { 960, 2, 64, 15 },
                    { 961, 2, 65, 1 },
                    { 962, 2, 65, 2 },
                    { 963, 2, 65, 3 },
                    { 964, 2, 65, 4 },
                    { 965, 2, 65, 5 },
                    { 966, 2, 65, 6 },
                    { 967, 2, 65, 7 },
                    { 968, 2, 65, 8 },
                    { 969, 2, 65, 9 },
                    { 970, 2, 65, 10 },
                    { 971, 2, 65, 11 },
                    { 972, 2, 65, 12 },
                    { 973, 2, 65, 13 },
                    { 974, 2, 65, 14 },
                    { 975, 2, 65, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoomId",
                table: "AspNetUsers",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Floors_BlockId",
                table: "Floors",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_RoomId",
                table: "Issues",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_UserId",
                table: "Issues",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueVotes_IssueId",
                table: "IssueVotes",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueVotes_UserId",
                table: "IssueVotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LaundryReservations_SlotId",
                table: "LaundryReservations",
                column: "SlotId");

            migrationBuilder.CreateIndex(
                name: "IX_LaundryReservations_UserId",
                table: "LaundryReservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAssignments_RoomId",
                table: "RoomAssignments",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAssignments_StudentId",
                table: "RoomAssignments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FloorId",
                table: "Rooms",
                column: "FloorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "IssueVotes");

            migrationBuilder.DropTable(
                name: "LaundryReservations");

            migrationBuilder.DropTable(
                name: "RoomAssignments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "LaundrySlots");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Blocks");
        }
    }
}
