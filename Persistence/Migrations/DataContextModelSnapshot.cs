﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Domain.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CheckOutDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ISBN")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("OverDueDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Author = "Book 1 Author",
                            ISBN = "123456789",
                            Title = "Book 1"
                        },
                        new
                        {
                            BookId = 2,
                            Author = "Book 2 Author",
                            ISBN = "987654321",
                            Title = "Book 2"
                        },
                        new
                        {
                            BookId = 3,
                            Author = "Book 3 Author",
                            ISBN = "345692817",
                            Title = "Book 3"
                        },
                        new
                        {
                            BookId = 4,
                            Author = "Book 4 Author",
                            ISBN = "248728749",
                            Title = "Book 4"
                        });
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsLibrerian")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "user1@gmail.com",
                            FirstName = "User 1",
                            IsLibrerian = true,
                            LastName = "Librarian",
                            Password = "12345"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "user2@gmail.com",
                            FirstName = "User 2",
                            IsLibrerian = false,
                            LastName = "NormalUser",
                            Password = "12345"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "user3@gmail.com",
                            FirstName = "User 3",
                            IsLibrerian = false,
                            LastName = "NormalUser",
                            Password = "12345"
                        },
                        new
                        {
                            UserId = 4,
                            Email = "user4@gmail.com",
                            FirstName = "User 4",
                            IsLibrerian = false,
                            LastName = "NormalUser",
                            Password = "12345"
                        });
                });

            modelBuilder.Entity("Domain.Book", b =>
                {
                    b.HasOne("Domain.User", "User")
                        .WithMany("Books")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
