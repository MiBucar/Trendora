﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wardrobe.Data_Access;

#nullable disable

namespace Wardrobe.Data_Access.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ColorProduct", b =>
                {
                    b.Property<int>("ColorsId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsWardrobeModelId")
                        .HasColumnType("int");

                    b.HasKey("ColorsId", "ProductsWardrobeModelId");

                    b.HasIndex("ProductsWardrobeModelId");

                    b.ToTable("ColorProduct");
                });

            modelBuilder.Entity("Wardrobe.Models.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ColorCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ColorList");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ColorCode = "#fc030f",
                            Name = "Red"
                        },
                        new
                        {
                            Id = 2,
                            ColorCode = "#0202d6",
                            Name = "Blue"
                        },
                        new
                        {
                            Id = 3,
                            ColorCode = "#04b507",
                            Name = "Green"
                        },
                        new
                        {
                            Id = 4,
                            ColorCode = "#f5f500",
                            Name = "Yellow"
                        },
                        new
                        {
                            Id = 5,
                            ColorCode = "#000000",
                            Name = "Black"
                        },
                        new
                        {
                            Id = 6,
                            ColorCode = "#ffffff",
                            Name = "White"
                        },
                        new
                        {
                            Id = 7,
                            ColorCode = "#e610a9",
                            Name = "Pink"
                        });
                });

            modelBuilder.Entity("Wardrobe.Models.Models.ItemType", b =>
                {
                    b.Property<int>("ItemTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemTypeId"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemTypeId");

                    b.ToTable("ItemTypeList");
                });

            modelBuilder.Entity("Wardrobe.Models.Models.Product", b =>
                {
                    b.Property<int>("WardrobeModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WardrobeModelId"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ItemTypeModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("WardrobeModelId");

                    b.HasIndex("ItemTypeModelId");

                    b.ToTable("WardrobeList");
                });

            modelBuilder.Entity("Wardrobe.Models.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("ItemSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemTypeModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemTypeModelId");

                    b.ToTable("SizeList");
                });

            modelBuilder.Entity("ColorProduct", b =>
                {
                    b.HasOne("Wardrobe.Models.Models.Color", null)
                        .WithMany()
                        .HasForeignKey("ColorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wardrobe.Models.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsWardrobeModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wardrobe.Models.Models.Product", b =>
                {
                    b.HasOne("Wardrobe.Models.Models.ItemType", "ItemType")
                        .WithMany()
                        .HasForeignKey("ItemTypeModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemType");
                });

            modelBuilder.Entity("Wardrobe.Models.Models.Size", b =>
                {
                    b.HasOne("Wardrobe.Models.Models.ItemType", "ItemTypeModel")
                        .WithMany("Sizes")
                        .HasForeignKey("ItemTypeModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemTypeModel");
                });

            modelBuilder.Entity("Wardrobe.Models.Models.ItemType", b =>
                {
                    b.Navigation("Sizes");
                });
#pragma warning restore 612, 618
        }
    }
}
