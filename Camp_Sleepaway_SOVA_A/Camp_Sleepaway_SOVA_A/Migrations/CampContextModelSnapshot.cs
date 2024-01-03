﻿// <auto-generated />
using System;
using Camp_Sleepaway_SOVA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Camp_Sleepaway_SOVA.Migrations
{
    [DbContext(typeof(CampContext))]
    partial class CampContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(450)");

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

                    b.Property<string>("CabinName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateOnly?>("Check_In")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("Check_Out")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParticipantTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CabinName");

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

                    b.Property<string>("CabinName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateOnly?>("Check_In")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("Check_Out")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

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

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CabinName")
                        .IsUnique()
                        .HasFilter("[CabinName] IS NOT NULL");

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

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

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

                    b.Property<string>("Relationship")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NextOfKins");
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
                        .HasForeignKey("CabinName")
                        .HasPrincipalKey("Name")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cabin");
                });

            modelBuilder.Entity("Camp_Sleepaway_SOVA.Counselor", b =>
                {
                    b.HasOne("Camp_Sleepaway_SOVA.Cabin", "Cabin")
                        .WithOne("Counselor")
                        .HasForeignKey("Camp_Sleepaway_SOVA.Counselor", "CabinName")
                        .HasPrincipalKey("Camp_Sleepaway_SOVA.Cabin", "Name");

                    b.Navigation("Cabin");
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

                    b.Navigation("Counselor");
                });
#pragma warning restore 612, 618
        }
    }
}
