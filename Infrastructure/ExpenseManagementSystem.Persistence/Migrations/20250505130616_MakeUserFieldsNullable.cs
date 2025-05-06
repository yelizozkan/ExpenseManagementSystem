using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MakeUserFieldsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "table",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 13, 6, 15, 347, DateTimeKind.Utc).AddTicks(8760), new DateTime(2025, 5, 5, 13, 6, 15, 347, DateTimeKind.Utc).AddTicks(8765) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 13, 6, 15, 347, DateTimeKind.Utc).AddTicks(8771), new DateTime(2025, 5, 5, 13, 6, 15, 347, DateTimeKind.Utc).AddTicks(8771) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 13, 6, 15, 347, DateTimeKind.Utc).AddTicks(8774), new DateTime(2025, 5, 5, 13, 6, 15, 347, DateTimeKind.Utc).AddTicks(8774) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "ExpenseStatuses",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 13, 6, 15, 205, DateTimeKind.Utc).AddTicks(5109), new DateTime(2025, 5, 5, 13, 6, 15, 205, DateTimeKind.Utc).AddTicks(5112) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "ExpenseStatuses",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 13, 6, 15, 205, DateTimeKind.Utc).AddTicks(5119), new DateTime(2025, 5, 5, 13, 6, 15, 205, DateTimeKind.Utc).AddTicks(5119) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "ExpenseStatuses",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 13, 6, 15, 205, DateTimeKind.Utc).AddTicks(5121), new DateTime(2025, 5, 5, 13, 6, 15, 205, DateTimeKind.Utc).AddTicks(5121) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6573ac3-b245-41fe-b253-877c1bbe807f", "AQAAAAIAAYagAAAAEOAQi1ZpMTuAa7x+aoJpIczMDD36AxNsTrQ3xrlz0YbF92yUZUGsfgye/BYCDDG1dA==", "075f12f9-bce8-4966-a591-a295eca56b8c" });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "475d7d14-af2a-4f8c-b877-805034aac42f", "AQAAAAIAAYagAAAAEHpoyQXzBAV9ofOlqpwm7t7NmkZLTt/+WzcfCCfakKxZphv9dpwVMQ2KKh6FgmM3KQ==", "b1c9cf4c-fb77-4aef-a39c-c2dda24c93ee" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "table",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 12, 53, 15, 722, DateTimeKind.Utc).AddTicks(7417), new DateTime(2025, 5, 5, 12, 53, 15, 722, DateTimeKind.Utc).AddTicks(7422) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 12, 53, 15, 722, DateTimeKind.Utc).AddTicks(7428), new DateTime(2025, 5, 5, 12, 53, 15, 722, DateTimeKind.Utc).AddTicks(7428) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 12, 53, 15, 722, DateTimeKind.Utc).AddTicks(7430), new DateTime(2025, 5, 5, 12, 53, 15, 722, DateTimeKind.Utc).AddTicks(7431) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "ExpenseStatuses",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 12, 53, 15, 605, DateTimeKind.Utc).AddTicks(8898), new DateTime(2025, 5, 5, 12, 53, 15, 605, DateTimeKind.Utc).AddTicks(8901) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "ExpenseStatuses",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 12, 53, 15, 605, DateTimeKind.Utc).AddTicks(8910), new DateTime(2025, 5, 5, 12, 53, 15, 605, DateTimeKind.Utc).AddTicks(8910) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "ExpenseStatuses",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 12, 53, 15, 605, DateTimeKind.Utc).AddTicks(8912), new DateTime(2025, 5, 5, 12, 53, 15, 605, DateTimeKind.Utc).AddTicks(8912) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82d8892f-890e-40be-9967-a4581f60f5cf", "AQAAAAIAAYagAAAAEAVcg77LpUO6Wjidfg7lkn17cgRBqulS3IsISzDDTGAY3ROgPKS8KbTwGnf4r7xy2Q==", "36e28d0d-9994-409e-90c9-adce32303462" });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "671d14d6-77a4-421d-992f-5d27cf87a3f5", "AQAAAAIAAYagAAAAEGGTT6606CLM+03MhM0qcuyVRUngk2F8uFLuUPZnxGRg9tsUH1UW4aQqFMmBfFYQJQ==", "f4c163bf-48c9-4397-8b20-2ba0b3f5b759" });
        }
    }
}
