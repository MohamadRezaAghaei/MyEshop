using Microsoft.EntityFrameworkCore;
using MyEshop.Models;

namespace MyEshop.Data
{
    public class MyEshopContext : DbContext
    {
        public MyEshopContext(DbContextOptions<MyEshopContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToProduct>()
                .HasKey(t => new { t.ProductId, t.CategoryId });

            //modelBuilder.Entity<Product>(
            //    p =>
            //    {
            //        p.HasKey(w => w.Id);
            //        p.OwnsOne<Item>(w => w.Item);
            //        p.HasOne<Item>(w => w.Item)
            //            .WithOne(w => w.Product)
            //            .HasForeignKey<Item>(w => w.Id);
            //    }
            //);

            modelBuilder.Entity<Item>(i =>
            {
                i.Property(w => w.Price).HasColumnType("Money");
                i.HasKey(w => w.Id);
            });

            #region Seed Data Category

            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id = 1,
                Name = "لپ تاپ",
                Description = "لپ تاپ"
            },
                new Category()
                {
                    Id = 2,
                    Name = "موبایل",
                    Description = "موبایل"
                },
                new Category()
                {
                    Id = 3,
                    Name = "کامپیوتر رومیزی",
                    Description = "کامپیوتر رومیزی"
                },
                new Category()
                {
                    Id = 4,
                    Name = "لوازم جانبی",
                    Description = "لوازم جانبی"
                }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item()
                {
                    Id = 1,
                    Price = 40000,
                    QuantityInStock = 5
                },
            new Item()
            {
                Id = 2,
                Price = 55000,
                QuantityInStock = 8
            },
            new Item()
            {
                Id = 3,
                Price = 250000,
                QuantityInStock = 3
            });

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = 1,
                ItemId = 1,
                Name = "لپ تاپ Asus Tuf Fx507Zc",
                Description =
                        "سری TUF لپ تاپ‌های ایسوس از لپ تاپ‌های خوب و باکیفیت این برند به حساب می‌آید. ایسوس کمپانی پرکار در عرصه تولید لوازم الکترونیکی و قطعات کامپیوتر، این سری لپ تاپ را علاوه بر ویژگی‌های برجسته با ظاهری زیبا روانه بازار کرده است. مدل TUF Gaming F15 FX507ZC-HN078 لپ تاپ 15.6 اینچی این کمپانی بوده که صفحه نمایشی با رزولوشن 1920x1080 پیکسل دارد. وزن این لپ تاپ 2.2 کیلوگرم بوده و ابعاد آن 24.9 × 251 ×354 میلی‌متر است. اینتل سازنده پردازنده این لپ تاپ بوده و پردازنده آن سری i7 بوده و مدل آن 12700H است. سازنده پردازنده گرافیکی انویدیا بوده و مدل آن GEFORCE RTX 3050 است. این گرافیک از پس کارهای روزمره و مولتی مدیای شما کاملا برخواهد آمد. 16 گیگابایت رم برای آن در نظر گرفته شده است. یک ترابایت SSD به عنوان حافظه داخلی در این لپ تاپ وجود دارد. قابلیت ارتقاء حافظه در این سیستم هم وجود دارد."
            },
                new Product()
                {
                    Id = 2,
                    ItemId = 2,
                    Name = "لپ تاپ 15.6 اینچی لنوو مدل IdeaPad Gaming 3 I7 16G 512G 6G RTX 3060",
                    Description =
                        "لپ تاپ لنوو آیدیاپد گیمینگ 3 سال 2022 با استفاده از پردازنده Intel Corei7 12650H عملکرد قوی ای را تضمین می کند. همچنین به کارت گرافیک NVIDIA GeForce RTX 3060 مجهز می باشد. این لپ تاپ با صفحه نمایش 15.6 اینچی IPS با وضوح FHD ، از رنگ و وضوح چشمگیر برخوردار است و زاویه دید گسترده ای ارائه می دهد و از نرخ به روزرسانی 120 هرتز بهره می برد . حافظه رم 16 گیگابایت DDR4 پهنای باند بسیاری برای اجرای بازی ، عکس ها و برنامه های ویرایش ویدئو و همچنین برنامه های متعدد و برگه های مرورگر، به صورت همزمان فراهم می کند .لپ تاپ Lenovo IdeaPad Gaming 3 2022 ظرفیت ذخیره سازی 512 گیگ PCIe SSD برای ذخیره تصاویر ، فیلم ها ، موسیقی و ... فراهم می کند."
                },
                new Product()
                {
                    Id = 3,
                    ItemId = 3,
                    Name = "لپ تاپ Legion 5 Pro لنوو i7 32GB ا ۱۶ اینچی ا Lenovo Legion 5 Pro i7(12700H) 32GB 1TB SSD 6GB RTX3060",
                    Description = "معرفی لپ تاپ Legion 5 Pro 16IAH7H\r\nلپ تاپ Legion 5 Pro 16IAH7H یکی از بهترین لپ تاپ‌ های گیمینگ بوده که در سال 2022 از آن رونمایی شد، این محصول با وجود پورت‌های متنوع، سیستم پرقدرت و ویژگی‌های مثبت دیگر، توانسته پاسخگوی تمام نیازهای کاربرانش باشد. در این مطلب قصد داریم به معرفی مدل 16IAH7H از سری لپ تاپ Legion 5 Pro بپردازیم. پس برای کسب اطلاعات بیشتر و اطلاع از قیمت Lenovo legion 5 Pro 16iah7h در این صفحه همراه ما باشید.\r\n\r\nطراحی لپ تاپ Legion 5 Pro 16IAH7H\r\nیکی از بزرگ‌ترین و معروف‌ترین شرکت‌های تولیدکننده لپ تاپ، شرکت لنوو است که با ایجاد تنوع در قیمت و کیفیت محصولات خود توانسته جایگاه ویژه‌ای را بین خریداران و فروشندگان لپ تاپ‌های گیمینگ کسب نماید. یکی از قدرتمندترین محصولات لنوو همین لپ تاپ Legion 5 Pro 16IAH7H خواهد بود. این محصول با بدنه آلومینیومی و وزنی حدود 2.49 کیلوگرم توانسته زیبایی خیره کننده‌ای ایجاد کند؛ همچنین با طراحی کیبوردی به رنگ آبی حس لطافت را به کاربرانش منتقل می‌کند. این لپ تاپ Gaming جهت اتصال بی‌ سیم دائم با کمترین خطا به Wi-Fi 6E مجهز شده است.\r\n\r\nصفحه نمایش لپ تاپ  legion 5 pro rtx 3060\r\nابعاد نمایشگر این لپ تاپ 16 اینچ با وضوح تصویر 2K و پنل IPS است؛ اما صفحه نمایش آن لمسی نیست. شرکت لنوو پوشش مات نمایشگر را به منظور ممانعت از خستگی چشم‌های کاربران در استفاده طولانی مدت از لپ تاپ طراحی کرده است. یکی از مشخصه‌های این محصول که توجه گیمرها را به خود جلب می‌کند نرخ نوسازی 165 هرتزی است که باعث می‌شود بتوانید بازی‌ها را با نرخ فریم بالایی تجربه کنید. با وجود پشتیبانی 100 درصدی از طیف رنگی sRGB، حداکثر روشنایی 500 نیت، پشتیبانی از Dolby Vision و تکنولوژی DisplayHDR 400 قادر به نمایش گذاشتن طیف وسیعی از رنگ‌ها است. در تکمیل مشخصات لپ تاپ legion 5 pro rtx 3060 می ‌توان به داشتن دو اسپیکر استریو 2 واتی اشاره کنیم.\r\n\r\nباتری لپ تاپ Legion 5 Pro 16IAH7H\r\nاین لپ تاپ دارای یک باتری چهار سلولی با ظرفیت خروجی 80 وات ‌ساعت است که قابلیت نگهداری شارژ باتری آن بین 2 تا 4 ساعت نسبت به نوع استفاده آن است.\r\n\r\nسخت افزار لپ تاپ legion 5 pro rtx 3060\r\nلنوو در لپ تاپ Legion 5 Pro 16IAH7H پردازنده سری Core i7 مدل 12700H را قرار داده است. این لپ تاپ از ۳۲ گیگابایت رم هم استفاده می‌کند. پردازنده گرافیکی NVIDIA GeForce"
                });

            modelBuilder.Entity<CategoryToProduct>().HasData(
                new CategoryToProduct() { CategoryId = 1, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 4, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 1, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 4, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 1, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 4, ProductId = 3 }
                );
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
