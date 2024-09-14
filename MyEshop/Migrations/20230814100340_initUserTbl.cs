using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyEshop.Migrations
{
    public partial class initUserTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categoryToProducts_categories_CategoryId",
                table: "categoryToProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_categoryToProducts_Products_ProductId",
                table: "categoryToProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categoryToProducts",
                table: "categoryToProducts");

            migrationBuilder.DropIndex(
                name: "IX_categoryToProducts_ProductId",
                table: "categoryToProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.RenameTable(
                name: "categoryToProducts",
                newName: "CategoryToProducts");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryToProducts",
                table: "CategoryToProducts",
                columns: new[] { "ProductId", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 300, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "QuantityInStock" },
                values: new object[] { 854.0m, 5 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "QuantityInStock" },
                values: new object[] { 3302.0m, 8 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Price", "QuantityInStock" },
                values: new object[] { 2500m, 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "آموزش Asp.Net Core 3 پروژه محور ASP.NET Core بر پایه‌ی NET Core.استوار است و نگارشی از NET.محسوب می شود که مستقل از سیستم عامل و بدون واسط برنامه نویسی ویندوز عمل می کند.ویندوز هنوز هم سیستم عاملی برتر به حساب می آید ولی برنامه های وب نه تنها روز به روز از کاربرد و اهمیت بیشتری برخوردار می‌شوند بلکه باید بر روی سکوهای دیگری مانند فضای ابری(Cloud) هم بتوانند میزبانی(Host) شوند، مایکروسافت با معرفی ASP.NET Core گستره کارکرد NET.را افزایش داده است.به این معنی که می‌توان برنامه‌های کاربردی ASP.NET Core را بر روی بازه‌ی گسترده ای از محیط‌های مختلف میزبانی کرد هم‌اکنون می‌توانید پروژه های وب را برای Linux یا macOS هم تولید کنید.", "آموزش Asp.Net Core 3 پروژه محور" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "در سال های گذشته ، کمپانی مایکروسافت با معرفی تکنولوژی های جدید و حرفه ای در زمینه های مختلف ، عرصه را برای سایر کمپانی ها تنگ تر کرده است. اخیرا این غول فناوری با معرفی فریم ورک های ASP.NET Core و همینطور Blazor قدرت خود در زمینه ی وب را به اثبات رسانده است.", "آموزش Blazor از مقدماتی تا پیشرفته" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "آموزش اپلیکیشن های وب پیش رونده ( PWA ) آموزش PWA از مقدماتی تا پیشرفته وب اپلیکیشن‌های پیش رونده(PWA) نسل جدید اپلیکیشن‌های تحت وب هستند که می‌توانند آینده‌ی اپلیکیشن‌های موبایل را متحول کنند.در این دوره به طور جامع به بررسی آن‌ها خواهیم پرداخت. مزایا و فاکتور هایی که یک وب اپلیکیشن دارا می باشد به صورت زیر می باشد : ریسپانسیو :  رکن اصلی سایت برای PWA ریسپانسیو بودن اپلیکیشن هستش که برای صفحه نمایش کاربران مختلف موبایل و تبلت خود را وفق دهند.", "آموزش اپلیکیشن های وب پیش رونده ( PWA )" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryToProducts_CategoryId",
                table: "CategoryToProducts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryToProducts_Categories_CategoryId",
                table: "CategoryToProducts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryToProducts_Products_ProductId",
                table: "CategoryToProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryToProducts_Categories_CategoryId",
                table: "CategoryToProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryToProducts_Products_ProductId",
                table: "CategoryToProducts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryToProducts",
                table: "CategoryToProducts");

            migrationBuilder.DropIndex(
                name: "IX_CategoryToProducts_CategoryId",
                table: "CategoryToProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "CategoryToProducts",
                newName: "categoryToProducts");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categoryToProducts",
                table: "categoryToProducts",
                columns: new[] { "CategoryId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "QuantityInStock" },
                values: new object[] { 3302.0m, 8 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "QuantityInStock" },
                values: new object[] { 2500m, 3 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Price", "QuantityInStock" },
                values: new object[] { 854.0m, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "ASP.NET Core بر پایه‌ی NET Core. استوار است و نگارشی از NET. محسوب می شود که مستقل از سیستم عامل و بدون واسط برنامه نویسی ویندوز عمل می کند . ویندوز هنوز هم سیستم عاملی برتر به حساب می آید ولی برنامه های وب نه تنها روز به روز از کاربرد و اهمیت بیشتری برخوردار می‌شوند بلکه باید بر روی سکوهای دیگری مانند فضای ابری (Cloud) هم بتوانند میزبانی (Host) شوند، مایکروسافت با معرفی ASP.NET Core گستره کارکرد NET. را افزایش داده است . به این معنی که می‌توان برنامه‌های کاربردی ASP.NET Core را بر روی بازه‌ی گسترده ای از محیط‌های مختلف میزبانی کرد هم‌اکنون می‌توانید پروژه های وب را برای Linux یا macOS هم تولید کنید.", "آموزش Asp.Net Core پروژه محور" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { @"Bootstrap مجموعه ای از ابزارهای رایگان برای ایجاد صفحات وب و نرم افزارهای تحت وب است که شامل دستورات HTML، CSS و توابع جاوا اسکریپت جهت تولید و نمایش فرم ها، دکمه ها، تب ها، ستون ها و سایر المان های مورد نیاز طراحی وب می باشد.
Bootstrap در ابتدا توسط مارک اتو و جاکوب تورنتون و در جهت ایجاد یک چارچوب ظاهری مشخص و یکسان در ابزارهای توییتر طراحی و نوشته شد. قبل از شروع این پروژه نمونه های زیادی با همین رویکرد ایجاد شده بود که همگی با سرنوشتی مشابه و عدم استقبال طراحان وب دنیا مواجه شده بودند. به دلیل وجود مشکلات اساسی در نمونه های دیگر، سازنده اصلی توییتر یا همان مارک اتو تصمیم به ساخت یک سیستم داخلی و قدرتمند برای خود با نام Bootstrap گرفت.", "آموزش بوت استرپ (BootStrap)" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "برنامه نویسی شی گرا (OOP) یک ساختار برنامه نویسی است که در آن برنامه‌ها بر خلاف عمل و منطق، حول اشیا سازماندهی می‌شوند. برنامه‌نویسی شی گرا اساساً یک فلسفه طراحی است که مجموعه متفاوتی از زبان‌های برنامه نویسی مانند سی‌شارپ از آن استفاده می کنند. درک مفاهیم OOP می تواند به تصمیم‌گیری در مورد نحوه‌ی طراحی برنامه و ساختار مورد استفاده کمک کند. همه چیز در OOP به عنوان اشیا کنار هم قرار می گیرند. یک شی ترکیبی از متغیرها، توابع و داده‌ها است که مجموعه‌ای از فعالیت‌های مرتبط با هم را انجام می‌دهد. وقتی شیء آن فعالیت‌ها را انجام می دهد، رفتار شی را تعریف می‌کند.", "آموزش برنامه‌نویسی شی‌ء گرا در سی‌شارپ" });

            migrationBuilder.CreateIndex(
                name: "IX_categoryToProducts_ProductId",
                table: "categoryToProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_categoryToProducts_categories_CategoryId",
                table: "categoryToProducts",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_categoryToProducts_Products_ProductId",
                table: "categoryToProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
