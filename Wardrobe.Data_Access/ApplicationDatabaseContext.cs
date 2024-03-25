using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wardrobe.Common;
using Wardrobe.Models.Models;

namespace Wardrobe.Data_Access
{
    public class ApplicationDatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options) { }

        public DbSet<Product> ProductList { get; set; }
        public DbSet<Category> CategoryList { get; set; }
        public DbSet<Size> SizeList { get; set; }
        public DbSet<Color> ColorList { get; set; }
        public DbSet<ApplicationUser> UserList { get; set; }
        public DbSet<OrderDetail> OrderDetailList { get; set; }
        public DbSet<OrderInfo> OrderInfoList { get; set; }
        public DbSet<Tag> TagList { get; set; }
        public DbSet<Collection> CollectionList { get; set; }
        public DbSet<Gender> GenderList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>().HasData(
                new Color { Id = 1, Name = "Red", ColorCode = "#fc030f" },
                new Color { Id = 2, Name = "Blue", ColorCode = "#0202d6" },
                new Color { Id = 3, Name = "Green", ColorCode = "#04b507" },
                new Color { Id = 4, Name = "Yellow", ColorCode = "#f5f500" },
                new Color { Id = 5, Name = "Black", ColorCode = "#000000" },
                new Color { Id = 6, Name = "White", ColorCode = "#ffffff" },
                new Color { Id = 7, Name = "Pink", ColorCode = "#e610a9" },
                new Color { Id = 8, Name = "Brown", ColorCode = "#964B00" },
                new Color { Id = 9, Name = "Purple", ColorCode = "#800080" },
                new Color { Id = 10, Name = "Orange", ColorCode = "#FFA500" },
                new Color { Id = 11, Name = "Gray", ColorCode = "#808080" },
                new Color { Id = 12, Name = "Light Blue", ColorCode = "#ADD8E6" }
            );

            modelBuilder.Entity<Gender>().HasData(
                new Gender { Id = 1, Name = SD.Section_Women },
                new Gender { Id = 2, Name = SD.Section_Men },
                new Gender { Id = 3, Name = SD.Section_Boys },
                new Gender { Id = 4, Name = SD.Section_Girls }
            );

            modelBuilder.Entity<Collection>().HasData(
                new Collection { CollectionId = 1, Name = SD.Section_Women },
                new Collection { CollectionId = 2, Name = SD.Section_Men },
                new Collection { CollectionId = 3, Name = SD.Section_Kids },
                new Collection { CollectionId = 4, Name = SD.Section_AllProducts }
            );

            modelBuilder.Entity<Tag>().HasData(
                new Tag { TagId = 1, Title = SD.Tag_None }
            );

            var allTagIds = modelBuilder.Model.GetEntityTypes().Single(t => t.ClrType == typeof(Tag)).GetSeedData().Select(d => (int)d["TagId"])
                            .ToList();
            foreach (var tagId in allTagIds)
            {
                modelBuilder.Entity("CollectionTag")
                    .HasData(new
                    {
                        CollectionsCollectionId = 4,
                        TagsTagId = tagId
                    });
            }

            modelBuilder.Entity<Gender>().HasMany(g => g.Collections).WithMany(c => c.Genders).UsingEntity(j => j.HasData(
                new { GendersId = 1, CollectionsCollectionId = 1 },
                new { GendersId = 2, CollectionsCollectionId = 2 },
                new { GendersId = 3, CollectionsCollectionId = 3 },
                new { GendersId = 4, CollectionsCollectionId = 3 },

                new { GendersId = 1, CollectionsCollectionId = 4 },
                new { GendersId = 2, CollectionsCollectionId = 4 },
                new { GendersId = 3, CollectionsCollectionId = 4 },
                new { GendersId = 4, CollectionsCollectionId = 4 }
            ));

            base.OnModelCreating(modelBuilder);
        }
    }
}
