﻿// <auto-generated />
using System;
using EshopOnline.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EshopOnline.Infra.Data.Migrations
{
    [DbContext(typeof(EshopOnlineContext))]
    partial class EshopOnlineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EshopOnline.Domain.Entities.AdditiveProduct", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("AdditiveProduct");
                });

            modelBuilder.Entity("EshopOnline.Domain.Entities.Propertis", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("TitleID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TitleID");

                    b.ToTable("Propertis");
                });

            modelBuilder.Entity("EshopOnline.Domain.Entities.PropertisProduct", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("PropertiseID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.HasIndex("PropertiseID");

                    b.ToTable("PropertisProducts");
                });

            modelBuilder.Entity("EshopOnline.Domain.Entities.PropertisTitle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("PropertiseTitles");
                });

            modelBuilder.Entity("EshopOnline.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EshopOnline.Domain.Entities.AdditiveProduct", b =>
                {
                    b.HasOne("EshopOnline.Domain.Models.Product", "Product")
                        .WithMany("AdditiveProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EshopOnline.Domain.Entities.Propertis", b =>
                {
                    b.HasOne("EshopOnline.Domain.Entities.PropertisTitle", "PropertiseTitle")
                        .WithMany("Propertises")
                        .HasForeignKey("TitleID");

                    b.Navigation("PropertiseTitle");
                });

            modelBuilder.Entity("EshopOnline.Domain.Entities.PropertisProduct", b =>
                {
                    b.HasOne("EshopOnline.Domain.Models.Product", "Product")
                        .WithMany("PropertisProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EshopOnline.Domain.Entities.Propertis", "Propertis")
                        .WithMany("PropertisProducts")
                        .HasForeignKey("PropertiseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Propertis");
                });

            modelBuilder.Entity("EshopOnline.Domain.Entities.Propertis", b =>
                {
                    b.Navigation("PropertisProducts");
                });

            modelBuilder.Entity("EshopOnline.Domain.Entities.PropertisTitle", b =>
                {
                    b.Navigation("Propertises");
                });

            modelBuilder.Entity("EshopOnline.Domain.Models.Product", b =>
                {
                    b.Navigation("AdditiveProducts");

                    b.Navigation("PropertisProducts");
                });
#pragma warning restore 612, 618
        }
    }
}