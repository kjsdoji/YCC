using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YCC.Data.Migrations
{
    public partial class AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "9f2ca94e-f652-48aa-8ca4-04cc49953d78");

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("35c242f0-1238-4fd0-9450-00a6d3cf9573"), "cb6db35a-9531-43c6-b2b3-9d9828e00b54", "User role", "user", "user" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("35c242f0-1238-4fd0-9450-00a6d3cf9573"), new Guid("d1e5705a-03e0-4d86-8396-b639cedef1b7") });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "7a6e953c-9c68-4001-a0af-a6e58594df7c", "admin@gmail.com", "Admin", "Ad", "admin@gmail.com", "AQAAAAEAACcQAAAAELsiJbd11X6h5rYxJ5mwKsL5lPT5GvPZVM09su8Jj/eaGTQNkgh8aRcZ5Htm3vsXsQ==" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d1e5705a-03e0-4d86-8396-b639cedef1b7"), 0, "a4c00fe8-c03a-43b2-bb45-4ef66471ec1d", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@gmail.com", true, "User", "Us", false, null, "user@gmail.com", "user", "AQAAAAEAACcQAAAAEDJi0B7nRZNY9WK7TIpqk9C7MlREB0STqdK2JqFF0a38fdO0AtGSNvNmHG+R2oNDGQ==", null, false, "", false, "user" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 7, 8, 23, 23, 59, 491, DateTimeKind.Local).AddTicks(9352));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("35c242f0-1238-4fd0-9450-00a6d3cf9573"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("35c242f0-1238-4fd0-9450-00a6d3cf9573"), new Guid("d1e5705a-03e0-4d86-8396-b639cedef1b7") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1e5705a-03e0-4d86-8396-b639cedef1b7"));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "286bb85f-87c7-4811-81e7-b6428023baf5");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "e0259694-f6ee-4ff9-bab6-e42457e50447", "ycc@gmail.com", "Kjs", "Doji", "ycc@gmail.com", "AQAAAAEAACcQAAAAEESyMdiyZePFNpTCn+u75KsIaTgEM/Id2D/10oSeSpZoan1JTDWFWaJdtj5kgpKOcw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 6, 30, 19, 34, 23, 311, DateTimeKind.Local).AddTicks(357));
        }
    }
}
