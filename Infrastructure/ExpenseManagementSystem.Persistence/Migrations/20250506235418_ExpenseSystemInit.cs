using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpenseManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ExpenseSystemInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "table");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "table",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateOnly = table.Column<DateOnly>(type: "date", nullable: true),
                    UpdatedDateOnly = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseStatuses",
                schema: "table",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateOnly = table.Column<DateOnly>(type: "date", nullable: true),
                    UpdatedDateOnly = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "table",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "table",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Iban = table.Column<string>(type: "text", nullable: true),
                    DepartmentName = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "table",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "table",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "table",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "table",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "table",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "table",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                schema: "table",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    Total = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateOnly = table.Column<DateOnly>(type: "date", nullable: true),
                    UpdatedDateOnly = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "table",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_ExpenseStatuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "table",
                        principalTable: "ExpenseStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "table",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "table",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "table",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "table",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenditures",
                schema: "table",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpenseId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ReceiptFilePath = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ReceiptNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ApprovedById = table.Column<long>(type: "bigint", nullable: true),
                    ApprovalNote = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    PaymentId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateOnly = table.Column<DateOnly>(type: "date", nullable: true),
                    UpdatedDateOnly = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenditures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenditures_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "table",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenditures_ExpenseStatuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "table",
                        principalTable: "ExpenseStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenditures_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalSchema: "table",
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenditures_Users_ApprovedById",
                        column: x => x.ApprovedById,
                        principalSchema: "table",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "table",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TargetIban = table.Column<string>(type: "character varying(26)", maxLength: 26, nullable: false),
                    ExpenditureId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateOnly = table.Column<DateOnly>(type: "date", nullable: true),
                    UpdatedDateOnly = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Expenditures_ExpenditureId",
                        column: x => x.ExpenditureId,
                        principalSchema: "table",
                        principalTable: "Expenditures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "table",
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "CreatedDateOnly", "Description", "IsActive", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate", "UpdatedDateOnly" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2025, 5, 6, 23, 54, 18, 82, DateTimeKind.Utc).AddTicks(5161), new DateOnly(2025, 5, 6), "Business travel and transportation", true, false, "Travel", null, new DateTime(2025, 5, 6, 23, 54, 18, 82, DateTimeKind.Utc).AddTicks(5170), new DateOnly(2025, 5, 6) },
                    { 2L, null, new DateTime(2025, 5, 6, 23, 54, 18, 82, DateTimeKind.Utc).AddTicks(5180), new DateOnly(2025, 5, 6), "Food and beverages during work", true, false, "Meals", null, new DateTime(2025, 5, 6, 23, 54, 18, 82, DateTimeKind.Utc).AddTicks(5181), new DateOnly(2025, 5, 6) },
                    { 3L, null, new DateTime(2025, 5, 6, 23, 54, 18, 82, DateTimeKind.Utc).AddTicks(5184), new DateOnly(2025, 5, 6), "Stationery and work materials", true, false, "Office Supplies", null, new DateTime(2025, 5, 6, 23, 54, 18, 82, DateTimeKind.Utc).AddTicks(5184), new DateOnly(2025, 5, 6) }
                });

            migrationBuilder.InsertData(
                schema: "table",
                table: "ExpenseStatuses",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "CreatedDateOnly", "Description", "IsActive", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate", "UpdatedDateOnly" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2025, 5, 6, 23, 54, 17, 959, DateTimeKind.Utc).AddTicks(4694), new DateOnly(2025, 5, 6), "Expense is waiting for approval", true, false, "Pending", null, new DateTime(2025, 5, 6, 23, 54, 17, 959, DateTimeKind.Utc).AddTicks(4698), new DateOnly(2025, 5, 6) },
                    { 2L, null, new DateTime(2025, 5, 6, 23, 54, 17, 959, DateTimeKind.Utc).AddTicks(4708), new DateOnly(2025, 5, 6), "Expense has been approved", true, false, "Approved", null, new DateTime(2025, 5, 6, 23, 54, 17, 959, DateTimeKind.Utc).AddTicks(4708), new DateOnly(2025, 5, 6) },
                    { 3L, null, new DateTime(2025, 5, 6, 23, 54, 17, 959, DateTimeKind.Utc).AddTicks(4710), new DateOnly(2025, 5, 6), "Expense has been rejected", true, false, "Rejected", null, new DateTime(2025, 5, 6, 23, 54, 17, 959, DateTimeKind.Utc).AddTicks(4710), new DateOnly(2025, 5, 6) }
                });

            migrationBuilder.InsertData(
                schema: "table",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1L, null, "Admin", "ADMIN" },
                    { 2L, null, "Personnel", "PERSONNEL" }
                });

            migrationBuilder.InsertData(
                schema: "table",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DepartmentName", "Email", "EmailConfirmed", "FirstName", "Iban", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Position", "RefreshToken", "RefreshTokenEndDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1L, 0, "83b82586-b020-45ab-ab50-0fbfbcad65ec", "Management", "admin@company.com", true, "System", "TR000000000000000000000000", "Administrator", false, null, "ADMIN@COMPANY.COM", "ADMIN@COMPANY.COM", "AQAAAAIAAYagAAAAEFF5ZYQ3XTT3f/Al+VmHbVvULpq2pTGDjA0fHaTM44d3d1JeKOPrOBU0BZqSbtSOaA==", null, false, "Admin", null, null, "17ef8889-5743-4989-bde2-fcc78efc5636", false, "admin@company.com" },
                    { 2L, 0, "d1e0a13d-ea5b-4eb8-9c12-40879d0868d6", "Muhasebe", "personel@company.com", true, "Ali", "TR111111111111111111111111", "Yılmaz", false, null, "PERSONEL@COMPANY.COM", "PERSONEL@COMPANY.COM", "AQAAAAIAAYagAAAAEGH7pvi5TRnOLA1Er6sfpc8xLxr9J+Hz/JDn2QYAQvj0sf9zThEN3Q0PSDy2D4j+gw==", null, false, "Personel", null, null, "8150ba94-aaed-4896-beea-55795f4e4e74", false, "personel@company.com" }
                });

            migrationBuilder.InsertData(
                schema: "table",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 2L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "table",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "table",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "table",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_ApprovedById",
                schema: "table",
                table: "Expenditures",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_CategoryId",
                schema: "table",
                table: "Expenditures",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_ExpenseId",
                schema: "table",
                table: "Expenditures",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_StatusId",
                schema: "table",
                table: "Expenditures",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryId",
                schema: "table",
                table: "Expenses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_StatusId",
                schema: "table",
                table: "Expenses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_UserId",
                schema: "table",
                table: "Expenses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ExpenditureId",
                schema: "table",
                table: "Payments",
                column: "ExpenditureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "table",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "table",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "table",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "table",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "table");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "table");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "table");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "table");

            migrationBuilder.DropTable(
                name: "Payments",
                schema: "table");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "table");

            migrationBuilder.DropTable(
                name: "Expenditures",
                schema: "table");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "table");

            migrationBuilder.DropTable(
                name: "Expenses",
                schema: "table");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "table");

            migrationBuilder.DropTable(
                name: "ExpenseStatuses",
                schema: "table");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "table");
        }
    }
}
