﻿// <auto-generated />
using System;
using FatecAppBackend.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FatecAppBackend.Infra.Data.Migrations
{
    [DbContext(typeof(FatecAppBackendContext))]
    partial class FatecAppBackendContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FatecAppBackend.Domain.Entities.College", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Localization")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Colleges", (string)null);
                });

            modelBuilder.Entity("FatecAppBackend.Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EventOwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("OnlyWomen")
                        .HasColumnType("bit");

                    b.Property<string>("Route")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("TimeToGo")
                        .HasColumnType("DateTime");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EventOwnerId");

                    b.ToTable("Events", (string)null);
                });

            modelBuilder.Entity("FatecAppBackend.Domain.Entities.Participant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserCollegeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserCollegeId");

                    b.ToTable("Participants", (string)null);
                });

            modelBuilder.Entity("FatecAppBackend.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("IdentityDocumentNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("IdentityDocumentPhoto")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType(" varchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<bool>("ValidatedUser")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("FatecAppBackend.Domain.Entities.UserCollege", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CollegeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("GraduationDate")
                        .HasColumnType("DateTime");

                    b.Property<string>("ProofDocument")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("StudentNumber")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("ValidatedDocument")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CollegeId");

                    b.HasIndex("StudentNumber")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserColleges", (string)null);
                });

            modelBuilder.Entity("FatecAppBackend.Domain.Entities.Event", b =>
                {
                    b.HasOne("FatecAppBackend.Domain.Entities.UserCollege", "EventOwner")
                        .WithMany("Events")
                        .HasForeignKey("EventOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventOwner");
                });

            modelBuilder.Entity("FatecAppBackend.Domain.Entities.Participant", b =>
                {
                    b.HasOne("FatecAppBackend.Domain.Entities.Event", "Event")
                        .WithMany("Participants")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FatecAppBackend.Domain.Entities.UserCollege", "UserCollege")
                        .WithMany("Participants")
                        .HasForeignKey("UserCollegeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("UserCollege");
                });

            modelBuilder.Entity("FatecAppBackend.Domain.Entities.UserCollege", b =>
                {
                    b.HasOne("FatecAppBackend.Domain.Entities.College", "College")
                        .WithMany("UserCollege")
                        .HasForeignKey("CollegeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FatecAppBackend.Domain.Entities.User", "User")
                        .WithOne("UserCollege")
                        .HasForeignKey("FatecAppBackend.Domain.Entities.UserCollege", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("College");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FatecAppBackend.Domain.Entities.College", b =>
                {
                    b.Navigation("UserCollege");
                });

            modelBuilder.Entity("FatecAppBackend.Domain.Entities.Event", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("FatecAppBackend.Domain.Entities.User", b =>
                {
                    b.Navigation("UserCollege")
                        .IsRequired();
                });

            modelBuilder.Entity("FatecAppBackend.Domain.Entities.UserCollege", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
