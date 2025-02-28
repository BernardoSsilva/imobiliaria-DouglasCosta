﻿// <auto-generated />
using System;
using ImmobileApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ImmobileApp.Infrastructure.Migrations
{
    [DbContext(typeof(ImmobileAppDbContext))]
    partial class ImmobileAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ImmobileApp.Domain.Entities.ImageEnitty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte>("Image")
                        .HasColumnType("smallint");

                    b.Property<Guid>("ImmobileId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Size")
                        .HasColumnType("real");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ImmobileId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ImmobileApp.Domain.Entities.ImmobileEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("HasScripture")
                        .HasColumnType("boolean");

                    b.Property<string>("ImmobileDescription")
                        .HasColumnType("text");

                    b.Property<string>("ImmobileType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LocalLink")
                        .HasColumnType("text");

                    b.Property<string>("LocalityInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserCreationId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserCreationId");

                    b.ToTable("Immobiles");
                });

            modelBuilder.Entity("ImmobileApp.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BornDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CivilState")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ImmobileApp.Domain.Entities.ImageEnitty", b =>
                {
                    b.HasOne("ImmobileApp.Domain.Entities.ImmobileEntity", "Immobile")
                        .WithMany("Images")
                        .HasForeignKey("ImmobileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Immobile");
                });

            modelBuilder.Entity("ImmobileApp.Domain.Entities.ImmobileEntity", b =>
                {
                    b.HasOne("ImmobileApp.Domain.Entities.UserEntity", "User")
                        .WithMany("Immobiles")
                        .HasForeignKey("UserCreationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ImmobileApp.Domain.Entities.ImmobileEntity", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("ImmobileApp.Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("Immobiles");
                });
#pragma warning restore 612, 618
        }
    }
}
