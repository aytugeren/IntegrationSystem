﻿// <auto-generated />
using System;
using AttributeService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AttributeService.Migrations
{
    [DbContext(typeof(AttributeDbContext))]
    [Migration("20250220173843_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AttributeService.Models.Attribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("AttributeService.Models.AttributeValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AttributeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.ToTable("AttributeValues");
                });

            modelBuilder.Entity("AttributeService.Models.ProductAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AttributeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AttributeValueId")
                        .HasColumnType("uuid");

                    b.Property<string>("CustomValue")
                        .HasColumnType("text");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("AttributeValueId");

                    b.ToTable("ProductAttributes");
                });

            modelBuilder.Entity("AttributeService.Models.AttributeValue", b =>
                {
                    b.HasOne("AttributeService.Models.Attribute", "Attribute")
                        .WithMany("AttributeValues")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attribute");
                });

            modelBuilder.Entity("AttributeService.Models.ProductAttribute", b =>
                {
                    b.HasOne("AttributeService.Models.Attribute", "Attribute")
                        .WithMany("ProductAttributes")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AttributeService.Models.AttributeValue", "AttributeValue")
                        .WithMany()
                        .HasForeignKey("AttributeValueId");

                    b.Navigation("Attribute");

                    b.Navigation("AttributeValue");
                });

            modelBuilder.Entity("AttributeService.Models.Attribute", b =>
                {
                    b.Navigation("AttributeValues");

                    b.Navigation("ProductAttributes");
                });
#pragma warning restore 612, 618
        }
    }
}
