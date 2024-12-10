﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories.EFCore;

#nullable disable

namespace RentACarApp.Api.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20241209163028_UpdateUserModel")]
    partial class UpdateUserModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Admin", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("char(11)")
                        .HasColumnName("id")
                        .IsFixedLength();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("lastname");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("password")
                        .IsFixedLength();

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("Admin", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Car", b =>
                {
                    b.Property<string>("VinNumber")
                        .HasMaxLength(17)
                        .IsUnicode(false)
                        .HasColumnType("char(17)")
                        .HasColumnName("vin_number")
                        .IsFixedLength();

                    b.Property<bool>("AvailabilityStatus")
                        .HasColumnType("bit")
                        .HasColumnName("availability_status");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("brand");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("DealershipId")
                        .HasColumnType("int")
                        .HasColumnName("dealership_id");

                    b.Property<int>("FuelType")
                        .HasColumnType("int")
                        .HasColumnName("fuel_type");

                    b.Property<int>("GearType")
                        .HasColumnType("int")
                        .HasColumnName("gear_type");

                    b.Property<int>("Kilometer")
                        .HasColumnType("int")
                        .HasColumnName("kilometer");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(7)
                        .IsUnicode(false)
                        .HasColumnType("char(7)")
                        .HasColumnName("license_plate")
                        .IsFixedLength();

                    b.Property<byte>("MinAge")
                        .HasColumnType("tinyint")
                        .HasColumnName("min_age");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("model");

                    b.Property<double>("PricePerDay")
                        .HasColumnType("float")
                        .HasColumnName("price_per_day");

                    b.Property<byte>("SeatCount")
                        .HasColumnType("tinyint")
                        .HasColumnName("seat_count");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.Property<short>("Year")
                        .HasColumnType("smallint")
                        .HasColumnName("year");

                    b.HasKey("VinNumber");

                    b.HasIndex("DealershipId");

                    b.HasIndex("FuelType");

                    b.HasIndex("GearType");

                    b.ToTable("Car", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Dealership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("char(12)")
                        .HasColumnName("phone")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("Dealership", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Deleted", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdminId")
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("char(11)")
                        .HasColumnName("admin_id")
                        .IsFixedLength();

                    b.Property<string>("CarId")
                        .IsRequired()
                        .HasMaxLength(17)
                        .IsUnicode(false)
                        .HasColumnType("char(17)")
                        .HasColumnName("car_id")
                        .IsFixedLength();

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime")
                        .HasColumnName("delete_time");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("CarId");

                    b.ToTable("Deleted", (string)null);
                });

            modelBuilder.Entity("Entities.Models.FuelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("FuelType", (string)null);
                });

            modelBuilder.Entity("Entities.Models.GearType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("GearType", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdminId")
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("char(11)")
                        .HasColumnName("admin_id")
                        .IsFixedLength();

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Messaage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("messaage");

                    b.Property<string>("UserId")
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("char(11)")
                        .HasColumnName("user_id")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("UserId");

                    b.ToTable("Log", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 3)")
                        .HasColumnName("amount");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("PaymentDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("payment_date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int")
                        .HasColumnName("payment_method");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int")
                        .HasColumnName("payment_status");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int")
                        .HasColumnName("reservation_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("PaymentMethod");

                    b.HasIndex("PaymentStatus");

                    b.HasIndex("ReservationId");

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("Entities.Models.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethod", (string)null);
                });

            modelBuilder.Entity("Entities.Models.PaymentStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsSuccessful")
                        .HasColumnType("bit")
                        .HasColumnName("is_successful");

                    b.HasKey("Id");

                    b.ToTable("PaymentStatus", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CarId")
                        .IsRequired()
                        .HasMaxLength(17)
                        .IsUnicode(false)
                        .HasColumnType("char(17)")
                        .HasColumnName("car_id")
                        .IsFixedLength();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime")
                        .HasColumnName("end_date");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime")
                        .HasColumnName("start_date");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18, 3)")
                        .HasColumnName("total_price");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_date");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("char(11)")
                        .HasColumnName("user_id")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("Status");

                    b.HasIndex("UserId");

                    b.ToTable("Reservation", (string)null);
                });

            modelBuilder.Entity("Entities.Models.ReservationStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("ReservationStatus", (string)null);
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("char(11)")
                        .HasColumnName("id")
                        .IsFixedLength();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("address");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime")
                        .HasColumnName("birth_date");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("lastname");

                    b.Property<string>("LicenseNumber")
                        .IsRequired()
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("char(6)")
                        .HasColumnName("license_number")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("password")
                        .IsFixedLength();

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("char(12)")
                        .HasColumnName("phone_number")
                        .IsFixedLength();

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Car", b =>
                {
                    b.HasOne("Entities.Models.Dealership", "Dealership")
                        .WithMany("Cars")
                        .HasForeignKey("DealershipId")
                        .IsRequired()
                        .HasConstraintName("FK_Car_Dealership");

                    b.HasOne("Entities.Models.FuelType", "FuelTypeNavigation")
                        .WithMany("Cars")
                        .HasForeignKey("FuelType")
                        .IsRequired()
                        .HasConstraintName("FK_Car_FuelType");

                    b.HasOne("Entities.Models.GearType", "GearTypeNavigation")
                        .WithMany("Cars")
                        .HasForeignKey("GearType")
                        .IsRequired()
                        .HasConstraintName("FK_Car_GearType");

                    b.Navigation("Dealership");

                    b.Navigation("FuelTypeNavigation");

                    b.Navigation("GearTypeNavigation");
                });

            modelBuilder.Entity("Entities.Models.Deleted", b =>
                {
                    b.HasOne("Entities.Models.Admin", "Admin")
                        .WithMany("Deleteds")
                        .HasForeignKey("AdminId")
                        .HasConstraintName("FK_Deleted_Admin");

                    b.HasOne("Entities.Models.Car", "Car")
                        .WithMany("Deleteds")
                        .HasForeignKey("CarId")
                        .IsRequired()
                        .HasConstraintName("FK_Deleted_Car");

                    b.Navigation("Admin");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Entities.Models.Log", b =>
                {
                    b.HasOne("Entities.Models.Admin", "Admin")
                        .WithMany("Logs")
                        .HasForeignKey("AdminId")
                        .HasConstraintName("FK_Log_Admin");

                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("Logs")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Log_User");

                    b.Navigation("Admin");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.Payment", b =>
                {
                    b.HasOne("Entities.Models.PaymentMethod", "PaymentMethodNavigation")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentMethod")
                        .IsRequired()
                        .HasConstraintName("FK_Payment_PaymentMethod");

                    b.HasOne("Entities.Models.PaymentStatus", "PaymentStatusNavigation")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentStatus")
                        .IsRequired()
                        .HasConstraintName("FK_Payment_PaymentStatus");

                    b.HasOne("Entities.Models.Reservation", "Reservation")
                        .WithMany("Payments")
                        .HasForeignKey("ReservationId")
                        .IsRequired()
                        .HasConstraintName("FK_Payment_Reservation");

                    b.Navigation("PaymentMethodNavigation");

                    b.Navigation("PaymentStatusNavigation");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("Entities.Models.Reservation", b =>
                {
                    b.HasOne("Entities.Models.Car", "Car")
                        .WithMany("Reservations")
                        .HasForeignKey("CarId")
                        .IsRequired()
                        .HasConstraintName("FK_Reservation_Car");

                    b.HasOne("Entities.Models.ReservationStatus", "StatusNavigation")
                        .WithMany("Reservations")
                        .HasForeignKey("Status")
                        .IsRequired()
                        .HasConstraintName("FK_Reservation_ReservationStatus");

                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Reservation_User");

                    b.Navigation("Car");

                    b.Navigation("StatusNavigation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.Admin", b =>
                {
                    b.Navigation("Deleteds");

                    b.Navigation("Logs");
                });

            modelBuilder.Entity("Entities.Models.Car", b =>
                {
                    b.Navigation("Deleteds");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Entities.Models.Dealership", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Entities.Models.FuelType", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Entities.Models.GearType", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Entities.Models.PaymentMethod", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Entities.Models.PaymentStatus", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Entities.Models.Reservation", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Entities.Models.ReservationStatus", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Navigation("Logs");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
