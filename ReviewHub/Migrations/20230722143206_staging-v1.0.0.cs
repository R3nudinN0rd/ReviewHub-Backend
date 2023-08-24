using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewHub.Migrations
{
    /// <inheritdoc />
    public partial class stagingv100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 22, 17, 32, 6, 254, DateTimeKind.Local).AddTicks(5589));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 22, 17, 32, 6, 254, DateTimeKind.Local).AddTicks(5613));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 22, 17, 32, 6, 254, DateTimeKind.Local).AddTicks(5621));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 22, 10, 10, 35, 504, DateTimeKind.Local).AddTicks(5741));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 22, 10, 10, 35, 504, DateTimeKind.Local).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 22, 10, 10, 35, 504, DateTimeKind.Local).AddTicks(5776));
        }
    }
}
