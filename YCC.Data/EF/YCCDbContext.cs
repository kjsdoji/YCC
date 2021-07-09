using System;
using System.Collections.Generic;
using System.Text;
using YCC.Data.Configurations;
using YCC.Data.Entities;
using YCC.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace YCC.Data.EF
{
    public class YCCDbContext : IdentityDbContext<AppUser>
    {
        public YCCDbContext(DbContextOptions options) : base(options) {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            //modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
            modelBuilder.ApplyConfiguration(new SlideConfiguration());
            //Add config from docs.microsoft...
            //modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            //modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            //modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasNoKey();
            //modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            //modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
            //Data seeding
            modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);
            SeedUsers(modelBuilder);
            SeedUserRoles(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<ProductInCategory> ProductInCategories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Slide> Slides { get; set; }
        private void SeedUsers(ModelBuilder builder)
        {
            AppUser admin = new AppUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Admin",
                Email = "admin@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890"
            };
            AppUser user = new AppUser()
            {
                Id = "3fa72aef-343e-4a4a-ba60-3b1670745be0",
                UserName = "User",
                Email = "user@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890"
            };
            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            passwordHasher.HashPassword(admin, "Admin*123");
            passwordHasher.HashPassword(user, "Admin*123");
            builder.Entity<AppUser>().HasData(admin);
            builder.Entity<AppUser>().HasData(user);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "deecde1b-9f1b-4320-b556-52fd1b22a929", Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" },
                new IdentityUserRole<string>() { RoleId = "deecde1b-9f1b-4320-b556-52fd1b22a929", UserId = "3fa72aef-343e-4a4a-ba60-3b1670745be0" }
                );
        }
    }
}