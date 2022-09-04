namespace HopBurger.Data
{
    public static class ApplicationDbContextSeed
    {
        public async static Task SeedAsync(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await db.Database.MigrateAsync();

            var catHamburger = new Category() { Name = "Hamburger" };
            var catIcecek = new Category() { Name = "İçecek" };
            var catSos = new Category() { Name = "Sos" };

            var item1 =new Item() { Name = "Steak House", Description = "90 gr et ev yapımı hamburgeri", Category = catHamburger, Price=30d};
            var item2 =new Item() { Name = "Whopper", Description = "90 gr et ev yapımı hamburgeri", Category = catHamburger, Price = 30d };
            var item3 =new Item() { Name = "Rolling Stone", Description = "90 gr tavuk ev yapımı hamburgeri", Category = catHamburger, Price = 30d };
            var item4 =new Item() { Name = "Kola", Description = "Coca Cola", Category = catIcecek, Price = 30d };
            var item5 =new Item() { Name = "Fanta", Description = "Fanta", Category = catIcecek, Price = 30d };
            var item6 =new Item() { Name = "Ayran", Description = "Sütaş Ayran", Category = catIcecek, Price = 30d };
            var item7 =new Item() { Name = "Barbekü", Description = "Barbekü", Category = catSos, Price = 30d };
            var item8 =new Item() { Name = "Acı", Description = "Acı", Category = catSos, Price = 30d };
            var item9 =new Item() { Name = "Ketçap", Description = "Ketçap", Category = catSos, Price = 30d};

            if (!db.Categories.Any())
            {
                db.Items.Add(item1);
                db.Items.Add(item2);
                db.Items.Add(item3);
                db.Items.Add(item4);
                db.Items.Add(item5);
                db.Items.Add(item6);
                db.Items.Add(item7);
                db.Items.Add(item8);
                db.Items.Add(item9);
                db.SaveChanges(); 
            }
        }
        public async static Task SeedDataAsync(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                await SeedAsync(db, userManager, roleManager);
            }
        }
    }
}
