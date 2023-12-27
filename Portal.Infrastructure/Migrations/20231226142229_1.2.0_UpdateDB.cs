using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Portal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _120_UpdateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeCreated",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "NOW(6)",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<string>(
                name: "ImageSrcDetail",
                table: "Akces",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "PocetVstupenek",
                table: "Akces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Akces",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Akces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Description", "ImageSrc", "ImageSrcDetail", "Name", "PocetVstupenek", "Price", "Time" },
                values: new object[] { new DateTime(2024, 1, 26, 15, 22, 29, 15, DateTimeKind.Local).AddTicks(3492), "Taylor Swift's Eras Tour", "/img/product/taylor-swift.jpg", "/img/product/taylor-swift-detail.jpg", "Taylor Swift - Eras Tour", 1000, 100.0, new DateTime(2024, 1, 27, 10, 22, 29, 15, DateTimeKind.Local).AddTicks(3542) });

            migrationBuilder.UpdateData(
                table: "Akces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Description", "ImageSrc", "ImageSrcDetail", "Name", "PocetVstupenek", "Price", "Time" },
                values: new object[] { new DateTime(2024, 2, 26, 15, 22, 29, 15, DateTimeKind.Local).AddTicks(3549), "Ed Sheeran's World Tour", "/img/product/ed-sheeran.jpg", "/img/product/ed-sheeran-detail.jpg", "Ed Sheeran - World Tour", 1500, 80.0, new DateTime(2024, 2, 27, 11, 22, 29, 15, DateTimeKind.Local).AddTicks(3551) });

            migrationBuilder.UpdateData(
                table: "Akces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Description", "ImageSrc", "ImageSrcDetail", "Name", "PocetVstupenek", "Price", "Time" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 22, 29, 15, DateTimeKind.Local).AddTicks(3554), "John Mayer's Solo Tour", "/img/product/john-mayer.jpg", "/img/product/john-mayer-detail.jpg", "John Mayer - Solo Tour", 1200, 75.0, new DateTime(2024, 3, 27, 9, 22, 29, 15, DateTimeKind.Local).AddTicks(3556) });

            migrationBuilder.InsertData(
                table: "Akces",
                columns: new[] { "Id", "Date", "Description", "ImageSrc", "ImageSrcDetail", "Name", "PocetVstupenek", "Price", "Time" },
                values: new object[,]
                {
                    { 4, new DateTime(2024, 4, 26, 15, 22, 29, 15, DateTimeKind.Local).AddTicks(3560), "Olivia Rodrigo's Guts Tour", "/img/product/olivia-rodrigo.jpg", "/img/product/olivia-rodrigo-detail.jpg", "Olivia Rodrigo - Guts Tour", 800, 90.0, new DateTime(2024, 4, 27, 12, 22, 29, 15, DateTimeKind.Local).AddTicks(3562) },
                    { 5, new DateTime(2024, 5, 26, 15, 22, 29, 15, DateTimeKind.Local).AddTicks(3565), "Gracie Abrams' Acoustic Showcase", "/img/product/gracie-abrams.jpg", "/img/product/gracie-abrams-detail.jpg", "Gracie Abrams - Acoustic Showcase", 900, 60.0, new DateTime(2024, 5, 27, 8, 22, 29, 15, DateTimeKind.Local).AddTicks(3567) }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "AkceID", "Komentar", "UserID" },
                values: new object[,]
                {
                    { 1, 1, "První komentář k akci 1.", 1 },
                    { 2, 1, "Druhý komentář k akci 1.", 2 },
                    { 3, 2, "Komentář k akci 2.", 3 }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "Request", "Solved" },
                values: new object[,]
                {
                    { 1, "První žádost na admina.", false },
                    { 2, "Druhá žádost na admina.", true },
                    { 3, "Třetí žádost na admina.", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Akces",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Akces",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ImageSrcDetail",
                table: "Akces");

            migrationBuilder.DropColumn(
                name: "PocetVstupenek",
                table: "Akces");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Akces");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeCreated",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "NOW(6)");

            migrationBuilder.UpdateData(
                table: "Akces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Description", "ImageSrc", "Name", "Price" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jídlo", "/img/product/produkty-01.jpg", "Rohlík", 2.0 });

            migrationBuilder.UpdateData(
                table: "Akces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Description", "ImageSrc", "Name", "Price" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nejlepší chleba", "/img/product/produkty-02.jpg", "Chleba", 30.0 });

            migrationBuilder.UpdateData(
                table: "Akces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Description", "ImageSrc", "Name", "Price" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vánoce", "/img/product/produkty-03.jpg", "Vánočka", 60.0 });
        }
    }
}
