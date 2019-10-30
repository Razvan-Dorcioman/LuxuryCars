using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LuxuryCars.Migrations
{
    public partial class TelemetryCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Telemetry",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2019, 10, 23, 14, 22, 36, 720, DateTimeKind.Local).AddTicks(9614));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telemetry",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2019, 10, 19, 23, 20, 37, 635, DateTimeKind.Local).AddTicks(6994));
        }
    }
}
