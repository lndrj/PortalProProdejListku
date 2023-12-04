﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portal.Infrastructure.Database;

#nullable disable

namespace Portal.Infrastructure.Migrations
{
    [DbContext(typeof(PortalDBContext))]
    [Migration("20231121141900_mysql_1.1.0")]
    partial class mysql_110
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Portal.Domain.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2023, 11, 21, 15, 19, 0, 386, DateTimeKind.Local).AddTicks(4784),
                            Email = "john.doe@example.com",
                            FirstName = "John",
                            IsAdmin = true,
                            LastName = "Doe",
                            Password = "password123",
                            PhoneNumber = "123456789"
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2023, 11, 21, 15, 19, 0, 386, DateTimeKind.Local).AddTicks(4840),
                            Email = "alice.smith@example.com",
                            FirstName = "Alice",
                            IsAdmin = false,
                            LastName = "Smith",
                            Password = "securepassword",
                            PhoneNumber = "987654321"
                        },
                        new
                        {
                            Id = 3,
                            DateCreated = new DateTime(2023, 11, 21, 15, 19, 0, 386, DateTimeKind.Local).AddTicks(4843),
                            Email = "bob.johnson@example.com",
                            FirstName = "Bob",
                            IsAdmin = true,
                            LastName = "Johnson",
                            Password = "bobpassword",
                            PhoneNumber = "555555555"
                        });
                });

            modelBuilder.Entity("Portal.Domain.Entities.AdminRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Request")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Solved")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Requests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Request = "První žádost na admina.",
                            Solved = false
                        },
                        new
                        {
                            Id = 2,
                            Request = "Druhá žádost na admina.",
                            Solved = true
                        },
                        new
                        {
                            Id = 3,
                            Request = "Třetí žádost na admina.",
                            Solved = false
                        });
                });

            modelBuilder.Entity("Portal.Domain.Entities.Akce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Akces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Jídlo",
                            ImageSrc = "/img/product/produkty-01.jpg",
                            Name = "Rohlík",
                            Price = 2.0
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Nejlepší chleba",
                            ImageSrc = "/img/product/produkty-02.jpg",
                            Name = "Chleba",
                            Price = 30.0
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Vánoce",
                            ImageSrc = "/img/product/produkty-03.jpg",
                            Name = "Vánočka",
                            Price = 60.0
                        });
                });

            modelBuilder.Entity("Portal.Domain.Entities.Carousel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ImageAlt")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Carousels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageAlt = "First slide",
                            ImageSrc = "/img/carousel/how-to-become-an-information-technology-specialist160684886950141.jpg"
                        },
                        new
                        {
                            Id = 2,
                            ImageAlt = "Second slide",
                            ImageSrc = "/img/carousel/Information-Technology-1-1.jpg"
                        },
                        new
                        {
                            Id = 3,
                            ImageAlt = "Third slide",
                            ImageSrc = "/img/carousel/itec-index-banner.jpg"
                        });
                });

            modelBuilder.Entity("Portal.Domain.Entities.Diskuze", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AkceID")
                        .HasColumnType("int");

                    b.Property<string>("Komentar")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Discussions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AkceID = 1,
                            Komentar = "První komentář k akci 1.",
                            UserID = 1
                        },
                        new
                        {
                            Id = 2,
                            AkceID = 1,
                            Komentar = "Druhý komentář k akci 1.",
                            UserID = 2
                        },
                        new
                        {
                            Id = 3,
                            AkceID = 2,
                            Komentar = "Komentář k akci 2.",
                            UserID = 3
                        });
                });

            modelBuilder.Entity("Portal.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Portal.Domain.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AkceID")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("AkceID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Portal.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("Portal.Domain.Entities.Akce", "Akce")
                        .WithMany()
                        .HasForeignKey("AkceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portal.Domain.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Akce");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Portal.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
