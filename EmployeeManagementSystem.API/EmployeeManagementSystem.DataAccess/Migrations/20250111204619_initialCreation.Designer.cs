﻿// <auto-generated />
using System;
using EmployeeManagementSystem.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeManagementSystem.DataAccess.Migrations
{
    [DbContext(typeof(EmployeeManagementDbContext))]
    [Migration("20250111204619_initialCreation")]
    partial class initialCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeManagementSystem.DataAccess.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeManagementSystem.DataAccess.Entities.EmployeeRoles", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("EmployeeId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("EmployeeRoles");
                });

            modelBuilder.Entity("EmployeeManagementSystem.DataAccess.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EmployeeManagementSystem.DataAccess.Entities.Shift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("EndTime");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("StartTime");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RoleId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("EmployeeManagementSystem.DataAccess.Entities.EmployeeRoles", b =>
                {
                    b.HasOne("EmployeeManagementSystem.DataAccess.Entities.Employee", "Employee")
                        .WithMany("EmployeeRoles")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeManagementSystem.DataAccess.Entities.Role", "Role")
                        .WithMany("EmployeeRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EmployeeManagementSystem.DataAccess.Entities.Shift", b =>
                {
                    b.HasOne("EmployeeManagementSystem.DataAccess.Entities.Employee", "Employee")
                        .WithMany("Shifts")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeManagementSystem.DataAccess.Entities.Role", "Role")
                        .WithMany("Shifts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EmployeeManagementSystem.DataAccess.Entities.Employee", b =>
                {
                    b.Navigation("EmployeeRoles");

                    b.Navigation("Shifts");
                });

            modelBuilder.Entity("EmployeeManagementSystem.DataAccess.Entities.Role", b =>
                {
                    b.Navigation("EmployeeRoles");

                    b.Navigation("Shifts");
                });
#pragma warning restore 612, 618
        }
    }
}
