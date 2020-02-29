﻿// <auto-generated />
using System;
using APIServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIServer.Migrations
{
    [DbContext(typeof(APIDBContext))]
    [Migration("20200229120333_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIServer.Model.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Companies");

                    b.HasData(
                        new { ID = 1, Address = "Minsk", Name = "Company 1" }
                    );
                });

            modelBuilder.Entity("APIServer.Model.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("OrderID");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProductID");

                    b.Property<DateTime>("ShipDate");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("APIServer.Model.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyID");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("APIServer.Model.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyID");

                    b.Property<string>("Country")
                        .HasMaxLength(30);

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .HasMaxLength(50);

                    b.Property<int>("Role");

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Users");

                    b.HasData(
                        new { ID = 1, Country = "BY", Email = "admin@test.com", FirstName = "Admin", LastName = "Admin", Password = "pass", Role = 0 }
                    );
                });

            modelBuilder.Entity("APIServer.Model.Order", b =>
                {
                    b.HasOne("APIServer.Model.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductID");
                });

            modelBuilder.Entity("APIServer.Model.Product", b =>
                {
                    b.HasOne("APIServer.Model.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyID");
                });

            modelBuilder.Entity("APIServer.Model.User", b =>
                {
                    b.HasOne("APIServer.Model.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyID");
                });
#pragma warning restore 612, 618
        }
    }
}
