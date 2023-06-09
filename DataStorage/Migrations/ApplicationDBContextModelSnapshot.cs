﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pre_Assignment;

#nullable disable

namespace DataStorage.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pre_Assignment.Entity.Comments", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("ErrorReportID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ErrorReportID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Pre_Assignment.Entity.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Pre_Assignment.Entity.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Pre_Assignment.Entity.ErrorReport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StatusID")
                        .HasColumnType("int");

                    b.Property<int>("customerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StatusID");

                    b.HasIndex("customerID");

                    b.ToTable("ErrorReports");
                });

            modelBuilder.Entity("Pre_Assignment.Entity.Status", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Pre_Assignment.Entity.Comments", b =>
                {
                    b.HasOne("Pre_Assignment.Entity.Employee", "Employee")
                        .WithMany("Comments")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pre_Assignment.Entity.ErrorReport", "ErrorReport")
                        .WithMany("Comments")
                        .HasForeignKey("ErrorReportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("ErrorReport");
                });

            modelBuilder.Entity("Pre_Assignment.Entity.ErrorReport", b =>
                {
                    b.HasOne("Pre_Assignment.Entity.Status", "status")
                        .WithMany("ErrorReports")
                        .HasForeignKey("StatusID");

                    b.HasOne("Pre_Assignment.Entity.Customer", "Customer")
                        .WithMany("ErrorReports")
                        .HasForeignKey("customerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("status");
                });

            modelBuilder.Entity("Pre_Assignment.Entity.Customer", b =>
                {
                    b.Navigation("ErrorReports");
                });

            modelBuilder.Entity("Pre_Assignment.Entity.Employee", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Pre_Assignment.Entity.ErrorReport", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Pre_Assignment.Entity.Status", b =>
                {
                    b.Navigation("ErrorReports");
                });
#pragma warning restore 612, 618
        }
    }
}
