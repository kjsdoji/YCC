using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YCC.Data.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "31307d86-024b-4d4e-96af-9856ba3af6d5");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "0c4b0677-aaa1-49a4-90e4-501e5db36735", "tedu.international@gmail.com", "Toan", "Bach", "tedu.international@gmail.com", "AQAAAAEAACcQAAAAEKOvaq3oaIjvIThUdb8tV/Sxm2zkpvm1RuxxjfadyVA63Szn5LzYDPs0rRiwDStvRg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 6, 30, 17, 48, 39, 408, DateTimeKind.Local).AddTicks(1008));
        }
    }
}
