﻿// <auto-generated />
using System;
using DoctorsSchedule.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoctorsSchedule.Migrations
{
    [DbContext(typeof(DoctorsScheduleContext))]
    [Migration("20240930132559_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("DoctorsSchedule.Models.Availability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DayId")
                        .HasColumnType("int");

                    b.Property<int>("DocId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("End")
                        .HasColumnType("time(6)");

                    b.Property<TimeSpan>("Start")
                        .HasColumnType("time(6)");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.HasIndex("DocId");

                    b.ToTable("Availabilities");
                });

            modelBuilder.Entity("DoctorsSchedule.Models.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("DoctorsSchedule.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("DoctorsSchedule.Models.Availability", b =>
                {
                    b.HasOne("DoctorsSchedule.Models.Day", "Day")
                        .WithMany("Availabilities")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorsSchedule.Models.Doctor", "Doctor")
                        .WithMany("Availabilities")
                        .HasForeignKey("DocId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Day");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("DoctorsSchedule.Models.Day", b =>
                {
                    b.Navigation("Availabilities");
                });

            modelBuilder.Entity("DoctorsSchedule.Models.Doctor", b =>
                {
                    b.Navigation("Availabilities");
                });
#pragma warning restore 612, 618
        }
    }
}
