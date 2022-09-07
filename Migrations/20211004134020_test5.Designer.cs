﻿// <auto-generated />
using BacendBulding.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BacendBulding.Migrations
{
    [DbContext(typeof(DBNewbulding))]
    [Migration("20211004134020_test5")]
    partial class test5
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

            modelBuilder.Entity("BacendBulding.Database.Building", b =>
                {
                    b.HasOne("BacendBulding.Database.Manage", "Manage")
                        .WithOne("Building")
                        .HasForeignKey("BacendBulding.Database.Building", "AccountMobile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manage");
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

            modelBuilder.Entity("BacendBulding.Database.Account", b =>
                {
                    b.Navigation("Manage");
                });

            modelBuilder.Entity("BacendBulding.Database.Manage", b =>
                {
                    b.Navigation("Building");
                });
#pragma warning restore 612, 618
        }
    }
}
