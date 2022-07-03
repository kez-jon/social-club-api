﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SocialClub.Api.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public virtual DbSet<ClubEvent> ClubEvent { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Member> Member { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClubEvent>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__ClubEven__7944C81021E2EFF8");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EventDescription)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EventStatus)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.HostName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Venue)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasIndex(e => e.Phone, "UQ__Contact__5C7E359E78A73DD7")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Contact__A9D10534FB4BC7D4")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasIndex(e => e.Phone, "UQ__Member__5C7E359E09C502A8")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Member__A9D1053482C2E59C")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
