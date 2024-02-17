﻿// <auto-generated />
using Attendance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Attendance.Migrations
{
    [DbContext(typeof(AttendanceDbContext))]
    [Migration("20240214151837_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Attendance.Models.TbAttendance", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<float>("AttendancePercentage")
                        .HasColumnType("real");

                    b.HasKey("StudentId");

                    b.ToTable("tb_Attendance");
                });
#pragma warning restore 612, 618
        }
    }
}
