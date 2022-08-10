using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyBanHangVer2.Data.Migrations
{
    public partial class fixdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 11, 45, 40, 708, DateTimeKind.Local).AddTicks(2254),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 10, 11, 40, 22, 652, DateTimeKind.Local).AddTicks(3333));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AppRoles",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "50cc1a7d-8ee7-4d93-8972-5332f96e0d59");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6572b8a6-b9a3-49f0-aa69-46b9217596dc", "AQAAAAEAACcQAAAAEEKot0oPTopIza/D8c4hA9JBZtOowFuvSYHatJcm/Yi7sA6lv2i3vuJY0wybDX0QRQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 10, 11, 40, 22, 652, DateTimeKind.Local).AddTicks(3333),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 10, 11, 45, 40, 708, DateTimeKind.Local).AddTicks(2254));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AppRoles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "648c10ec-3e88-4af2-8919-05895387b235");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d2c94e56-83e1-4fde-8749-ac5bec5ca60b", "AQAAAAEAACcQAAAAEGBNYxLB9R48UcDOVZ2na2vlCfXsKRnqamUST096lLcyUCMxsCWglWbVqRF7u53ZmQ==" });
        }
    }
}
