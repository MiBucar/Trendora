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
    }
}
