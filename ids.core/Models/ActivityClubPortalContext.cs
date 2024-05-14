using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ids.core.Models;

public partial class ActivityClubPortalContext : DbContext
{
    public ActivityClubPortalContext()
    {
    }

    public ActivityClubPortalContext(DbContextOptions<ActivityClubPortalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventGuide> EventGuide { get; set; }

    public virtual DbSet<EventsMember> EventsMembers { get; set; }

    public virtual DbSet<Guide> Guides { get; set; }

    public virtual DbSet<Lookup> Lookups { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersRole> UsersRoles { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ActivityClubPortal;Trusted_Connection=True;Encrypt=False");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer("Server=SPECTRE;Database=ActivityClubPortal;Trusted_Connection=True;trustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Events__3214EC07F802EFC2");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Cost)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(int.MaxValue)
                .IsUnicode(false);
            entity.Property(e => e.Destination)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
               .HasMaxLength(int.MaxValue)
               .IsUnicode(false);

            entity.HasOne(d => d.Lookup).WithMany(p => p.Events)
                .HasForeignKey(d => d.LookupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Events__LookupId__5629CD9C");
        });

        modelBuilder.Entity<EventGuide>(entity =>
        {
            entity.HasKey(e => new { e.EventId, e.GuideId }).HasName("PK__EventsGu__8A1E2D5275C69368");

            entity.HasOne(d => d.Events).WithMany(p => p.EventGuide)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventsGui__Event__60A75C0F");

            entity.HasOne(d => d.Guides).WithMany(p => p.EventGuide)
                .HasForeignKey(d => d.GuideId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventsGui__Guide__619B8048");
        });

        modelBuilder.Entity<EventsMember>(entity =>
        {
            entity.HasKey(e => new { e.EventsId, e.MembersId }).HasName("PK__EventsMe__A95F8D5D0993C128");

            entity.HasOne(d => d.Events).WithMany(p => p.EventsMembers)
                .HasForeignKey(d => d.EventsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventsMem__Event__5CD6CB2B");

            entity.HasOne(d => d.Members).WithMany(p => p.EventsMembers)
                .HasForeignKey(d => d.MembersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventsMembers_Members");
        });

        modelBuilder.Entity<Guide>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Guides__3214EC07376882AC");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Profession)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
               .HasMaxLength(int.MaxValue)
               .IsUnicode(false);
        });

        modelBuilder.Entity<Lookup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lookups__3214EC070D66A87F");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Orders)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
               .HasMaxLength(int.MaxValue)
               .IsUnicode(false);
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.DateOfBirth).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.EmergencyNumber).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.JoiningDate).HasMaxLength(50);
            entity.Property(e => e.MobileNumber).HasMaxLength(50);
            entity.Property(e => e.Nationality).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Profession).HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07395D21A9");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<UsersRole>(entity =>
        {
            entity.HasKey(e => new { e.UsersId, e.RolesId }).HasName("PK__UsersRol__49E4C579D70DD5CF");

            entity.HasOne(d => d.Roles).WithMany(p => p.UsersRoles)
                .HasForeignKey(d => d.RolesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsersRole__Roles__5165187F");

            entity.HasOne(d => d.Users).WithMany(p => p.UsersRoles)
                .HasForeignKey(d => d.UsersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsersRoles_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
