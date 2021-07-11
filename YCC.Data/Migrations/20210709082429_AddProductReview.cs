using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YCC.Data.Migrations
{
    public partial class AddProductReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId",
                table: "ProductReviews",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("35c242f0-1238-4fd0-9450-00a6d3cf9573"),
                column: "ConcurrencyStamp",
                value: "cb6db35a-9531-43c6-b2b3-9d9828e00b54");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "9f2ca94e-f652-48aa-8ca4-04cc49953d78");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7a6e953c-9c68-4001-a0af-a6e58594df7c", "AQAAAAEAACcQAAAAELsiJbd11X6h5rYxJ5mwKsL5lPT5GvPZVM09su8Jj/eaGTQNkgh8aRcZ5Htm3vsXsQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1e5705a-03e0-4d86-8396-b639cedef1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a4c00fe8-c03a-43b2-bb45-4ef66471ec1d", "AQAAAAEAACcQAAAAEDJi0B7nRZNY9WK7TIpqk9C7MlREB0STqdK2JqFF0a38fdO0AtGSNvNmHG+R2oNDGQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 7, 8, 23, 23, 59, 491, DateTimeKind.Local).AddTicks(9352));
        }
    }
}
