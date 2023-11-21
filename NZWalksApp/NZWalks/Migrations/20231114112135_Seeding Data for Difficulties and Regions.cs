using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("149d4cfa-347f-46ee-abd3-e33f9197fd2e"), "Hard" },
                    { new Guid("48fbe5c5-1f55-4545-a360-6dd6a0414a4f"), "Medium" },
                    { new Guid("dd4c0950-fb61-4c20-8b5b-70592aafc614"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[] { new Guid("a6396964-9e21-45e5-a9d4-6ff284112164"), "AWL", "Auckland", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.newzealand.com%2Fassets%2FTourism-NZ%2FAuckland%2F98618569ff%2Fimg-1536065871-6217-4403-p-10D1D0BD-B88E-AAB3-AE3F2E903EF65717-2544003__aWxvdmVrZWxseQo_CropResizeWzEyMDAsNjMwLDc1LCJqcGciXQ.jpg&tbnid=afMD--rWiAoJ1M&vet=12ahUKEwiA3NmT98KCAxWffWwGHWF3DWoQMygBegQIARBv..i&imgrefurl=https%3A%2F%2Fwww.newzealand.com%2Fin%2Fauckland%2F&docid=LplqmIiu5MkpZM&w=1200&h=630&q=auckland&ved=2ahUKEwiA3NmT98KCAxWffWwGHWF3DWoQMygBegQIARBv" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("149d4cfa-347f-46ee-abd3-e33f9197fd2e"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("48fbe5c5-1f55-4545-a360-6dd6a0414a4f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("dd4c0950-fb61-4c20-8b5b-70592aafc614"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a6396964-9e21-45e5-a9d4-6ff284112164"));
        }
    }
}
