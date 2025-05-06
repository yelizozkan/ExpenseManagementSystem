using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddIsApprovedForPaymentToExpenditure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Position",
                schema: "table",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Iban",
                schema: "table",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                schema: "table",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<bool>(
                name: "IsApprovedForPayment",
                schema: "table",
                table: "Expenditures",
                type: "boolean",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 16, 34, 55, 339, DateTimeKind.Utc).AddTicks(8656), new DateTime(2025, 5, 5, 16, 34, 55, 339, DateTimeKind.Utc).AddTicks(8660) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 16, 34, 55, 339, DateTimeKind.Utc).AddTicks(8667), new DateTime(2025, 5, 5, 16, 34, 55, 339, DateTimeKind.Utc).AddTicks(8667) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 16, 34, 55, 339, DateTimeKind.Utc).AddTicks(8670), new DateTime(2025, 5, 5, 16, 34, 55, 339, DateTimeKind.Utc).AddTicks(8670) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "ExpenseStatuses",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 16, 34, 55, 227, DateTimeKind.Utc).AddTicks(6420), new DateTime(2025, 5, 5, 16, 34, 55, 227, DateTimeKind.Utc).AddTicks(6428) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "ExpenseStatuses",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 16, 34, 55, 227, DateTimeKind.Utc).AddTicks(6435), new DateTime(2025, 5, 5, 16, 34, 55, 227, DateTimeKind.Utc).AddTicks(6435) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "ExpenseStatuses",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 5, 5, 16, 34, 55, 227, DateTimeKind.Utc).AddTicks(6437), new DateTime(2025, 5, 5, 16, 34, 55, 227, DateTimeKind.Utc).AddTicks(6437) });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6dd6011-f643-4134-93b8-16956865686a", "AQAAAAIAAYagAAAAEOwoa/47YTsQEcY42OI2VPe4FAGjiKE5N+LtJ2EBrknznU9wiyKyyrPePtO6j9dL0Q==", "d9b63c9b-4207-4011-b378-f338c38782ec" });

            migrationBuilder.UpdateData(
                schema: "table",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4590660-4d0c-48aa-96f8-d7709f8edf35", "AQAAAAIAAYagAAAAEFCG/NoK42tn2urNLIazYOuL7gbYvx9vqaD3UMfsozzAMzJg50ivzCj3P9YjA6rCDg==", "4f10ed65-4861-4523-b6e4-6567dd2059dc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApprovedForPayment",
                schema: "table",
                table: "Expenditures");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                schema: "table",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Iban",
                schema: "table",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                schema: "table",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
    }
}
