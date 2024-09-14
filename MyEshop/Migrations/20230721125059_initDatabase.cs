using Microsoft.EntityFrameworkCore.Migrations;

namespace MyEshop.Migrations
{
    public partial class initDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    QuantityInStock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "categoryToProducts",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryToProducts", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_categoryToProducts_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categoryToProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Price", "QuantityInStock" },
                values: new object[,]
                {
                    { 1, 3302.0m, 8 },
                    { 2, 2500m, 3 },
                    { 3, 854.0m, 5 }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Asp.Net Core 3", "Asp.Net Core" },
                    { 2, "گروه لباس ورزشی", "لباس ورزشی" },
                    { 3, "ساعت مچی", "ساعت مچی" },
                    { 4, "لوازم منزل", "لوازم منزل" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ItemId", "Name" },
                values: new object[] { 1, "ASP.NET Core بر پایه‌ی NET Core. استوار است و نگارشی از NET. محسوب می شود که مستقل از سیستم عامل و بدون واسط برنامه نویسی ویندوز عمل می کند . ویندوز هنوز هم سیستم عاملی برتر به حساب می آید ولی برنامه های وب نه تنها روز به روز از کاربرد و اهمیت بیشتری برخوردار می‌شوند بلکه باید بر روی سکوهای دیگری مانند فضای ابری (Cloud) هم بتوانند میزبانی (Host) شوند، مایکروسافت با معرفی ASP.NET Core گستره کارکرد NET. را افزایش داده است . به این معنی که می‌توان برنامه‌های کاربردی ASP.NET Core را بر روی بازه‌ی گسترده ای از محیط‌های مختلف میزبانی کرد هم‌اکنون می‌توانید پروژه های وب را برای Linux یا macOS هم تولید کنید.", 1, "آموزش Asp.Net Core پروژه محور" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ItemId", "Name" },
                values: new object[] { 2, @"Bootstrap مجموعه ای از ابزارهای رایگان برای ایجاد صفحات وب و نرم افزارهای تحت وب است که شامل دستورات HTML، CSS و توابع جاوا اسکریپت جهت تولید و نمایش فرم ها، دکمه ها، تب ها، ستون ها و سایر المان های مورد نیاز طراحی وب می باشد.
Bootstrap در ابتدا توسط مارک اتو و جاکوب تورنتون و در جهت ایجاد یک چارچوب ظاهری مشخص و یکسان در ابزارهای توییتر طراحی و نوشته شد. قبل از شروع این پروژه نمونه های زیادی با همین رویکرد ایجاد شده بود که همگی با سرنوشتی مشابه و عدم استقبال طراحان وب دنیا مواجه شده بودند. به دلیل وجود مشکلات اساسی در نمونه های دیگر، سازنده اصلی توییتر یا همان مارک اتو تصمیم به ساخت یک سیستم داخلی و قدرتمند برای خود با نام Bootstrap گرفت.", 2, "آموزش بوت استرپ (BootStrap)" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ItemId", "Name" },
                values: new object[] { 3, "برنامه نویسی شی گرا (OOP) یک ساختار برنامه نویسی است که در آن برنامه‌ها بر خلاف عمل و منطق، حول اشیا سازماندهی می‌شوند. برنامه‌نویسی شی گرا اساساً یک فلسفه طراحی است که مجموعه متفاوتی از زبان‌های برنامه نویسی مانند سی‌شارپ از آن استفاده می کنند. درک مفاهیم OOP می تواند به تصمیم‌گیری در مورد نحوه‌ی طراحی برنامه و ساختار مورد استفاده کمک کند. همه چیز در OOP به عنوان اشیا کنار هم قرار می گیرند. یک شی ترکیبی از متغیرها، توابع و داده‌ها است که مجموعه‌ای از فعالیت‌های مرتبط با هم را انجام می‌دهد. وقتی شیء آن فعالیت‌ها را انجام می دهد، رفتار شی را تعریف می‌کند.", 3, "آموزش برنامه‌نویسی شی‌ء گرا در سی‌شارپ" });

            migrationBuilder.InsertData(
                table: "categoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_categoryToProducts_ProductId",
                table: "categoryToProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ItemId",
                table: "Products",
                column: "ItemId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categoryToProducts");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
