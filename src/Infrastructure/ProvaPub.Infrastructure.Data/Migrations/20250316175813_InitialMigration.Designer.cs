﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProvaPub.Infrastructure.Data.Contexts;

#nullable disable

namespace ProvaPub.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ProvaPubContext))]
    [Migration("20250316175813_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProvaPub.Infrastructure.Data.Models.CustomerModel", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = new Guid("747cb2c4-284a-4b0b-b112-5240948c8f35"),
                            Name = "Customer 1"
                        },
                        new
                        {
                            CustomerId = new Guid("d056c7ca-2cbe-42f0-84ee-f0b9e314ba03"),
                            Name = "Customer 2"
                        },
                        new
                        {
                            CustomerId = new Guid("6aa0b12c-a645-4a91-8468-e865dfa3fd3e"),
                            Name = "Customer 3"
                        },
                        new
                        {
                            CustomerId = new Guid("d12a7211-4580-4e25-b8b2-be08232c9afc"),
                            Name = "Customer 4"
                        },
                        new
                        {
                            CustomerId = new Guid("6ec8a7f9-2987-432f-b2a3-b56ff491a11d"),
                            Name = "Customer 5"
                        },
                        new
                        {
                            CustomerId = new Guid("dc0c6034-8351-41ca-bdf8-37931f78993d"),
                            Name = "Customer 6"
                        },
                        new
                        {
                            CustomerId = new Guid("dc533d52-a956-411a-9ac8-490963d8793f"),
                            Name = "Customer 7"
                        },
                        new
                        {
                            CustomerId = new Guid("6c52d19b-6070-401e-9a42-a0f188972e36"),
                            Name = "Customer 8"
                        },
                        new
                        {
                            CustomerId = new Guid("0db09350-9a3c-40c1-bcfa-603acec7b65d"),
                            Name = "Customer 9"
                        },
                        new
                        {
                            CustomerId = new Guid("70afbd9a-bb53-4950-9225-be467c81f081"),
                            Name = "Customer 10"
                        },
                        new
                        {
                            CustomerId = new Guid("15e0454b-8378-4423-9374-947d7c1a0cb1"),
                            Name = "Customer 11"
                        },
                        new
                        {
                            CustomerId = new Guid("5bd20719-ebc8-44ac-8890-adacfdd00c0b"),
                            Name = "Customer 12"
                        },
                        new
                        {
                            CustomerId = new Guid("f1c3f2f8-1100-47f2-863a-dd9922e87f81"),
                            Name = "Customer 13"
                        },
                        new
                        {
                            CustomerId = new Guid("d65859b1-61c1-4096-8a48-b4aa1c95bccc"),
                            Name = "Customer 14"
                        },
                        new
                        {
                            CustomerId = new Guid("f5b5bf67-8156-482f-8877-1f248572a55d"),
                            Name = "Customer 15"
                        },
                        new
                        {
                            CustomerId = new Guid("e304e618-855e-434f-a65d-9939f0788988"),
                            Name = "Customer 16"
                        },
                        new
                        {
                            CustomerId = new Guid("588d58ad-7648-4cc5-897b-3be539d2a068"),
                            Name = "Customer 17"
                        },
                        new
                        {
                            CustomerId = new Guid("43749f94-bb6a-4219-b491-d9076b8f44d9"),
                            Name = "Customer 18"
                        },
                        new
                        {
                            CustomerId = new Guid("65415a69-67dd-42fa-b46e-000a5761c09e"),
                            Name = "Customer 19"
                        },
                        new
                        {
                            CustomerId = new Guid("1040c9f9-7f56-4c5d-90ac-d3b69bee8a15"),
                            Name = "Customer 20"
                        });
                });

            modelBuilder.Entity("ProvaPub.Infrastructure.Data.Models.OrderModel", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasPrecision(28, 2)
                        .HasColumnType("decimal(28,2)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ProvaPub.Infrastructure.Data.Models.ProductModel", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("b9cbf743-f5e8-47a5-b23d-51b311b0bf87"),
                            Name = "Product 1"
                        },
                        new
                        {
                            ProductId = new Guid("215cf962-f89d-4f88-ad4a-62b5313707d8"),
                            Name = "Product 2"
                        },
                        new
                        {
                            ProductId = new Guid("80ef4535-eeb4-41e0-9323-6ace9757b828"),
                            Name = "Product 3"
                        },
                        new
                        {
                            ProductId = new Guid("0d7e9aa8-50d7-4966-adb0-3553175a7d24"),
                            Name = "Product 4"
                        },
                        new
                        {
                            ProductId = new Guid("bb80b4d3-cfaf-4974-ba23-cfa636659171"),
                            Name = "Product 5"
                        },
                        new
                        {
                            ProductId = new Guid("bea89c8e-1904-4b3b-96c5-726e75dc84a1"),
                            Name = "Product 6"
                        },
                        new
                        {
                            ProductId = new Guid("6ef8ffb6-72dc-4a1f-85d0-e7b9238865ac"),
                            Name = "Product 7"
                        },
                        new
                        {
                            ProductId = new Guid("8053622f-2ac1-47de-af76-a1817500f54b"),
                            Name = "Product 8"
                        },
                        new
                        {
                            ProductId = new Guid("eeec841c-e3b5-48dc-9607-d8ec85a76639"),
                            Name = "Product 9"
                        },
                        new
                        {
                            ProductId = new Guid("c1bfbc67-3988-4c21-899a-74fb4f6bd96d"),
                            Name = "Product 10"
                        },
                        new
                        {
                            ProductId = new Guid("22474301-3380-4936-87f2-b5a1b1e3413b"),
                            Name = "Product 11"
                        },
                        new
                        {
                            ProductId = new Guid("3b480b89-17d9-412c-a057-d47792aa742a"),
                            Name = "Product 12"
                        },
                        new
                        {
                            ProductId = new Guid("b8b52983-9643-41d9-99d0-b5a739187274"),
                            Name = "Product 13"
                        },
                        new
                        {
                            ProductId = new Guid("080711bd-8395-4004-b79f-5fcbc9f9c06a"),
                            Name = "Product 14"
                        },
                        new
                        {
                            ProductId = new Guid("109d9239-a22b-4aa0-82d6-f6227c54c9a4"),
                            Name = "Product 15"
                        },
                        new
                        {
                            ProductId = new Guid("ea03c9e0-4ac2-4b72-a0fb-7a554fab784d"),
                            Name = "Product 16"
                        },
                        new
                        {
                            ProductId = new Guid("f03aad02-3b57-4e39-9fb6-ff31a17beb0e"),
                            Name = "Product 17"
                        },
                        new
                        {
                            ProductId = new Guid("5f86effc-a076-446d-abfc-b4bb9852fc34"),
                            Name = "Product 18"
                        },
                        new
                        {
                            ProductId = new Guid("6a385b22-5af2-4184-98e6-64bc45aef7a3"),
                            Name = "Product 19"
                        },
                        new
                        {
                            ProductId = new Guid("60297082-67d5-48d3-b6dd-5ccf4d1b7bc8"),
                            Name = "Product 20"
                        });
                });

            modelBuilder.Entity("ProvaPub.Infrastructure.Data.Models.RandomNumberModel", b =>
                {
                    b.Property<Guid>("RandomNumberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("RandomNumberId");

                    b.HasIndex("Number")
                        .IsUnique();

                    b.ToTable("RandomNumbers");
                });

            modelBuilder.Entity("ProvaPub.Infrastructure.Data.Models.OrderModel", b =>
                {
                    b.HasOne("ProvaPub.Infrastructure.Data.Models.CustomerModel", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ProvaPub.Infrastructure.Data.Models.CustomerModel", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
