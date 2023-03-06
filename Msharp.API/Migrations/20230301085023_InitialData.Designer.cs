﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Msharp.Infrastructure.Context;

#nullable disable

namespace Msharp.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230301085023_InitialData")]
    partial class InitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Msharp.Core.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmployeeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("FactoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("FactoryId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 32,
                            FactoryId = 1,
                            Name = "Mike Dan",
                            Position = "Car Checker"
                        },
                        new
                        {
                            Id = 2,
                            Age = 35,
                            FactoryId = 3,
                            Name = "Jhon Deo",
                            Position = "Moto Controller"
                        });
                });

            modelBuilder.Entity("Msharp.Core.Models.Factory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FactoryId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FactoryType")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("ProductionCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Factories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FactoryType = "Automobiles",
                            Location = "Germany",
                            Name = "BMW",
                            ProductionCapacity = 100
                        },
                        new
                        {
                            Id = 3,
                            FactoryType = "Motocycles",
                            Location = "Japan",
                            Name = "YAMAHA",
                            ProductionCapacity = 120
                        });
                });

            modelBuilder.Entity("Msharp.Core.Models.Employee", b =>
                {
                    b.HasOne("Msharp.Core.Models.Factory", "Factory")
                        .WithMany("Employees")
                        .HasForeignKey("FactoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factory");
                });

            modelBuilder.Entity("Msharp.Core.Models.Factory", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
