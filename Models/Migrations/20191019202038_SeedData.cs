using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LuxuryCars.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "OrderNumber", "UserId" },
                values: new object[] { 1, new DateTime(2019, 10, 19, 23, 20, 37, 635, DateTimeKind.Local).AddTicks(6994), "12345", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
