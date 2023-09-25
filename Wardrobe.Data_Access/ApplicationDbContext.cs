using Microsoft.EntityFrameworkCore;
using Wardrobe.Models.Models;

namespace Wardrobe.Data_Access
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<WardrobeModel> WardrobeList { get; set; }
        public DbSet<ItemTypeModel> ItemTypeList { get; set; }
        public DbSet<SizeModel> SizeList { get; set; }
    }
}
