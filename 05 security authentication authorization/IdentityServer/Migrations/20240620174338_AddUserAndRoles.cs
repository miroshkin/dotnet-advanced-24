using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityServer.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "919d2803-12df-48c8-bbe3-f212e68f9d27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec52a5bf-7318-42d1-8558-64a4c4612f90");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Manager", "MANAGER" },
                    { "2", null, "Buyer", "BUYER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "d3990e12-1489-4454-9c45-23ab5f9382a6", "manager@domain.com", true, false, null, "MANAGER@DOMAIN.COM", "MANAGER@DOMAIN.COM", "AQAAAAIAAYagAAAAELURYMUOAK0Fvpm/UVZGwBWWD25POKgvVeRP4d5PiXruzUCo8iBHdfUHODVLqNjU2A==", null, false, "ad566a9d-aade-4113-b653-1b32b903f6c6", false, "manager@domain.com" },
                    { "2", 0, "d3f2f502-9e1c-47d4-8004-2c42e99a4287", "buyer@domain.com", true, false, null, "BUYER@DOMAIN.COM", "BUYER@DOMAIN.COM", "AQAAAAIAAYagAAAAEFrM4Wy96TA8OUKRzfsWig6mcytw2k5IeaBoja/pkCf3Fd9MapIWSmHjQO7gBJN59A==", null, false, "f3d3aaa8-5e8f-48d0-b714-846103703087", false, "buyer@domain.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "919d2803-12df-48c8-bbe3-f212e68f9d27", null, "Manager", "MANAGER" },
                    { "ec52a5bf-7318-42d1-8558-64a4c4612f90", null, "Buyer", "BUYER" }
                });
        }
    }
}
