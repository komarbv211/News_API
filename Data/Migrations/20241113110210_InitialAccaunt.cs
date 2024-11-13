using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialAccaunt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14142855-e262-4715-9295-7171f80e794f",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "LastLoginDate", "SecurityStamp" },
                values: new object[] { "66d3f22e-9b39-4edd-8652-c88676947c73", new DateTime(2024, 11, 13, 11, 2, 9, 73, DateTimeKind.Utc).AddTicks(1300), new DateTime(2024, 11, 13, 11, 2, 9, 73, DateTimeKind.Utc).AddTicks(1304), "879b036d-3be9-467c-959d-a60fc7a3676d" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2024, 11, 13, 13, 2, 9, 73, DateTimeKind.Local).AddTicks(2258));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatePosted",
                value: new DateTime(2024, 11, 13, 13, 2, 9, 73, DateTimeKind.Local).AddTicks(2266));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DatePosted",
                value: new DateTime(2024, 11, 13, 13, 2, 9, 73, DateTimeKind.Local).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2024, 11, 13, 13, 2, 9, 73, DateTimeKind.Local).AddTicks(2081));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2024, 11, 13, 13, 2, 9, 73, DateTimeKind.Local).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2024, 11, 13, 13, 2, 9, 73, DateTimeKind.Local).AddTicks(2165));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14142855-e262-4715-9295-7171f80e794f",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "LastLoginDate", "SecurityStamp" },
                values: new object[] { "ce1f7975-da8d-4ba7-a757-978584bfc316", new DateTime(2024, 11, 8, 19, 44, 50, 107, DateTimeKind.Utc).AddTicks(6298), new DateTime(2024, 11, 8, 19, 44, 50, 107, DateTimeKind.Utc).AddTicks(6302), "ff67cd36-d934-4a62-8ca5-711df972a327" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2024, 11, 8, 21, 44, 50, 107, DateTimeKind.Local).AddTicks(7220));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatePosted",
                value: new DateTime(2024, 11, 8, 21, 44, 50, 107, DateTimeKind.Local).AddTicks(7227));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DatePosted",
                value: new DateTime(2024, 11, 8, 21, 44, 50, 107, DateTimeKind.Local).AddTicks(7234));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2024, 11, 8, 21, 44, 50, 107, DateTimeKind.Local).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2024, 11, 8, 21, 44, 50, 107, DateTimeKind.Local).AddTicks(7147));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2024, 11, 8, 21, 44, 50, 107, DateTimeKind.Local).AddTicks(7151));
        }
    }
}
