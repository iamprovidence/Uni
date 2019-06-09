﻿// <auto-generated />
using System;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.Entities.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.Property<bool?>("HasUserBeenNotified");

                    b.Property<string>("MainPhoto")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("Price");

                    b.Property<DateTime?>("RentEndDate")
                        .HasColumnType("date");

                    b.Property<int?>("RenterId");

                    b.HasKey("Id");

                    b.HasIndex("RenterId");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("DataAccess.Entities.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApartmentId");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<int>("PaymentStatus");

                    b.Property<int?>("RenterId");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("RenterId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("DataAccess.Entities.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("EmergencyLevel");

                    b.Property<int?>("ResidentId");

                    b.HasKey("Id");

                    b.HasIndex("ResidentId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("DataAccess.Entities.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApartmentId");

                    b.Property<int?>("ResidentId");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("ResidentId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int?>("ManagerId");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("Role");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, Email = "admin@gmail.com", FirstName = "Admin", LastName = "Admin", Password = "1111", Role = 2 },
                        new { Id = 2, Email = "manager@gmail.com", FirstName = "Manager", LastName = "Manager", Password = "1111", Role = 1 }
                    );
                });

            modelBuilder.Entity("DataAccess.Entities.Apartment", b =>
                {
                    b.HasOne("DataAccess.Entities.User", "Renter")
                        .WithMany("Apartments")
                        .HasForeignKey("RenterId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("DataAccess.Entities.Bill", b =>
                {
                    b.HasOne("DataAccess.Entities.Apartment", "Apartment")
                        .WithMany("Bills")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Entities.User", "Renter")
                        .WithMany("Bills")
                        .HasForeignKey("RenterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Entities.Notification", b =>
                {
                    b.HasOne("DataAccess.Entities.User", "Resident")
                        .WithMany("Notifications")
                        .HasForeignKey("ResidentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Entities.Request", b =>
                {
                    b.HasOne("DataAccess.Entities.Apartment", "Apartment")
                        .WithMany("Requests")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Entities.User", "Resident")
                        .WithMany("Requests")
                        .HasForeignKey("ResidentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Entities.User", b =>
                {
                    b.HasOne("DataAccess.Entities.User", "Manager")
                        .WithMany("Resident")
                        .HasForeignKey("ManagerId");
                });
#pragma warning restore 612, 618
        }
    }
}