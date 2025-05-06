using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IBAN",
                schema: "table",
                table: "Users",
                newName: "Iban");

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "CreatedDateOnly", "UpdatedDate", "UpdatedDateOnly" },
                values: new object[] { new DateTime(2025, 5, 5, 12, 53, 15, 722, DateTimeKind.Utc).AddTicks(7417), new DateOnly(2025, 5, 5), new DateTime(2025, 5, 5, 12, 53, 15, 722, DateTimeKind.Utc).AddTicks(7422), new DateOnly(2025, 5, 5) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "CreatedDateOnly", "UpdatedDate", "UpdatedDateOnly" },
                values: new object[] { new DateTime(2025, 5, 5, 12, 53, 15, 722, DateTimeKind.Utc).AddTicks(7428), new DateOnly(2025, 5, 5), new DateTime(2025, 5, 5, 12, 53, 15, 722, DateTimeKind.Utc).AddTicks(7428), new DateOnly(2025, 5, 5) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "CreatedDateOnly", "UpdatedDate", "UpdatedDateOnly" },
                values: new object[] { new DateTime(2025, 5, 5, 12, 53, 15, 722, DateTimeKind.Utc).AddTicks(7430), new DateOnly(2025, 5, 5), new DateTime(2025, 5, 5, 12, 53, 15, 722, DateTimeKind.Utc).AddTicks(7431), new DateOnly(2025, 5, 5) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "ExpenseStatuses",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "CreatedDateOnly", "UpdatedDate", "UpdatedDateOnly" },
                values: new object[] { new DateTime(2025, 5, 5, 12, 53, 15, 605, DateTimeKind.Utc).AddTicks(8898), new DateOnly(2025, 5, 5), new DateTime(2025, 5, 5, 12, 53, 15, 605, DateTimeKind.Utc).AddTicks(8901), new DateOnly(2025, 5, 5) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "ExpenseStatuses",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "CreatedDateOnly", "UpdatedDate", "UpdatedDateOnly" },
                values: new object[] { new DateTime(2025, 5, 5, 12, 53, 15, 605, DateTimeKind.Utc).AddTicks(8910), new DateOnly(2025, 5, 5), new DateTime(2025, 5, 5, 12, 53, 15, 605, DateTimeKind.Utc).AddTicks(8910), new DateOnly(2025, 5, 5) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "ExpenseStatuses",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "CreatedDateOnly", "UpdatedDate", "UpdatedDateOnly" },
                values: new object[] { new DateTime(2025, 5, 5, 12, 53, 15, 605, DateTimeKind.Utc).AddTicks(8912), new DateOnly(2025, 5, 5), new DateTime(2025, 5, 5, 12, 53, 15, 605, DateTimeKind.Utc).AddTicks(8912), new DateOnly(2025, 5, 5) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82d8892f-890e-40be-9967-a4581f60f5cf", "AQAAAAIAAYagAAAAEAVcg77LpUO6Wjidfg7lkn17cgRBqulS3IsISzDDTGAY3ROgPKS8KbTwGnf4r7xy2Q==", "36e28d0d-9994-409e-90c9-adce32303462" });

            migrationBuilder.InsertData(
                schema: "table",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DepartmentName", "Email", "EmailConfirmed", "FirstName", "Iban", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Position", "RefreshToken", "RefreshTokenEndDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2L, 0, "671d14d6-77a4-421d-992f-5d27cf87a3f5", "Muhasebe", "personel@company.com", true, "Ali", "TR111111111111111111111111", "Yılmaz", false, null, "PERSONEL@COMPANY.COM", "PERSONEL@COMPANY.COM", "AQAAAAIAAYagAAAAEGGTT6606CLM+03MhM0qcuyVRUngk2F8uFLuUPZnxGRg9tsUH1UW4aQqFMmBfFYQJQ==", null, false, "Personel", null, null, "f4c163bf-48c9-4397-8b20-2ba0b3f5b759", false, "personel@company.com" });

            migrationBuilder.InsertData(
                schema: "table",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 2L, 2L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "table",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2L, 2L });

            migrationBuilder.DeleteData(
                schema: "table",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.RenameColumn(
                name: "Iban",
                schema: "table",
                table: "Users",
                newName: "IBAN");

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "CreatedDateOnly", "UpdatedDate", "UpdatedDateOnly" },
                values: new object[] { new DateTime(2025, 5, 4, 9, 50, 48, 930, DateTimeKind.Utc).AddTicks(8903), new DateOnly(2025, 5, 4), new DateTime(2025, 5, 4, 9, 50, 48, 930, DateTimeKind.Utc).AddTicks(8906), new DateOnly(2025, 5, 4) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "CreatedDateOnly", "UpdatedDate", "UpdatedDateOnly" },
                values: new object[] { new DateTime(2025, 5, 4, 9, 50, 48, 930, DateTimeKind.Utc).AddTicks(8911), new DateOnly(2025, 5, 4), new DateTime(2025, 5, 4, 9, 50, 48, 930, DateTimeKind.Utc).AddTicks(8912), new DateOnly(2025, 5, 4) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "CreatedDateOnly", "UpdatedDate", "UpdatedDateOnly" },
                values: new object[] { new DateTime(2025, 5, 4, 9, 50, 48, 930, DateTimeKind.Utc).AddTicks(8915), new DateOnly(2025, 5, 4), new DateTime(2025, 5, 4, 9, 50, 48, 930, DateTimeKind.Utc).AddTicks(8916), new DateOnly(2025, 5, 4) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "ExpenseStatuses",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "CreatedDateOnly", "UpdatedDate", "UpdatedDateOnly" },
                values: new object[] { new DateTime(2025, 5, 4, 9, 50, 48, 875, DateTimeKind.Utc).AddTicks(9301), new DateOnly(2025, 5, 4), new DateTime(2025, 5, 4, 9, 50, 48, 875, DateTimeKind.Utc).AddTicks(9306), new DateOnly(2025, 5, 4) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "ExpenseStatuses",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "CreatedDateOnly", "UpdatedDate", "UpdatedDateOnly" },
                values: new object[] { new DateTime(2025, 5, 4, 9, 50, 48, 875, DateTimeKind.Utc).AddTicks(9315), new DateOnly(2025, 5, 4), new DateTime(2025, 5, 4, 9, 50, 48, 875, DateTimeKind.Utc).AddTicks(9315), new DateOnly(2025, 5, 4) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "ExpenseStatuses",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "CreatedDateOnly", "UpdatedDate", "UpdatedDateOnly" },
                values: new object[] { new DateTime(2025, 5, 4, 9, 50, 48, 875, DateTimeKind.Utc).AddTicks(9317), new DateOnly(2025, 5, 4), new DateTime(2025, 5, 4, 9, 50, 48, 875, DateTimeKind.Utc).AddTicks(9317), new DateOnly(2025, 5, 4) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "533ed0e5-245f-4c6b-a736-306d1023c760", "AQAAAAIAAYagAAAAEJOx4AhGHYeW2Er7Vri1UNvBzUZdyVx7+mz2ByC/L0crqhRU7OyDTiRKKYRh3IAR9g==", "149be89e-e049-461f-b837-76dcd97625a3" });
        }
    }
}
