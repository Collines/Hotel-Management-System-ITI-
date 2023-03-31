﻿// <auto-generated />
using System;
using HotelManagementSystem.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelManagementSystem.Migrations.FrontendDBMigrations
{
    [DbContext(typeof(FrontendDB))]
    [Migration("20230331132135_AddingReservationEntity")]
    partial class AddingReservationEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelManagementSystem.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationID"));

                    b.Property<int>("ApartmentSuite")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<int>("Breakfast")
                        .HasColumnType("int");

                    b.Property<string>("CardCVC")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime>("CardExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CardNumber")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<byte>("CardType")
                        .HasColumnType("tinyint");

                    b.Property<bool>("CheckedIn")
                        .HasColumnType("bit");

                    b.Property<string>("City")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("Cleaning")
                        .HasColumnType("bit");

                    b.Property<int>("Dinner")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FoodBill")
                        .HasColumnType("int");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LeavingTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Lunch")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("int");

                    b.Property<byte>("PaymentType")
                        .HasColumnType("tinyint");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("RoomFloor")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<byte>("RoomType")
                        .HasColumnType("tinyint");

                    b.Property<bool>("SSurprise")
                        .HasColumnType("bit");

                    b.Property<string>("State")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("StreetAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("SupplyStatus")
                        .HasColumnType("bit");

                    b.Property<decimal>("TotalBill")
                        .HasColumnType("Money");

                    b.Property<bool>("Towel")
                        .HasColumnType("bit");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ReservationID");

                    b.ToTable("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
