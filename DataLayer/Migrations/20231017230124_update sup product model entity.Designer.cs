﻿// <auto-generated />
using System;
using DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(DibaContext))]
    [Migration("20231017230124_update sup product model entity")]
    partial class updatesupproductmodelentity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataLayer.Entities.Address", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("AddressName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<int>("PostCode")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ReciverFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ReciverLastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ReciverPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Unit")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Userid");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("DataLayer.Entities.Cart", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("Orderid")
                        .HasColumnType("int");

                    b.Property<int>("SubProductid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Orderid");

                    b.HasIndex("SubProductid");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("DataLayer.Entities.CategoryProduct", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("ImageAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("Parentid")
                        .HasColumnType("int");

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.HasIndex("Parentid");

                    b.ToTable("CategoryProducts");
                });

            modelBuilder.Entity("DataLayer.Entities.Color", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("ColorCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColorValue")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("ColorProducts");
                });

            modelBuilder.Entity("DataLayer.Entities.Discount", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("DiscountEnd")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiscountPercent")
                        .HasColumnType("int");

                    b.Property<DateTime>("DiscountStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubProductid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("SubProductid");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("DataLayer.Entities.ExclusiveOffer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("OfferEnd")
                        .HasColumnType("datetime2");

                    b.Property<int>("OfferPercent")
                        .HasColumnType("int");

                    b.Property<DateTime>("OfferStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubProductid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("SubProductid");

                    b.ToTable("ExclusiveOffers");
                });

            modelBuilder.Entity("DataLayer.Entities.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFinaly")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double?>("TotalDiscount")
                        .HasColumnType("float");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DataLayer.Entities.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("CategoryProductid")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsInStock")
                        .HasColumnType("bit");

                    b.Property<string>("MainProductImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SellCount")
                        .HasColumnType("int");

                    b.Property<string>("ShortProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("CategoryProductid");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DataLayer.Entities.ProductImage", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("ImageAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Productid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Productid");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("DataLayer.Entities.ProductInfo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("ProductInfoTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProductInfoValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Productid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Productid");

                    b.ToTable("ProductInfo");
                });

            modelBuilder.Entity("DataLayer.Entities.Size", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("SizeValue")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("SizeProducts");
                });

            modelBuilder.Entity("DataLayer.Entities.Slider", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PageAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SliderImageAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SliderName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Slider");
                });

            modelBuilder.Entity("DataLayer.Entities.SubProduct", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Colorid")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DiscountEnd")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DiscountPercent")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DiscountStart")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsHaveActiveDIscount")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInStock")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductModelName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Productid")
                        .HasColumnType("int");

                    b.Property<int>("Sizeid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Colorid");

                    b.HasIndex("Productid");

                    b.HasIndex("Sizeid");

                    b.ToTable("SubProducts");
                });

            modelBuilder.Entity("DataLayer.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("IsActived")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("SMSCODE")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<Guid?>("SecurityCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataLayer.Entities.UserComment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Parentid")
                        .HasColumnType("int");

                    b.Property<int>("Productid")
                        .HasColumnType("int");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Parentid");

                    b.HasIndex("Userid");

                    b.ToTable("UserComments");
                });

            modelBuilder.Entity("DataLayer.Entities.Address", b =>
                {
                    b.HasOne("DataLayer.Entities.User", "User")
                        .WithMany("Address")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Entities.Cart", b =>
                {
                    b.HasOne("DataLayer.Entities.Order", "Order")
                        .WithMany("Carts")
                        .HasForeignKey("Orderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.SubProduct", "subproduct")
                        .WithMany("Carts")
                        .HasForeignKey("SubProductid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("subproduct");
                });

            modelBuilder.Entity("DataLayer.Entities.CategoryProduct", b =>
                {
                    b.HasOne("DataLayer.Entities.CategoryProduct", null)
                        .WithMany("CategoryProducts")
                        .HasForeignKey("Parentid");
                });

            modelBuilder.Entity("DataLayer.Entities.Discount", b =>
                {
                    b.HasOne("DataLayer.Entities.SubProduct", "SubProduct")
                        .WithMany("Discounts")
                        .HasForeignKey("SubProductid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubProduct");
                });

            modelBuilder.Entity("DataLayer.Entities.ExclusiveOffer", b =>
                {
                    b.HasOne("DataLayer.Entities.SubProduct", "SubProduct")
                        .WithMany("ExclusiveOffers")
                        .HasForeignKey("SubProductid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubProduct");
                });

            modelBuilder.Entity("DataLayer.Entities.Order", b =>
                {
                    b.HasOne("DataLayer.Entities.User", "User")
                        .WithMany("Order")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLayer.Entities.Product", b =>
                {
                    b.HasOne("DataLayer.Entities.CategoryProduct", "CategoryProduct")
                        .WithMany("Products")
                        .HasForeignKey("CategoryProductid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryProduct");
                });

            modelBuilder.Entity("DataLayer.Entities.ProductImage", b =>
                {
                    b.HasOne("DataLayer.Entities.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("Productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataLayer.Entities.ProductInfo", b =>
                {
                    b.HasOne("DataLayer.Entities.Product", "Product")
                        .WithMany("ProductInfos")
                        .HasForeignKey("Productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataLayer.Entities.SubProduct", b =>
                {
                    b.HasOne("DataLayer.Entities.Color", "Color")
                        .WithMany("SubProducts")
                        .HasForeignKey("Colorid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.Product", "Product")
                        .WithMany("SubProducts")
                        .HasForeignKey("Productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.Size", "Size")
                        .WithMany("SubProducts")
                        .HasForeignKey("Sizeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Product");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("DataLayer.Entities.UserComment", b =>
                {
                    b.HasOne("DataLayer.Entities.UserComment", "Comment")
                        .WithMany("Comments")
                        .HasForeignKey("Parentid");

                    b.HasOne("DataLayer.Entities.User", null)
                        .WithMany("Comments")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("DataLayer.Entities.CategoryProduct", b =>
                {
                    b.Navigation("CategoryProducts");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("DataLayer.Entities.Color", b =>
                {
                    b.Navigation("SubProducts");
                });

            modelBuilder.Entity("DataLayer.Entities.Order", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("DataLayer.Entities.Product", b =>
                {
                    b.Navigation("ProductImages");

                    b.Navigation("ProductInfos");

                    b.Navigation("SubProducts");
                });

            modelBuilder.Entity("DataLayer.Entities.Size", b =>
                {
                    b.Navigation("SubProducts");
                });

            modelBuilder.Entity("DataLayer.Entities.SubProduct", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Discounts");

                    b.Navigation("ExclusiveOffers");
                });

            modelBuilder.Entity("DataLayer.Entities.User", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Comments");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("DataLayer.Entities.UserComment", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
