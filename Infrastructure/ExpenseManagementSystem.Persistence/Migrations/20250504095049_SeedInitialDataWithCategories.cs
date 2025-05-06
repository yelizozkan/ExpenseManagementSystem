using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpenseManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialDataWithCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                schema: "table",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "table",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "table",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                schema: "table",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "table",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "table",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AspNetUsers_ApprovedById",
                schema: "table",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AspNetUsers_UserId",
                schema: "table",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Expenses_ExpenseId",
                schema: "table",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "table");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                schema: "table",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                schema: "table",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "TransactionReference",
                schema: "table",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                schema: "table",
                table: "ExpenseStatuses");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                schema: "table",
                table: "Expenses");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "table",
                newName: "UserRoles",
                newSchema: "table");

            migrationBuilder.RenameColumn(
                name: "ExpenseId",
                schema: "table",
                table: "Payments",
                newName: "ExpenditureId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_ExpenseId",
                schema: "table",
                table: "Payments",
                newName: "IX_Payments_ExpenditureId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "table",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                schema: "table",
                table: "Payments",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                schema: "table",
                table: "Expenses",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                schema: "table",
                table: "Expenses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxAmount",
                schema: "table",
                table: "Expenditures",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                schema: "table",
                table: "Expenditures",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<long>(
                name: "PaymentId",
                schema: "table",
                table: "Expenditures",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                schema: "table",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

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
                    IBAN = table.Column<string>(type: "text", nullable: false),
                    DepartmentName = table.Column<string>(type: "text", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false),
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

            migrationBuilder.InsertData(
                schema: "table",
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "CreatedDateOnly", "Description", "IsActive", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate", "UpdatedDateOnly" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2025, 5, 4, 9, 50, 48, 930, DateTimeKind.Utc).AddTicks(8903), new DateOnly(2025, 5, 4), "Business travel and transportation", true, false, "Travel", null, new DateTime(2025, 5, 4, 9, 50, 48, 930, DateTimeKind.Utc).AddTicks(8906), new DateOnly(2025, 5, 4) },
                    { 2L, null, new DateTime(2025, 5, 4, 9, 50, 48, 930, DateTimeKind.Utc).AddTicks(8911), new DateOnly(2025, 5, 4), "Food and beverages during work", true, false, "Meals", null, new DateTime(2025, 5, 4, 9, 50, 48, 930, DateTimeKind.Utc).AddTicks(8912), new DateOnly(2025, 5, 4) },
                    { 3L, null, new DateTime(2025, 5, 4, 9, 50, 48, 930, DateTimeKind.Utc).AddTicks(8915), new DateOnly(2025, 5, 4), "Stationery and work materials", true, false, "Office Supplies", null, new DateTime(2025, 5, 4, 9, 50, 48, 930, DateTimeKind.Utc).AddTicks(8916), new DateOnly(2025, 5, 4) }
                });

            migrationBuilder.InsertData(
                schema: "table",
                table: "ExpenseStatuses",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "CreatedDateOnly", "Description", "IsActive", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate", "UpdatedDateOnly" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2025, 5, 4, 9, 50, 48, 875, DateTimeKind.Utc).AddTicks(9301), new DateOnly(2025, 5, 4), "Expense is waiting for approval", true, false, "Pending", null, new DateTime(2025, 5, 4, 9, 50, 48, 875, DateTimeKind.Utc).AddTicks(9306), new DateOnly(2025, 5, 4) },
                    { 2L, null, new DateTime(2025, 5, 4, 9, 50, 48, 875, DateTimeKind.Utc).AddTicks(9315), new DateOnly(2025, 5, 4), "Expense has been approved", true, false, "Approved", null, new DateTime(2025, 5, 4, 9, 50, 48, 875, DateTimeKind.Utc).AddTicks(9315), new DateOnly(2025, 5, 4) },
                    { 3L, null, new DateTime(2025, 5, 4, 9, 50, 48, 875, DateTimeKind.Utc).AddTicks(9317), new DateOnly(2025, 5, 4), "Expense has been rejected", true, false, "Rejected", null, new DateTime(2025, 5, 4, 9, 50, 48, 875, DateTimeKind.Utc).AddTicks(9317), new DateOnly(2025, 5, 4) }
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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DepartmentName", "Email", "EmailConfirmed", "FirstName", "IBAN", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Position", "RefreshToken", "RefreshTokenEndDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1L, 0, "533ed0e5-245f-4c6b-a736-306d1023c760", "Management", "admin@company.com", true, "System", "TR000000000000000000000000", "Administrator", false, null, "ADMIN@COMPANY.COM", "ADMIN@COMPANY.COM", "AQAAAAIAAYagAAAAEJOx4AhGHYeW2Er7Vri1UNvBzUZdyVx7+mz2ByC/L0crqhRU7OyDTiRKKYRh3IAR9g==", null, false, "Admin", null, null, "149be89e-e049-461f-b837-76dcd97625a3", false, "admin@company.com" });

            migrationBuilder.InsertData(
                schema: "table",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1L, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryId",
                schema: "table",
                table: "Expenses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "table",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_Roles_RoleId",
                schema: "table",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalSchema: "table",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_Users_UserId",
                schema: "table",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "table",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_Users_UserId",
                schema: "table",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "table",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_Users_UserId",
                schema: "table",
                table: "AspNetUserTokens",
                column: "UserId",
                principalSchema: "table",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Categories_CategoryId",
                schema: "table",
                table: "Expenses",
                column: "CategoryId",
                principalSchema: "table",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_ApprovedById",
                schema: "table",
                table: "Expenses",
                column: "ApprovedById",
                principalSchema: "table",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_UserId",
                schema: "table",
                table: "Expenses",
                column: "UserId",
                principalSchema: "table",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Expenditures_ExpenditureId",
                schema: "table",
                table: "Payments",
                column: "ExpenditureId",
                principalSchema: "table",
                principalTable: "Expenditures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                schema: "table",
                table: "UserRoles",
                column: "RoleId",
                principalSchema: "table",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                schema: "table",
                table: "UserRoles",
                column: "UserId",
                principalSchema: "table",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_Roles_RoleId",
                schema: "table",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_Users_UserId",
                schema: "table",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_Users_UserId",
                schema: "table",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_Users_UserId",
                schema: "table",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Categories_CategoryId",
                schema: "table",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_ApprovedById",
                schema: "table",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_UserId",
                schema: "table",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Expenditures_ExpenditureId",
                schema: "table",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                schema: "table",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                schema: "table",
                table: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "table");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "table");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CategoryId",
                schema: "table",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                schema: "table",
                table: "UserRoles");

            migrationBuilder.DeleteData(
                schema: "table",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "table",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "table",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "table",
                table: "ExpenseStatuses",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "table",
                table: "ExpenseStatuses",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "table",
                table: "ExpenseStatuses",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "table",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "table",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                schema: "table",
                table: "Expenditures");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "table",
                newName: "AspNetUserRoles",
                newSchema: "table");

            migrationBuilder.RenameColumn(
                name: "ExpenditureId",
                schema: "table",
                table: "Payments",
                newName: "ExpenseId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_ExpenditureId",
                schema: "table",
                table: "Payments",
                newName: "IX_Payments_ExpenseId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                schema: "table",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                schema: "table",
                table: "Payments",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                schema: "table",
                table: "Payments",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TransactionReference",
                schema: "table",
                table: "Payments",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                schema: "table",
                table: "ExpenseStatuses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                schema: "table",
                table: "Expenses",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AddColumn<long>(
                name: "PaymentId",
                schema: "table",
                table: "Expenses",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxAmount",
                schema: "table",
                table: "Expenditures",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                schema: "table",
                table: "Expenditures",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                schema: "table",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "table",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "table",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    DepartmentName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    IBAN = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "table",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "table",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "table",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                schema: "table",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalSchema: "table",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "table",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "table",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "table",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "table",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                schema: "table",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalSchema: "table",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "table",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "table",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "table",
                table: "AspNetUserTokens",
                column: "UserId",
                principalSchema: "table",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AspNetUsers_ApprovedById",
                schema: "table",
                table: "Expenses",
                column: "ApprovedById",
                principalSchema: "table",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AspNetUsers_UserId",
                schema: "table",
                table: "Expenses",
                column: "UserId",
                principalSchema: "table",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Expenses_ExpenseId",
                schema: "table",
                table: "Payments",
                column: "ExpenseId",
                principalSchema: "table",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
