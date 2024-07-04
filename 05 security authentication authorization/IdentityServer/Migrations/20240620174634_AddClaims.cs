using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityServer.Migrations
    {
    /// <inheritdoc />
    public partial class AddClaims : Migration
        {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
            {
            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "Permission", "Read", "1" },
                    { 2, "Permission", "Create", "1" },
                    { 3, "Permission", "Update", "1" },
                    { 4, "Permission", "Delete", "1" },
                    { 5, "Permission", "Read", "2" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "533f6075-4167-4677-8fb4-9cbe501f1fa7", "AQAAAAIAAYagAAAAED8ULwMpUUxjJaqQjmP4f+5+9pYWkpp4qBDySNpno1bHMkCmrp6ttZF6nlDQ/psm0g==", "d74bd2fa-f151-4ab6-87ec-67efca06c559" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8129dac-b606-40ac-b0f2-29370edb96f0", "AQAAAAIAAYagAAAAECTndl4RRMWRDYt0DBR46PgBomkm2zym28Tak0XavVzdRk+iPWtkOR3tKwaJSxWt+w==", "737e1eb6-dd69-4f0a-8b18-98f8ccdda8fe" });
            }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
            {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3990e12-1489-4454-9c45-23ab5f9382a6", "AQAAAAIAAYagAAAAELURYMUOAK0Fvpm/UVZGwBWWD25POKgvVeRP4d5PiXruzUCo8iBHdfUHODVLqNjU2A==", "ad566a9d-aade-4113-b653-1b32b903f6c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3f2f502-9e1c-47d4-8004-2c42e99a4287", "AQAAAAIAAYagAAAAEFrM4Wy96TA8OUKRzfsWig6mcytw2k5IeaBoja/pkCf3Fd9MapIWSmHjQO7gBJN59A==", "f3d3aaa8-5e8f-48d0-b714-846103703087" });
            }
        }
    }