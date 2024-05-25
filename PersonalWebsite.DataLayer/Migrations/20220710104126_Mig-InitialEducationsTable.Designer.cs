﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalWebsite.DataLayer.Context;

namespace PersonalWebsite.DataLayer.Migrations
{
    [DbContext(typeof(PersonalWebsiteContext))]
    [Migration("20220710104126_Mig-InitialEducationsTable")]
    partial class MigInitialEducationsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersonalWebsite.DataLayer.Entities.User.AboutUser", b =>
                {
                    b.Property<int>("AU_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("BirthDate")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ImageProfile")
                        .HasMaxLength(200);

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.HasKey("AU_ID");

                    b.ToTable("AboutUsers");
                });

            modelBuilder.Entity("PersonalWebsite.DataLayer.Entities.User.Education", b =>
                {
                    b.Property<int>("EducationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FromDate")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("TillDate")
                        .HasMaxLength(100);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("University")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("EducationID");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("PersonalWebsite.DataLayer.Entities.User.Skill", b =>
                {
                    b.Property<int>("SkillID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("Percent");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("SkillID");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("PersonalWebsite.DataLayer.Entities.User.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserImage")
                        .HasMaxLength(200);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PersonalWebsite.DataLayer.Entities.Weblog.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlogImageName")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("LDescription")
                        .IsRequired();

                    b.Property<string>("SDescription")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });
#pragma warning restore 612, 618
        }
    }
}
