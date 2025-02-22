using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class seedingdiffictultyandregion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Level" },
                values: new object[,]
                {
                    { new Guid("3d7a44c7-ee8e-42db-9d92-0e47e8e9f0cd"), "Hard" },
                    { new Guid("49f69dc5-b326-440f-ac88-baecc5d18cb2"), "Mid" },
                    { new Guid("d23b6401-144d-4350-b6ff-8225e05dfea7"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[] { new Guid("69733ddb-7720-4bee-8159-33639e6663c1"), "NYC", "New York", "drugs&shit.org" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3d7a44c7-ee8e-42db-9d92-0e47e8e9f0cd"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("49f69dc5-b326-440f-ac88-baecc5d18cb2"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d23b6401-144d-4350-b6ff-8225e05dfea7"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("69733ddb-7720-4bee-8159-33639e6663c1"));
        }
    }
}
