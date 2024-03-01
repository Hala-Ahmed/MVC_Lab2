﻿// <auto-generated />
using System;
using MVC_Lab2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_Lab2.Migrations
{
    [DbContext(typeof(BanhaDbContext))]
    [Migration("20240219201355_v111")]
    partial class v111
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVC_Lab2.Models.Department", b =>
                {
                    b.Property<int>("Dno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Dno"));

                    b.Property<string>("Dname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MGRSSN")
                        .HasColumnType("int");

                    b.Property<DateTime?>("MGRStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Dno");

                    b.HasIndex("MGRSSN");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("MVC_Lab2.Models.Dependent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Bdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DependentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ESSN")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("ID");

                    b.HasIndex("ESSN");

                    b.ToTable("Dependents");
                });

            modelBuilder.Entity("MVC_Lab2.Models.Employee", b =>
                {
                    b.Property<int>("SSN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SSN"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Bdate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Dno")
                        .HasColumnType("int");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("money");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int?>("Superssn")
                        .HasColumnType("int");

                    b.HasKey("SSN");

                    b.HasIndex("Dno");

                    b.HasIndex("Superssn");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("MVC_Lab2.Models.Project", b =>
                {
                    b.Property<int>("Pnumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pnumber"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Dno")
                        .HasColumnType("int");

                    b.Property<string>("Plocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pnumber");

                    b.HasIndex("Dno");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("MVC_Lab2.Models.WorksFor", b =>
                {
                    b.Property<int>("ESSN")
                        .HasColumnType("int");

                    b.Property<int>("Pno")
                        .HasColumnType("int");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.HasKey("ESSN", "Pno");

                    b.HasIndex("Pno");

                    b.ToTable("WorksFor");
                });

            modelBuilder.Entity("MVC_Lab2.Models.Department", b =>
                {
                    b.HasOne("MVC_Lab2.Models.Employee", "Manger")
                        .WithMany()
                        .HasForeignKey("MGRSSN");

                    b.Navigation("Manger");
                });

            modelBuilder.Entity("MVC_Lab2.Models.Dependent", b =>
                {
                    b.HasOne("MVC_Lab2.Models.Employee", "Employee")
                        .WithMany("Dependents")
                        .HasForeignKey("ESSN");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("MVC_Lab2.Models.Employee", b =>
                {
                    b.HasOne("MVC_Lab2.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("Dno");

                    b.HasOne("MVC_Lab2.Models.Employee", "Supervisor")
                        .WithMany()
                        .HasForeignKey("Superssn");

                    b.Navigation("Department");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("MVC_Lab2.Models.Project", b =>
                {
                    b.HasOne("MVC_Lab2.Models.Department", "Department")
                        .WithMany("Projects")
                        .HasForeignKey("Dno");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MVC_Lab2.Models.WorksFor", b =>
                {
                    b.HasOne("MVC_Lab2.Models.Employee", "Employee")
                        .WithMany("WorkAssignments")
                        .HasForeignKey("ESSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC_Lab2.Models.Project", "Project")
                        .WithMany("WorkAssignments")
                        .HasForeignKey("Pno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("MVC_Lab2.Models.Department", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("MVC_Lab2.Models.Employee", b =>
                {
                    b.Navigation("Dependents");

                    b.Navigation("WorkAssignments");
                });

            modelBuilder.Entity("MVC_Lab2.Models.Project", b =>
                {
                    b.Navigation("WorkAssignments");
                });
#pragma warning restore 612, 618
        }
    }
}
