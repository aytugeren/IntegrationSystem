﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProductMicroservice.Data;

#nullable disable

namespace ProductMicroservice.Data.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20241122114206_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProductMicroservice.Entities.Entities.Picture", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("LogMessage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("Picture is added on 22-11-2024 11:42");

                    b.Property<string>("PictureAltName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PictureName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("tblPicture", (string)null);
                });

            modelBuilder.Entity("ProductMicroservice.Entities.Entities.Product", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("LogMessage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("Product is added on 22-11-2024 11:42");

                    b.Property<string>("ProductMainCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("VatRate")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("tblProduct", (string)null);
                });

            modelBuilder.Entity("ProductMicroservice.Entities.Entities.ProductSize", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("LogMessage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("Product is added on 22-11-2024 11:42");

                    b.Property<Guid>("ProductVariantId")
                        .HasColumnType("uuid");

                    b.Property<string>("SizeCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductVariantId");

                    b.ToTable("tblProductSize", (string)null);
                });

            modelBuilder.Entity("ProductMicroservice.Entities.Entities.ProductSizeRegion", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("LogMessage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("ProductSizeRegion is added on 22-11-2024 11:42");

                    b.Property<Guid>("ProductSizeId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("RegionId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductSizeId");

                    b.ToTable("tblProductSizeRegion", (string)null);
                });

            modelBuilder.Entity("ProductMicroservice.Entities.Entities.ProductVariant", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CargoId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DeliveryDuration")
                        .HasColumnType("uuid");

                    b.Property<string>("DeliveryOption")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("LogMessage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("ProductVariant is added on 22-11-2024 11:42");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<string>("ProductVariantCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductVariantName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("tblProductVariant", (string)null);
                });

            modelBuilder.Entity("ProductMicroservice.Entities.Entities.ProductVariantPicture", b =>
                {
                    b.Property<Guid>("ProductVariantId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PictureId")
                        .HasColumnType("uuid");

                    b.HasKey("ProductVariantId", "PictureId");

                    b.HasIndex("PictureId");

                    b.ToTable("tblProductVariantPicture", (string)null);
                });

            modelBuilder.Entity("ProductMicroservice.Entities.Entities.ProductSize", b =>
                {
                    b.HasOne("ProductMicroservice.Entities.Entities.ProductVariant", "ProductVariant")
                        .WithMany("ProductSizes")
                        .HasForeignKey("ProductVariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductVariant");
                });

            modelBuilder.Entity("ProductMicroservice.Entities.Entities.ProductSizeRegion", b =>
                {
                    b.HasOne("ProductMicroservice.Entities.Entities.ProductSize", "ProductSize")
                        .WithMany("ProductSizeRegions")
                        .HasForeignKey("ProductSizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductSize");
                });

            modelBuilder.Entity("ProductMicroservice.Entities.Entities.ProductVariant", b =>
                {
                    b.HasOne("ProductMicroservice.Entities.Entities.Product", "Product")
                        .WithMany("ProductVariants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductMicroservice.Entities.Entities.ProductVariantPicture", b =>
                {
                    b.HasOne("ProductMicroservice.Entities.Entities.Picture", "Picture")
                        .WithMany("ProductVariantPictures")
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductMicroservice.Entities.Entities.ProductVariant", "ProductVariant")
                        .WithMany("ProductVariantPictures")
                        .HasForeignKey("ProductVariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Picture");

                    b.Navigation("ProductVariant");
                });

            modelBuilder.Entity("ProductMicroservice.Entities.Entities.Picture", b =>
                {
                    b.Navigation("ProductVariantPictures");
                });

            modelBuilder.Entity("ProductMicroservice.Entities.Entities.Product", b =>
                {
                    b.Navigation("ProductVariants");
                });

            modelBuilder.Entity("ProductMicroservice.Entities.Entities.ProductSize", b =>
                {
                    b.Navigation("ProductSizeRegions");
                });

            modelBuilder.Entity("ProductMicroservice.Entities.Entities.ProductVariant", b =>
                {
                    b.Navigation("ProductSizes");

                    b.Navigation("ProductVariantPictures");
                });
#pragma warning restore 612, 618
        }
    }
}
