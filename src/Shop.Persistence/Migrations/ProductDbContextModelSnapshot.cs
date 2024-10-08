﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Shop.Persistence.Database;

#nullable disable

namespace Shop.Persistence.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    partial class ProductDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Shop.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Brands", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Genders", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("integer");

                    b.Property<int>("GenderId")
                        .HasColumnType("integer");

                    b.Property<int>("SubcategoryId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("GenderId");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.Products.ProductSizeQuantity", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("SizeId")
                        .HasColumnType("integer");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("integer");

                    b.HasKey("ProductId", "SizeId");

                    b.HasIndex("SizeId");

                    b.HasIndex("ProductId", "SizeId")
                        .IsUnique();

                    b.ToTable("ProductSizeQuantities", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Sizes", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.Subcategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Subcategories", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.Products.Product", b =>
                {
                    b.HasOne("Shop.Domain.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Shop.Domain.Entities.Gender", "Gender")
                        .WithMany("Products")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Shop.Domain.Entities.Subcategory", "Subcategory")
                        .WithMany("Products")
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("Shop.Domain.Entities.Products.Product.Details#Shop.Domain.Entities.Products.ProductDetails", "Details", b1 =>
                        {
                            b1.Property<int>("ProductId")
                                .HasColumnType("integer");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("Code");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(1000)
                                .HasColumnType("character varying(1000)")
                                .HasColumnName("Description");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("character varying(200)")
                                .HasColumnName("Name");

                            b1.Property<decimal>("Price")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Price");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Brand");

                    b.Navigation("Details")
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Products.ProductSizeQuantity", b =>
                {
                    b.HasOne("Shop.Domain.Entities.Products.Product", "Product")
                        .WithMany("SizeQuantities")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Shop.Domain.Entities.Size", "Size")
                        .WithMany("SizeQuantities")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Size", b =>
                {
                    b.HasOne("Shop.Domain.Entities.Category", "Category")
                        .WithMany("Sizes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Subcategory", b =>
                {
                    b.HasOne("Shop.Domain.Entities.Category", "Category")
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Category", b =>
                {
                    b.Navigation("Sizes");

                    b.Navigation("Subcategories");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Gender", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Products.Product", b =>
                {
                    b.Navigation("SizeQuantities");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Size", b =>
                {
                    b.Navigation("SizeQuantities");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Subcategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
