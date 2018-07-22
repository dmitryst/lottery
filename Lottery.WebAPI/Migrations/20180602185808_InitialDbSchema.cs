using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lottery.WebAPI.Migrations
{
    public partial class InitialDbSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lotteries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    DateOfConducting = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotteries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Number = table.Column<string>(maxLength: 7, nullable: false),
                    IsWinning = table.Column<bool>(nullable: false),
                    LotteryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Lotteries_LotteryId",
                        column: x => x.LotteryId,
                        principalTable: "Lotteries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Lotteries",
                columns: new[] { "Id", "DateOfConducting", "Number" },
                values: new object[] { 1, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "101" });

            migrationBuilder.InsertData(
                table: "Lotteries",
                columns: new[] { "Id", "DateOfConducting", "Number" },
                values: new object[] { 2, new DateTime(2018, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "102" });

            migrationBuilder.InsertData(
                table: "Lotteries",
                columns: new[] { "Id", "DateOfConducting", "Number" },
                values: new object[] { 3, new DateTime(2018, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "103" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "IsWinning", "LotteryId", "Number" },
                values: new object[,]
                {
                    { 1, false, 1, "AS7239G" },
                    { 2, false, 1, "AL7249J" },
                    { 3, true, 1, "BS7K3LP" },
                    { 4, false, 2, "9L7Y69G" },
                    { 5, true, 2, "AY7739U" },
                    { 6, false, 2, "A8MN390" },
                    { 7, true, 3, "Z888399" },
                    { 8, false, 3, "Z677392" },
                    { 9, false, 3, "3607391" },
                    { 10, false, 3, "08J8K19" }
                });

            migrationBuilder.CreateIndex(
                name: "INX_NUMBER",
                table: "Lotteries",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "INX_NUMBER",
                table: "Tickets",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_LotteryId_Number",
                table: "Tickets",
                columns: new[] { "LotteryId", "Number" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Lotteries");
        }
    }
}
