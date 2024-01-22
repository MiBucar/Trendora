using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wardrobe.Models.Models;

namespace Wardrobe.Data_Access
{
    public class ApplicationDatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options) { }

        public DbSet<Product> ProductList { get; set; }
        public DbSet<ItemType> ItemTypeList { get; set; }
        public DbSet<Size> SizeList { get; set; }
        public DbSet<Color> ColorList { get; set; }
        public DbSet<ApplicationUser> UserList { get; set; }
        public DbSet<OrderDetail> OrderDetailList { get; set; }
        public DbSet<OrderInfo> OrderInfoList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>().HasData(
                new Color { Id=1, Name="Red", ColorCode= "#fc030f" },
                new Color { Id=2, Name="Blue", ColorCode= "#0202d6" },
                new Color { Id=3, Name="Green", ColorCode= "#04b507" },
                new Color { Id=4, Name="Yellow", ColorCode= "#f5f500" },
                new Color { Id=5, Name="Black", ColorCode= "#000000" },
                new Color { Id=6, Name="White", ColorCode= "#ffffff" },
                new Color { Id=7, Name="Pink", ColorCode= "#e610a9" },
                new Color { Id=8, Name="Brown", ColorCode= "#964B00" },
                new Color { Id=9, Name="Purple", ColorCode= "#800080" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
