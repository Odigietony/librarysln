﻿// <auto-generated />
using System;
using LibrarySolution.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibrarySolution.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200603034937_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LibrarySolution.Api.Models.Book", b =>
                {
                    b.Property<string>("Isbn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(1) CHARACTER SET utf8mb4");

                    b.Property<string>("BookDescription")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("BookTitle")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateOfPublication")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Isbn");

                    b.ToTable("books");
                });
#pragma warning restore 612, 618
        }
    }
}
