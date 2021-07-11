using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YCC.Data.Migrations
{
    public partial class ModifyProductReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("35c242f0-1238-4fd0-9450-00a6d3cf9573"),
                column: "ConcurrencyStamp",
                value: "791f6b1d-2a74-48b1-aade-909f9023c7ae");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "0d6156ff-1cf5-4c9a-b066-9d559c4da617");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "83d8fe3f-cec6-4f09-b01d-f5ca6c53c0f1", "AQAAAAEAACcQAAAAEGvpQ94dBFWb/oxTMVtPGqPnMGAlQ6wc/YZBXS0cQpVfUlWsd57QmJXR591UayXL2g==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1e5705a-03e0-4d86-8396-b639cedef1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bba90aa7-175f-4fe8-9404-6ef567a4f1c2", "AQAAAAEAACcQAAAAEJiBQgdn8pWN1HygQiAu2sT/cDbiW+uEjeqO2oGeRDamTtpIy6wvgj/U6qiGx2ahxQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 7, 9, 19, 22, 45, 398, DateTimeKind.Local).AddTicks(9314));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("35c242f0-1238-4fd0-9450-00a6d3cf9573"),
                column: "ConcurrencyStamp",
                value: "b5c7b9ec-53bd-422d-a437-150727eba460");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "89319e9b-8303-4acf-ac83-b4f2666d1ebc");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5d2bcb24-64a6-423a-b82e-843ace571aab", "AQAAAAEAACcQAAAAEBxfgyz8FNLc2RlywYVzL5MuBQ6FCT+9iF5pvR8clvYj9Q/uI1yhsnRZEV3nOlQQKw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1e5705a-03e0-4d86-8396-b639cedef1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "91279349-534e-4d0d-a0dd-3247dae09c97", "AQAAAAEAACcQAAAAELUIJjP9br8pLNctYrfpFExrEitFTNBPWUc6Se0hwRISBnUK40+zcfdg+2NxNlnBkQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 7, 9, 15, 24, 28, 161, DateTimeKind.Local).AddTicks(467));
        }
    }
}
