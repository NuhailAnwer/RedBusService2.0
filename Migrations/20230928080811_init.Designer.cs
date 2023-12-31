﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RedBusService2._0;

#nullable disable

namespace RedBusService2._0.Migrations
{
    [DbContext(typeof(BDbContext))]
    [Migration("20230928080811_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RedBusService2._0.Entities.Bus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("DriverId")
                        .HasColumnType("integer");

                    b.Property<int>("MaintainenceStates")
                        .HasColumnType("integer");

                    b.Property<int>("RouteNumber")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimeOfArrival")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("fuelLevel")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DriverId")
                        .IsUnique();

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("RedBusService2._0.Entities.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfExpiry")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DriverLicense")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DriverName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DrivingDetails")
                        .HasColumnType("integer");

                    b.Property<bool>("TrafficRuleViolation")
                        .HasColumnType("boolean");

                    b.Property<int>("YearOfExperience")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("RedBusService2._0.Entities.Bus", b =>
                {
                    b.HasOne("RedBusService2._0.Entities.Driver", "Driver")
                        .WithOne("Bus")
                        .HasForeignKey("RedBusService2._0.Entities.Bus", "DriverId");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("RedBusService2._0.Entities.Driver", b =>
                {
                    b.Navigation("Bus");
                });
#pragma warning restore 612, 618
        }
    }
}
