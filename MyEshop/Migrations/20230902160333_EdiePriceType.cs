using Microsoft.EntityFrameworkCore.Migrations;

namespace MyEshop.Migrations
{
    public partial class EdiePriceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UsersUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UsersUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "OrderDetails",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 40000m);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 55000m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "سری TUF لپ تاپ‌های ایسوس از لپ تاپ‌های خوب و باکیفیت این برند به حساب می‌آید. ایسوس کمپانی پرکار در عرصه تولید لوازم الکترونیکی و قطعات کامپیوتر، این سری لپ تاپ را علاوه بر ویژگی‌های برجسته با ظاهری زیبا روانه بازار کرده است. مدل TUF Gaming F15 FX507ZC-HN078 لپ تاپ 15.6 اینچی این کمپانی بوده که صفحه نمایشی با رزولوشن 1920x1080 پیکسل دارد. وزن این لپ تاپ 2.2 کیلوگرم بوده و ابعاد آن 24.9 × 251 ×354 میلی‌متر است. اینتل سازنده پردازنده این لپ تاپ بوده و پردازنده آن سری i7 بوده و مدل آن 12700H است. سازنده پردازنده گرافیکی انویدیا بوده و مدل آن GEFORCE RTX 3050 است. این گرافیک از پس کارهای روزمره و مولتی مدیای شما کاملا برخواهد آمد. 16 گیگابایت رم برای آن در نظر گرفته شده است. یک ترابایت SSD به عنوان حافظه داخلی در این لپ تاپ وجود دارد. قابلیت ارتقاء حافظه در این سیستم هم وجود دارد.", "لپ تاپ Asus Tuf Fx507Zc" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "UsersUserId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 854.0m);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 3302.0m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "آموزش Asp.Net Core 3 پروژه محور ASP.NET Core بر پایه‌ی NET Core.استوار است و نگارشی از NET.محسوب می شود که مستقل از سیستم عامل و بدون واسط برنامه نویسی ویندوز عمل می کند.ویندوز هنوز هم سیستم عاملی برتر به حساب می آید ولی برنامه های وب نه تنها روز به روز از کاربرد و اهمیت بیشتری برخوردار می‌شوند بلکه باید بر روی سکوهای دیگری مانند فضای ابری(Cloud) هم بتوانند میزبانی(Host) شوند، مایکروسافت با معرفی ASP.NET Core گستره کارکرد NET.را افزایش داده است.به این معنی که می‌توان برنامه‌های کاربردی ASP.NET Core را بر روی بازه‌ی گسترده ای از محیط‌های مختلف میزبانی کرد هم‌اکنون می‌توانید پروژه های وب را برای Linux یا macOS هم تولید کنید.", "آموزش Asp.Net Core 3 پروژه محور" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UsersUserId",
                table: "Orders",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UsersUserId",
                table: "Orders",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
