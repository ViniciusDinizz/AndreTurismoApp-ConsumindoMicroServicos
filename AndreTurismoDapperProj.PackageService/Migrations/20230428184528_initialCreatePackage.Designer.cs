﻿// <auto-generated />
using System;
using AndreTurismoDapperProj.PackageService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AndreTurismoDapperProj.PackageService.Migrations
{
    [DbContext(typeof(AndreTurismoDapperProjPackageServiceContext))]
    [Migration("20230428184528_initialCreatePackage")]
    partial class initialCreatePackage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AndreTurismoDapperProj.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Burgh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DtRegister")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCityId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCityId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("AndreTurismoDapperProj.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("AndreTurismoDapperProj.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdAddressId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("AndreTurismoDapperProj.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdAddressId");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("AndreTurismoDapperProj.Models.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("IdHotelId")
                        .HasColumnType("int");

                    b.Property<int>("IdTicketId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdCustomerId");

                    b.HasIndex("IdHotelId");

                    b.HasIndex("IdTicketId");

                    b.ToTable("Package");
                });

            modelBuilder.Entity("AndreTurismoDapperProj.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DtRegister")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDestinId")
                        .HasColumnType("int");

                    b.Property<int>("IdOriginId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdDestinId");

                    b.HasIndex("IdOriginId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("AndreTurismoDapperProj.Models.Address", b =>
                {
                    b.HasOne("AndreTurismoDapperProj.Models.City", "IdCity")
                        .WithMany()
                        .HasForeignKey("IdCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdCity");
                });

            modelBuilder.Entity("AndreTurismoDapperProj.Models.Customer", b =>
                {
                    b.HasOne("AndreTurismoDapperProj.Models.Address", "IdAddress")
                        .WithMany()
                        .HasForeignKey("IdAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdAddress");
                });

            modelBuilder.Entity("AndreTurismoDapperProj.Models.Hotel", b =>
                {
                    b.HasOne("AndreTurismoDapperProj.Models.Address", "IdAddress")
                        .WithMany()
                        .HasForeignKey("IdAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdAddress");
                });

            modelBuilder.Entity("AndreTurismoDapperProj.Models.Package", b =>
                {
                    b.HasOne("AndreTurismoDapperProj.Models.Customer", "IdCustomer")
                        .WithMany()
                        .HasForeignKey("IdCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AndreTurismoDapperProj.Models.Hotel", "IdHotel")
                        .WithMany()
                        .HasForeignKey("IdHotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AndreTurismoDapperProj.Models.Ticket", "IdTicket")
                        .WithMany()
                        .HasForeignKey("IdTicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdCustomer");

                    b.Navigation("IdHotel");

                    b.Navigation("IdTicket");
                });

            modelBuilder.Entity("AndreTurismoDapperProj.Models.Ticket", b =>
                {
                    b.HasOne("AndreTurismoDapperProj.Models.Address", "IdDestin")
                        .WithMany()
                        .HasForeignKey("IdDestinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AndreTurismoDapperProj.Models.Address", "IdOrigin")
                        .WithMany()
                        .HasForeignKey("IdOriginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdDestin");

                    b.Navigation("IdOrigin");
                });
#pragma warning restore 612, 618
        }
    }
}