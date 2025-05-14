using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBanHang.Migrations
{
    public partial class SeedDataToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Categogies_CategogyId",
                table: "products");

            migrationBuilder.AlterColumn<int>(
                name: "CategogyId",
                table: "products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categogies",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Điện thoại" },
                    { 2, 2, "Máy tính bảng" },
                    { 3, 3, "Laptop" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "CategogyId", "CategoryId", "Description", "Discount", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, null, 1, null, 0, null, "Iphone 7", 300.0 },
                    { 2, null, 1, null, 0, null, "Iphone 7s", 350.0 },
                    { 3, null, 1, null, 0, null, "Iphone 8", 400.0 },
                    { 4, null, 1, null, 0, null, "Iphone 8s", 420.0 },
                    { 5, null, 1, null, 0, null, "Iphone 12", 630.0 },
                    { 6, null, 1, null, 0, null, "Iphone 12 Pro", 750.0 },
                    { 7, null, 1, null, 0, null, "Iphone 14", 820.0 },
                    { 8, null, 1, null, 0, null, "Iphone 14 Pro", 950.0 },
                    { 9, null, 1, null, 0, null, "Iphone 15", 1200.0 },
                    { 10, null, 1, null, 0, null, "Iphone 15 Pro Max ", 1450.0 },
                    { 11, null, 2, null, 0, null, "Ipad Gen 10", 750.0 },
                    { 12, null, 2, null, 0, null, "Ipad Pro 11", 1250.0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_products_Categogies_CategogyId",
                table: "products",
                column: "CategogyId",
                principalTable: "Categogies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Categogies_CategogyId",
                table: "products");

            migrationBuilder.DeleteData(
                table: "Categogies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categogies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categogies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "products");

            migrationBuilder.AlterColumn<int>(
                name: "CategogyId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_products_Categogies_CategogyId",
                table: "products",
                column: "CategogyId",
                principalTable: "Categogies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
