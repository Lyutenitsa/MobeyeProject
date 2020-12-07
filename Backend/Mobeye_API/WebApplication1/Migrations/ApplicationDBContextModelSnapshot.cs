﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mobeye_API.Services;

namespace Mobeye_API.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DeviceUser", b =>
                {
                    b.Property<string>("DevicesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("OwnersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DevicesId", "OwnersId");

                    b.HasIndex("OwnersId");

                    b.ToTable("DeviceUser");
                });

            modelBuilder.Entity("Mobeye_API.Models.Alarm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Alarmtext")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Confirmed_Denied")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Confirmed_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ContactUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Devicename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Escalation")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Set_Reset")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeOfAlarm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountUserId");

                    b.HasIndex("ContactUserId");

                    b.ToTable("Alarms");
                });

            modelBuilder.Entity("Mobeye_API.Models.Device", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Command")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Devicename")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("Mobeye_API.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlarmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthPrivateKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneIMEI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationPrivateKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SMSCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlarmId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Mobeye_API.Models.AccountUser", b =>
                {
                    b.HasBaseType("Mobeye_API.Models.User");

                    b.HasDiscriminator().HasValue("AccountUser");
                });

            modelBuilder.Entity("Mobeye_API.Models.CallKeyUser", b =>
                {
                    b.HasBaseType("Mobeye_API.Models.User");

                    b.HasDiscriminator().HasValue("CallKeyUser");
                });

            modelBuilder.Entity("Mobeye_API.Models.ContactUser", b =>
                {
                    b.HasBaseType("Mobeye_API.Models.User");

                    b.HasDiscriminator().HasValue("ContactUser");
                });

            modelBuilder.Entity("DeviceUser", b =>
                {
                    b.HasOne("Mobeye_API.Models.Device", null)
                        .WithMany()
                        .HasForeignKey("DevicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mobeye_API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("OwnersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mobeye_API.Models.Alarm", b =>
                {
                    b.HasOne("Mobeye_API.Models.AccountUser", null)
                        .WithMany("Alarms")
                        .HasForeignKey("AccountUserId");

                    b.HasOne("Mobeye_API.Models.ContactUser", null)
                        .WithMany("Alarms")
                        .HasForeignKey("ContactUserId");
                });

            modelBuilder.Entity("Mobeye_API.Models.User", b =>
                {
                    b.HasOne("Mobeye_API.Models.Alarm", null)
                        .WithMany("Recipients")
                        .HasForeignKey("AlarmId");
                });

            modelBuilder.Entity("Mobeye_API.Models.Alarm", b =>
                {
                    b.Navigation("Recipients");
                });

            modelBuilder.Entity("Mobeye_API.Models.AccountUser", b =>
                {
                    b.Navigation("Alarms");
                });

            modelBuilder.Entity("Mobeye_API.Models.ContactUser", b =>
                {
                    b.Navigation("Alarms");
                });
#pragma warning restore 612, 618
        }
    }
}
