﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UcakBiletim.DataAccess.Contexts;

namespace UcakBiletim.DataAccess.Migrations
{
    [DbContext(typeof(UcakBiletimContext))]
    [Migration("20221219170510_ReservationTblRelations1")]
    partial class ReservationTblRelations1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UcakBiletim.Entities.Concrete.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("From")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("UcakBiletim.Entities.Concrete.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreditCardCvc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreditCardExpirationDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreditCardHolderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreditCardNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartureFlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("PassengerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ReservationNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                    b.Property<int?>("ReturnFlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartureFlightId");

                    b.HasIndex("ReturnFlightId")
                        .IsUnique()
                        .HasFilter("[ReturnFlightId] IS NOT NULL");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("UcakBiletim.Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UcakBiletim.Entities.Concrete.Reservation", b =>
                {
                    b.HasOne("UcakBiletim.Entities.Concrete.Flight", "DepartureFlight")
                        .WithMany()
                        .HasForeignKey("DepartureFlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UcakBiletim.Entities.Concrete.Flight", "ReturnFlight")
                        .WithOne()
                        .HasForeignKey("UcakBiletim.Entities.Concrete.Reservation", "ReturnFlightId");
                });
#pragma warning restore 612, 618
        }
    }
}
