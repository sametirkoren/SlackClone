﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210601122432_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Domain.Channel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Channels");

                    b.HasData(
                        new
                        {
                            Id = new Guid("774c6a20-02cc-41ee-b45b-17d74c992faa"),
                            Description = ".Net Core Kanalı",
                            Name = "DotNetCore"
                        },
                        new
                        {
                            Id = new Guid("b37f0c8d-3f30-42e6-9888-f59e2e4f9b5e"),
                            Description = "Angular Kanalı",
                            Name = "Angular"
                        },
                        new
                        {
                            Id = new Guid("2983edbc-86f9-4683-9114-1e5d7091d874"),
                            Description = "React Kanalı",
                            Name = "React"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}