using Microsoft.EntityFrameworkCore;
using Wardrobe.Models.Models;

namespace Wardrobe.Data_Access
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> WardrobeList { get; set; }
        public DbSet<ItemType> ItemTypeList { get; set; }
        public DbSet<Size> SizeList { get; set; }
        public DbSet<Color> ColorList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>().HasData(
                new Color { Id=1, Name="Red", ColorCode= "#fc030f" },
                new Color { Id=2, Name="Blue", ColorCode= "#0202d6" },
                new Color { Id=3, Name="Green", ColorCode= "#04b507" },
                new Color { Id=4, Name="Yellow", ColorCode= "#f5f500" },
                new Color { Id=5, Name="Black", ColorCode= "#000000" },
                new Color { Id=6, Name="White", ColorCode= "#ffffff" },
                new Color { Id=7, Name="Pink", ColorCode= "#e610a9" }
            );
        }
    }
}
