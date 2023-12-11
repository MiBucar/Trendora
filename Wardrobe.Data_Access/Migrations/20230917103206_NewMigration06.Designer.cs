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
    [DbContext(typeof(ApplicationDatabaseContext))]
    [Migration("20230917103206_NewMigration06")]
    partial class NewMigration06
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
