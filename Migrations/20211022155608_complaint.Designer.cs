﻿// <auto-generated />
using System;
using BacendBulding.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BacendBulding.Migrations
{
    [DbContext(typeof(DBNewbulding))]
    [Migration("20211022155608_complaint")]
    partial class complaint
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BacendBulding.Database.Account", b =>
                {
                    b.Property<string>("Mobile")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Mobile");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BacendBulding.Database.Building", b =>
                {
                    b.Property<string>("AccountMobile")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuildingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FloorNumber")
                        .HasColumnType("int");

                    b.Property<int>("UnitNumber")
                        .HasColumnType("int");

                    b.HasKey("AccountMobile");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("BacendBulding.Database.BuildingCost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BuildingCosts");
                });

            modelBuilder.Entity("BacendBulding.Database.Complaint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResidentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ResidentId")
                        .IsUnique();

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("BacendBulding.Database.Manage", b =>
                {
                    b.Property<string>("AccountMobile")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountMobile");

                    b.ToTable("Manages");
                });

            modelBuilder.Entity("BacendBulding.Database.Resident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountMobile")
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("FloorNumber")
                        .HasColumnType("int");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountMobile")
                        .IsUnique()
                        .HasFilter("[AccountMobile] IS NOT NULL");

                    b.ToTable("Residents");
                });

            modelBuilder.Entity("BacendBulding.Database.Building", b =>
                {
                    b.HasOne("BacendBulding.Database.Manage", "Manage")
                        .WithOne("Building")
                        .HasForeignKey("BacendBulding.Database.Building", "AccountMobile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manage");
                });

            modelBuilder.Entity("BacendBulding.Database.Complaint", b =>
                {
                    b.HasOne("BacendBulding.Database.Resident", "Resident")
                        .WithOne("Complaint")
                        .HasForeignKey("BacendBulding.Database.Complaint", "ResidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resident");
                });

            modelBuilder.Entity("BacendBulding.Database.Manage", b =>
                {
                    b.HasOne("BacendBulding.Database.Account", "Account")
                        .WithOne("Manage")
                        .HasForeignKey("BacendBulding.Database.Manage", "AccountMobile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BacendBulding.Database.Resident", b =>
                {
                    b.HasOne("BacendBulding.Database.Account", "Account")
                        .WithOne("Resident")
                        .HasForeignKey("BacendBulding.Database.Resident", "AccountMobile");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BacendBulding.Database.Account", b =>
                {
                    b.Navigation("Manage");

                    b.Navigation("Resident");
                });

            modelBuilder.Entity("BacendBulding.Database.Manage", b =>
                {
                    b.Navigation("Building");
                });

            modelBuilder.Entity("BacendBulding.Database.Resident", b =>
                {
                    b.Navigation("Complaint");
                });
#pragma warning restore 612, 618
        }
    }
}
