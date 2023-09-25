﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wardrobe.Data_Access;

#nullable disable

namespace Wardrobe.Data_Access.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230925071548_AddSizes3")]
    partial class AddSizes3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ItemTypeModelSize", b =>
                {
                    b.Property<int>("ItemTypesItemTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SizesId")
                        .HasColumnType("int");

                    b.HasKey("ItemTypesItemTypeId", "SizesId");

                    b.HasIndex("SizesId");

                    b.ToTable("ItemTypeSize", (string)null);
                });

            modelBuilder.Entity("Wardrobe.Models.Models.ItemTypeModel", b =>
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

            modelBuilder.Entity("Wardrobe.Models.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<string>("ItemSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SizeList");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsChecked = false,
                            ItemSize = "S"
                        },
                        new
                        {
                            Id = 2,
                            IsChecked = false,
                            ItemSize = "M"
                        },
                        new
                        {
                            Id = 3,
                            IsChecked = false,
                            ItemSize = "L"
                        });
                });

            modelBuilder.Entity("Wardrobe.Models.Models.WardrobeModel", b =>
                {
                    b.Property<int>("WardrobeModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WardrobeModelId"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ItemTypeModelId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("WardrobeModelId");

                    b.HasIndex("ItemTypeModelId");

                    b.ToTable("WardrobeList");
                });

            modelBuilder.Entity("ItemTypeModelSize", b =>
                {
                    b.HasOne("Wardrobe.Models.Models.ItemTypeModel", null)
                        .WithMany()
                        .HasForeignKey("ItemTypesItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wardrobe.Models.Models.Size", null)
                        .WithMany()
                        .HasForeignKey("SizesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wardrobe.Models.Models.WardrobeModel", b =>
                {
                    b.HasOne("Wardrobe.Models.Models.ItemTypeModel", "ItemType")
                        .WithMany()
                        .HasForeignKey("ItemTypeModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemType");
                });
#pragma warning restore 612, 618
        }
    }
}