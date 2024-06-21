﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeedWackerCoreWebApi.Context;

#nullable disable

namespace WeedWackerCoreWebApi.Migrations
{
    [DbContext(typeof(WeedWackerDbContext))]
    [Migration("20240621184958_changeCountryId")]
    partial class changeCountryId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WeedWackerCoreWebApi.Entity.Address", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AddInfo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlateCode")
                        .HasColumnType("int");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("WeedWackerCoreWebApi.Entity.City", b =>
                {
                    b.Property<int>("PlateCode")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PlateCode");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("WeedWackerCoreWebApi.Entity.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PlateCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("WeedWackerCoreWebApi.Entity.EmployerOffer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("WorkId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkId");

                    b.ToTable("EmployerOffers");
                });

            modelBuilder.Entity("WeedWackerCoreWebApi.Entity.EmployerSetting", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlateCode")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("EmployerSetting");
                });

            modelBuilder.Entity("WeedWackerCoreWebApi.Entity.Error", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Errors");
                });

            modelBuilder.Entity("WeedWackerCoreWebApi.Entity.PostCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<int>("PlateCode")
                        .HasColumnType("int");

                    b.Property<int>("QuarterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PostCodes");
                });

            modelBuilder.Entity("WeedWackerCoreWebApi.Entity.Quarter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PlateCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Quarter");
                });

            modelBuilder.Entity("WeedWackerCoreWebApi.Entity.Role", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WeedWackerCoreWebApi.Entity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("RoleId")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WeedWackerCoreWebApi.Entity.Work", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlateCode")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("WeedWackerCoreWebApi.Entity.Address", b =>
                {
                    b.HasOne("WeedWackerCoreWebApi.Entity.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("WeedWackerCoreWebApi.Entity.Address", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WeedWackerCoreWebApi.Entity.EmployerOffer", b =>
                {
                    b.HasOne("WeedWackerCoreWebApi.Entity.User", "User")
                        .WithMany("EmployerOffers")
                        .HasForeignKey("UserId");

                    b.HasOne("WeedWackerCoreWebApi.Entity.Work", "Work")
                        .WithMany("EmployerOffers")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("WeedWackerCoreWebApi.Entity.EmployerSetting", b =>
                {
                    b.HasOne("WeedWackerCoreWebApi.Entity.User", "User")
                        .WithOne("EmployerSetting")
                        .HasForeignKey("WeedWackerCoreWebApi.Entity.EmployerSetting", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WeedWackerCoreWebApi.Entity.User", b =>
                {
                    b.HasOne("WeedWackerCoreWebApi.Entity.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WeedWackerCoreWebApi.Entity.Work", b =>
                {
                    b.HasOne("WeedWackerCoreWebApi.Entity.User", "User")
                        .WithMany("Works")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WeedWackerCoreWebApi.Entity.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("WeedWackerCoreWebApi.Entity.User", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("EmployerOffers");

                    b.Navigation("EmployerSetting");

                    b.Navigation("Works");
                });

            modelBuilder.Entity("WeedWackerCoreWebApi.Entity.Work", b =>
                {
                    b.Navigation("EmployerOffers");
                });
#pragma warning restore 612, 618
        }
    }
}
