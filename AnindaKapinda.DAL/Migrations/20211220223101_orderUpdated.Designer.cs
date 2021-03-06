// <auto-generated />
using System;
using AnindaKapinda.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnindaKapinda.DAL.Migrations
{
    [DbContext(typeof(AnindaKapindaDbContext))]
    [Migration("20211220223101_orderUpdated")]
    partial class orderUpdated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AnindaKapinda.DAL.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.HasIndex("MemberId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.CreditCard", b =>
                {
                    b.Property<int>("CreditCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Expiry")
                        .HasColumnType("datetime2");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Secure")
                        .HasColumnType("int");

                    b.HasKey("CreditCardId");

                    b.HasIndex("MemberId");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourierId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.HasIndex("CourierId");

                    b.HasIndex("MemberId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Desciption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegionId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.User", b =>
                {
                    b.Property<int>("UserId")
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

                    b.HasKey("UserId");

                    b.ToTable("Users");
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
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.CreditCard", b =>
                {
                    b.HasOne("AnindaKapinda.DAL.Member", "Member")
                        .WithMany("CreditCards")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Order", b =>
                {
                    b.HasOne("AnindaKapinda.DAL.Courier", "Courier")
                        .WithMany("Orders")
                        .HasForeignKey("CourierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnindaKapinda.DAL.Member", "Member")
                        .WithMany("Orders")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courier");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.OrderDetail", b =>
                {
                    b.HasOne("AnindaKapinda.DAL.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnindaKapinda.DAL.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Product", b =>
                {
                    b.HasOne("AnindaKapinda.DAL.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Employee", b =>
                {
                    b.HasOne("AnindaKapinda.DAL.User", null)
                        .WithOne()
                        .HasForeignKey("AnindaKapinda.DAL.Employee", "UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Member", b =>
                {
                    b.HasOne("AnindaKapinda.DAL.User", null)
                        .WithOne()
                        .HasForeignKey("AnindaKapinda.DAL.Member", "UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Courier", b =>
                {
                    b.HasOne("AnindaKapinda.DAL.Employee", null)
                        .WithOne()
                        .HasForeignKey("AnindaKapinda.DAL.Courier", "UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnindaKapinda.DAL.SupplyOfficer", b =>
                {
                    b.HasOne("AnindaKapinda.DAL.Employee", null)
                        .WithOne()
                        .HasForeignKey("AnindaKapinda.DAL.SupplyOfficer", "UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Member", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("CreditCards");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("AnindaKapinda.DAL.Courier", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
