using FatecAppBackend.Domain.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Infra.Data.Contexts
{
    public class FatecAppBackendContext : DbContext
    {
        // Call on Startup
        public FatecAppBackendContext(DbContextOptions<FatecAppBackendContext> options) : base(options)
        {
            
        }

        // Tables

        public DbSet<User> Users { get; set; }

        public DbSet<College> Colleges { get; set; }

        public DbSet<UserCollege> UserColleges { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Participant> Participants { get; set; }

        // Relations

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            #region User mapping
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().Property(x => x.Id);
            modelBuilder.Entity<User>().HasOne(x => x.UserCollege).WithOne(x => x.User).HasForeignKey<UserCollege>(x => x.UserId);

            // Name
            modelBuilder.Entity<User>().Property(x => x.Name).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(x => x.Name).HasColumnType("varchar(100)");
            modelBuilder.Entity<User>().Property(x => x.Name).IsRequired();

            // Email
            modelBuilder.Entity<User>().Property(x => x.Email).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(x => x.Email).HasColumnType("varchar(100)");
            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();

            // Passowrd
            modelBuilder.Entity<User>().Property(x => x.Password).HasMaxLength(200);
            modelBuilder.Entity<User>().Property(x => x.Password).HasColumnType("varchar(200)");
            modelBuilder.Entity<User>().Property(x => x.Password).IsRequired();

            // Photo
            modelBuilder.Entity<User>().Property(x => x.Photo).HasMaxLength(1000);
            modelBuilder.Entity<User>().Property(x => x.Photo).HasColumnType("varchar(1000)");
            modelBuilder.Entity<User>().Property(x => x.Photo).IsRequired();

            // PhoneNumber
            modelBuilder.Entity<User>().Property(x => x.PhoneNumber).HasMaxLength(12);
            modelBuilder.Entity<User>().Property(x => x.PhoneNumber).HasColumnType("varchar(12)");
            modelBuilder.Entity<User>().Property(x => x.PhoneNumber).IsRequired();

            // IdentityDocumentNumber
            modelBuilder.Entity<User>().Property(x => x.IdentityDocumentNumber).HasMaxLength(11);
            modelBuilder.Entity<User>().Property(x => x.IdentityDocumentNumber).HasColumnType("varchar(11)");
            modelBuilder.Entity<User>().Property(x => x.IdentityDocumentNumber).IsRequired();

            // IdentityDocumentPhotoFront
            modelBuilder.Entity<User>().Property(x => x.IdentityDocumentPhotoFront).HasMaxLength(1000);
            modelBuilder.Entity<User>().Property(x => x.IdentityDocumentPhotoFront).HasColumnType(" varchar(1000)");
            modelBuilder.Entity<User>().Property(x => x.IdentityDocumentPhotoFront).IsRequired();

            // IdentityDocumentPhotoBack
            modelBuilder.Entity<User>().Property(x => x.IdentityDocumentPhotoBack).HasMaxLength(1000);
            modelBuilder.Entity<User>().Property(x => x.IdentityDocumentPhotoBack).HasColumnType(" varchar(1000)");
            modelBuilder.Entity<User>().Property(x => x.IdentityDocumentPhotoBack).IsRequired();

            // Gender
            modelBuilder.Entity<User>().Property(x => x.Gender).HasColumnType("varchar(100) CHECK(Gender IN ('Male', 'Female'))");
            modelBuilder.Entity<User>().Property(x => x.Gender).IsRequired();

            // ValidatedUser
            modelBuilder.Entity<User>().Property(x => x.ValidatedUser).HasColumnType("bit");
            modelBuilder.Entity<User>().Property(x => x.ValidatedUser).IsRequired();

            // CreatedAt
            modelBuilder.Entity<User>().Property(x => x.CreatedAt).HasColumnType("DateTime");
            modelBuilder.Entity<User>().Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

            #endregion

            #region UserCollege mapping
            modelBuilder.Entity<UserCollege>().ToTable("UserColleges");
            modelBuilder.Entity<UserCollege>().Property(x => x.Id);
            modelBuilder.Entity<UserCollege>().HasMany(x => x.Events).WithOne(x => x.EventOwner);    

            // UserId
            modelBuilder.Entity<UserCollege>().Property(x => x.UserId).HasColumnType("uniqueidentifier");
            modelBuilder.Entity<UserCollege>().Property(x => x.UserId).IsRequired();
            modelBuilder.Entity<UserCollege>().HasIndex(x => x.UserId).IsUnique();
            modelBuilder.Entity<UserCollege>().HasOne(x => x.User).WithOne(x => x.UserCollege);

            // CollegeId
            modelBuilder.Entity<UserCollege>().Property(x => x.CollegeId).HasColumnType("uniqueidentifier");
            modelBuilder.Entity<UserCollege>().Property(x => x.CollegeId).IsRequired();
            modelBuilder.Entity<UserCollege>().HasOne(x => x.College).WithMany(x => x.UserCollege);

            // StudentNumber
            modelBuilder.Entity<UserCollege>().Property(x => x.StudentNumber).HasColumnType("varchar(100)");
            modelBuilder.Entity<UserCollege>().Property(x => x.StudentNumber).IsRequired();
            modelBuilder.Entity<UserCollege>().HasIndex(x => x.StudentNumber).IsUnique();

            // ValidatedDocument
            modelBuilder.Entity<UserCollege>().Property(x => x.ValidatedDocument).HasColumnType("bit");
            modelBuilder.Entity<UserCollege>().Property(x => x.ValidatedDocument).IsRequired();

            // ProofDocument
            modelBuilder.Entity<UserCollege>().Property(x => x.ProofDocument).HasMaxLength(1000);
            modelBuilder.Entity<UserCollege>().Property(x => x.ProofDocument).HasColumnType("varchar(1000)");
            modelBuilder.Entity<UserCollege>().Property(x => x.ProofDocument).IsRequired();

            // GraduationDate
            modelBuilder.Entity<UserCollege>().Property(x => x.GraduationDate).HasColumnType("DateTime");
            modelBuilder.Entity<UserCollege>().Property(x => x.GraduationDate).IsRequired();

            #endregion

            #region Event mapping
            modelBuilder.Entity<Event>().ToTable("Events");
            modelBuilder.Entity<Event>().Property(x => x.Id);

            // EventOwnerId
            modelBuilder.Entity<Event>().Property(x => x.EventOwnerId).HasColumnType("uniqueidentifier");
            modelBuilder.Entity<Event>().Property(x => x.EventOwnerId).IsRequired();
            modelBuilder.Entity<Event>().HasOne(x => x.EventOwner).WithMany(x => x.Events);

            // From
            modelBuilder.Entity<Event>().Property(x => x.From).HasColumnType("varchar(100)");
            modelBuilder.Entity<Event>().Property(x => x.From).IsRequired();

            // To
            modelBuilder.Entity<Event>().Property(x => x.To).HasColumnType("varchar(100)");
            modelBuilder.Entity<Event>().Property(x => x.To).IsRequired();

            // Route
            modelBuilder.Entity<Event>().Property(x => x.Route).HasColumnType("varchar(500)");
            modelBuilder.Entity<Event>().Property(x => x.Route).IsRequired();

            // OnlyWomen
            modelBuilder.Entity<Event>().Property(x => x.OnlyWomen).HasColumnType("bit");
            modelBuilder.Entity<Event>().Property(x => x.OnlyWomen).IsRequired();

            // TimeToGo
            modelBuilder.Entity<Event>().Property(x => x.TimeToGo).HasColumnType("DateTime");
            modelBuilder.Entity<Event>().Property(x => x.TimeToGo).IsRequired();


            // Status
            modelBuilder.Entity<Event>().Property(x => x.Status).HasColumnType("varchar(100) CHECK(Status IN ('Preparation', 'Ready', 'Started', 'Finished'))");
            modelBuilder.Entity<Event>().Property(x => x.Status).IsRequired();
            #endregion

            #region College mapping
            modelBuilder.Entity<College>().ToTable("Colleges");
            modelBuilder.Entity<College>().Property(x => x.Id);
            modelBuilder.Entity<College>().HasMany(x => x.UserCollege).WithOne(x => x.College);

            // Name
            modelBuilder.Entity<College>().Property(x => x.Name).HasColumnType("varchar(100)");
            modelBuilder.Entity<College>().Property(x => x.Name).IsRequired();

            // Course
            modelBuilder.Entity<College>().Property(x => x.Course).HasColumnType("varchar(100)");
            modelBuilder.Entity<College>().Property(x => x.Course).IsRequired();

            // Time
            modelBuilder.Entity<College>().Property(x => x.Time).HasColumnType("varchar(100) CHECK(Time IN ('AM', 'PM'))");
            modelBuilder.Entity<College>().Property(x => x.Time).IsRequired();

            // Localization
            modelBuilder.Entity<College>().Property(x => x.Localization).HasColumnType("varchar(500)");
            modelBuilder.Entity<College>().Property(x => x.Localization).IsRequired();

            #endregion

            #region Participant mapping
            modelBuilder.Entity<Participant>().ToTable("Participants");
            modelBuilder.Entity<Participant>().Property(x => x.Id);
            modelBuilder.Entity<Participant>().HasOne(x => x.UserCollege).WithMany(x => x.Participants);
            modelBuilder.Entity<Participant>().HasOne(x => x.Event).WithMany(x => x.Participants);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
