using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EGWalks.API.Migrations.EGWalksAuthDb
{
    /// <inheritdoc />
    public partial class seedingauthroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "72f19fc5-b1d0-4ee1-b108-820e95d1fb22", "72f19fc5-b1d0-4ee1-b108-820e95d1fb22", "writer", "WRITER" },
                    { "edb15d33-b0a0-420b-a5b9-026d3ee06689", "edb15d33-b0a0-420b-a5b9-026d3ee06689", "reader", "READER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72f19fc5-b1d0-4ee1-b108-820e95d1fb22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edb15d33-b0a0-420b-a5b9-026d3ee06689");
        }
    }
}
