﻿// <auto-generated />
using System;
using AnindaKapinda.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnindaKapinda.DAL.Migrations
{
    [DbContext(typeof(AnindaKapindaDbContext))]
    partial class AnindaKapindaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AnindaKapinda.DAL.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MemberID")
                        .HasColumnType("int");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MemberID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.CreditCard", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Expiry")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MemberID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Secure")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MemberID");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressID")
                        .HasColumnType("int");

                    b.Property<int?>("CourierID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.HasIndex("CourierID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Desciption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Discount")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAccountActive")
                        .HasColumnType("bit");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MemberOrder", b =>
                {
                    b.Property<int>("MembersID")
                        .HasColumnType("int");

                    b.Property<int>("OrdersID")
                        .HasColumnType("int");

                    b.HasKey("MembersID", "OrdersID");

                    b.HasIndex("OrdersID");

                    b.ToTable("MemberOrder");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<int>("OrdersID")
                        .HasColumnType("int");

                    b.Property<int>("ProductsID")
                        .HasColumnType("int");

                    b.HasKey("OrdersID", "ProductsID");

                    b.HasIndex("ProductsID");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Employee", b =>
                {
                    b.HasBaseType("AnindaKapinda.DAL.User");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Member", b =>
                {
                    b.HasBaseType("AnindaKapinda.DAL.User");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Courier", b =>
                {
                    b.HasBaseType("AnindaKapinda.DAL.Employee");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Couriers");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.SupplyOfficer", b =>
                {
                    b.HasBaseType("AnindaKapinda.DAL.Employee");

                    b.ToTable("SupplyOfficers");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Address", b =>
                {
                    b.HasOne("AnindaKapinda.DAL.Member", "Member")
                        .WithMany("Addresses")
                        .HasForeignKey("MemberID");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.CreditCard", b =>
                {
                    b.HasOne("AnindaKapinda.DAL.Member", "Member")
                        .WithMany("CreditCards")
                        .HasForeignKey("MemberID");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Order", b =>
                {
                    b.HasOne("AnindaKapinda.DAL.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID");

                    b.HasOne("AnindaKapinda.DAL.Courier", "Courier")
                        .WithMany("Orders")
                        .HasForeignKey("CourierID");

                    b.Navigation("Address");

                    b.Navigation("Courier");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Product", b =>
                {
                    b.HasOne("AnindaKapinda.DAL.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MemberOrder", b =>
                {
                    b.HasOne("AnindaKapinda.DAL.Member", null)
                        .WithMany()
                        .HasForeignKey("MembersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnindaKapinda.DAL.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("AnindaKapinda.DAL.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnindaKapinda.DAL.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Employee", b =>
                {
                    b.HasOne("AnindaKapinda.DAL.User", null)
                        .WithOne()
                        .HasForeignKey("AnindaKapinda.DAL.Employee", "ID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Member", b =>
                {
                    b.HasOne("AnindaKapinda.DAL.User", null)
                        .WithOne()
                        .HasForeignKey("AnindaKapinda.DAL.Member", "ID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Courier", b =>
                {
                    b.HasOne("AnindaKapinda.DAL.Employee", null)
                        .WithOne()
                        .HasForeignKey("AnindaKapinda.DAL.Courier", "ID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnindaKapinda.DAL.SupplyOfficer", b =>
                {
                    b.HasOne("AnindaKapinda.DAL.Employee", null)
                        .WithOne()
                        .HasForeignKey("AnindaKapinda.DAL.SupplyOfficer", "ID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Member", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("CreditCards");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Courier", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
