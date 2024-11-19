using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class seedingdatafordiffultiesandregions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("45fde8b6-8e73-4d66-8e26-506d3e14704b"), "Medium" },
                    { new Guid("57486005-9ed6-46d9-9a1b-05d25a1b9285"), "Hard" },
                    { new Guid("61bc18fd-e87f-4639-8afa-6e93ec0e5e8e"), "Easy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("45fde8b6-8e73-4d66-8e26-506d3e14704b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("57486005-9ed6-46d9-9a1b-05d25a1b9285"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("61bc18fd-e87f-4639-8afa-6e93ec0e5e8e"));
        }
    }
}
