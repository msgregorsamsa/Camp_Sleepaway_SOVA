﻿// <auto-generated />
using System;
using Camp_Sleepaway_SOVA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Camp_Sleepaway_SOVA.Migrations
{
    [DbContext(typeof(CampContext))]
    [Migration("20231228092855_SecondCreate")]
    partial class SecondCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Camp_Sleepaway_SOVA.Cabin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cabins");
                });

            modelBuilder.Entity("Camp_Sleepaway_SOVA.Camper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CabinId")
                        .HasColumnType("int");

                    b.Property<string>("CabinName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Check_In")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Check_Out")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NextOfKinId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CabinId");

                    b.ToTable("Campers");
                });

            modelBuilder.Entity("Camp_Sleepaway_SOVA.Counselor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CabinId")
                        .HasColumnType("int");

                    b.Property<string>("CabinName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Check_In")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Check_Out")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OnCabinDuty")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CabinId")
                        .IsUnique()
                        .HasFilter("[CabinId] IS NOT NULL");

                    b.ToTable("Counselors");
                });

            modelBuilder.Entity("Camp_Sleepaway_SOVA.NextOfKin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CamperId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NextOfKins");
                });

            modelBuilder.Entity("Camp_Sleepaway_SOVA.Stay", b =>
                {
                    b.Property<int>("StayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StayId"));

                    b.Property<int>("CabinId")
                        .HasColumnType("int");

                    b.Property<int>("CamperId")
                        .HasColumnType("int");

                    b.Property<int>("CounselorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("StayId");

                    b.HasIndex("CabinId");

                    b.HasIndex("CamperId");

                    b.HasIndex("CounselorId");

                    b.ToTable("Stays");
                });

            modelBuilder.Entity("CamperNextOfKin", b =>
                {
                    b.Property<int>("CampersId")
                        .HasColumnType("int");

                    b.Property<int>("NextOfKinsId")
                        .HasColumnType("int");

                    b.HasKey("CampersId", "NextOfKinsId");

                    b.HasIndex("NextOfKinsId");

                    b.ToTable("Campers_NextOfKins", (string)null);
                });

            modelBuilder.Entity("Camp_Sleepaway_SOVA.Camper", b =>
                {
                    b.HasOne("Camp_Sleepaway_SOVA.Cabin", "Cabin")
                        .WithMany("Campers")
                        .HasForeignKey("CabinId");

                    b.Navigation("Cabin");
                });

            modelBuilder.Entity("Camp_Sleepaway_SOVA.Counselor", b =>
                {
                    b.HasOne("Camp_Sleepaway_SOVA.Cabin", "Cabin")
                        .WithOne("Counselor")
                        .HasForeignKey("Camp_Sleepaway_SOVA.Counselor", "CabinId");

                    b.Navigation("Cabin");
                });

            modelBuilder.Entity("Camp_Sleepaway_SOVA.Stay", b =>
                {
                    b.HasOne("Camp_Sleepaway_SOVA.Cabin", "Cabin")
                        .WithMany("Stays")
                        .HasForeignKey("CabinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Camp_Sleepaway_SOVA.Camper", "Camper")
                        .WithMany("Stays")
                        .HasForeignKey("CamperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Camp_Sleepaway_SOVA.Counselor", "Counselor")
                        .WithMany("Stays")
                        .HasForeignKey("CounselorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cabin");

                    b.Navigation("Camper");

                    b.Navigation("Counselor");
                });

            modelBuilder.Entity("CamperNextOfKin", b =>
                {
                    b.HasOne("Camp_Sleepaway_SOVA.Camper", null)
                        .WithMany()
                        .HasForeignKey("CampersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Camp_Sleepaway_SOVA.NextOfKin", null)
                        .WithMany()
                        .HasForeignKey("NextOfKinsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Camp_Sleepaway_SOVA.Cabin", b =>
                {
                    b.Navigation("Campers");

                    b.Navigation("Counselor")
                        .IsRequired();

                    b.Navigation("Stays");
                });

            modelBuilder.Entity("Camp_Sleepaway_SOVA.Camper", b =>
                {
                    b.Navigation("Stays");
                });

            modelBuilder.Entity("Camp_Sleepaway_SOVA.Counselor", b =>
                {
                    b.Navigation("Stays");
                });
#pragma warning restore 612, 618
        }
    }
}
