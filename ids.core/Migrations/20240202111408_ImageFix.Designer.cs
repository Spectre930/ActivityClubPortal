﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ids.core.Models;

#nullable disable

namespace ids.core.Migrations
{
    [DbContext(typeof(ActivityClubPortalContext))]
    [Migration("20240202111408_ImageFix")]
    partial class ImageFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ids.core.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cost")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateOnly>("DateFrom")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateTo")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LookupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Events__3214EC07F802EFC2");

                    b.HasIndex("LookupId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ids.core.Models.EventGuide", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("GuideId")
                        .HasColumnType("int");

                    b.HasKey("EventId", "GuideId")
                        .HasName("PK__EventsGu__8A1E2D5275C69368");

                    b.HasIndex("GuideId");

                    b.ToTable("EventGuide");
                });

            modelBuilder.Entity("ids.core.Models.EventsMember", b =>
                {
                    b.Property<int>("EventsId")
                        .HasColumnType("int");

                    b.Property<int>("MembersId")
                        .HasColumnType("int");

                    b.HasKey("EventsId", "MembersId")
                        .HasName("PK__EventsMe__A95F8D5D0993C128");

                    b.HasIndex("MembersId");

                    b.ToTable("EventsMembers");
                });

            modelBuilder.Entity("ids.core.Models.Guide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("JoiningDate")
                        .HasColumnType("date");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Guides__3214EC07376882AC");

                    b.ToTable("Guides");
                });

            modelBuilder.Entity("ids.core.Models.Lookup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Orders")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Lookups__3214EC070D66A87F");

                    b.ToTable("Lookups");
                });

            modelBuilder.Entity("ids.core.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateOfBirth")
                        .HasMaxLength(50)
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmergencyNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateOnly>("JoiningDate")
                        .HasMaxLength(50)
                        .HasColumnType("date");

                    b.Property<string>("MobileNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("ids.core.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Roles__3214EC07395D21A9");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ids.core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ids.core.Models.UsersRole", b =>
                {
                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.HasKey("UsersId", "RolesId")
                        .HasName("PK__UsersRol__49E4C579D70DD5CF");

                    b.HasIndex("RolesId");

                    b.ToTable("UsersRoles");
                });

            modelBuilder.Entity("ids.core.Models.Event", b =>
                {
                    b.HasOne("ids.core.Models.Lookup", "Lookup")
                        .WithMany("Events")
                        .HasForeignKey("LookupId")
                        .IsRequired()
                        .HasConstraintName("FK__Events__LookupId__5629CD9C");

                    b.Navigation("Lookup");
                });

            modelBuilder.Entity("ids.core.Models.EventGuide", b =>
                {
                    b.HasOne("ids.core.Models.Event", "Events")
                        .WithMany("EventGuide")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__EventsGui__Event__60A75C0F");

                    b.HasOne("ids.core.Models.Guide", "Guides")
                        .WithMany("EventGuide")
                        .HasForeignKey("GuideId")
                        .IsRequired()
                        .HasConstraintName("FK__EventsGui__Guide__619B8048");

                    b.Navigation("Events");

                    b.Navigation("Guides");
                });

            modelBuilder.Entity("ids.core.Models.EventsMember", b =>
                {
                    b.HasOne("ids.core.Models.Event", "Events")
                        .WithMany("EventsMembers")
                        .HasForeignKey("EventsId")
                        .IsRequired()
                        .HasConstraintName("FK__EventsMem__Event__5CD6CB2B");

                    b.HasOne("ids.core.Models.Member", "Members")
                        .WithMany("EventsMembers")
                        .HasForeignKey("MembersId")
                        .IsRequired()
                        .HasConstraintName("FK_EventsMembers_Members");

                    b.Navigation("Events");

                    b.Navigation("Members");
                });

            modelBuilder.Entity("ids.core.Models.UsersRole", b =>
                {
                    b.HasOne("ids.core.Models.Role", "Roles")
                        .WithMany("UsersRoles")
                        .HasForeignKey("RolesId")
                        .IsRequired()
                        .HasConstraintName("FK__UsersRole__Roles__5165187F");

                    b.HasOne("ids.core.Models.User", "Users")
                        .WithMany("UsersRoles")
                        .HasForeignKey("UsersId")
                        .IsRequired()
                        .HasConstraintName("FK_UsersRoles_Users");

                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ids.core.Models.Event", b =>
                {
                    b.Navigation("EventGuide");

                    b.Navigation("EventsMembers");
                });

            modelBuilder.Entity("ids.core.Models.Guide", b =>
                {
                    b.Navigation("EventGuide");
                });

            modelBuilder.Entity("ids.core.Models.Lookup", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("ids.core.Models.Member", b =>
                {
                    b.Navigation("EventsMembers");
                });

            modelBuilder.Entity("ids.core.Models.Role", b =>
                {
                    b.Navigation("UsersRoles");
                });

            modelBuilder.Entity("ids.core.Models.User", b =>
                {
                    b.Navigation("UsersRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
