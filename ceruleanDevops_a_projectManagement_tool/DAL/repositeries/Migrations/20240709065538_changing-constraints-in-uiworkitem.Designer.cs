﻿// <auto-generated />
using System;
using DAL.Dbcontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(WorkItemsDbContext))]
    [Migration("20240709065538_changing-constraints-in-uiworkitem")]
    partial class changingconstraintsinuiworkitem
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Entites.Areas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AreaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("DAL.Entites.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("WorkItemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkItemId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DAL.Entites.FileUploads", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("WorkItemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("WorkItemId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("DAL.Entites.Iterations", b =>
                {
                    b.Property<int>("IterationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IterationId"));

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("IterationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IterationId");

                    b.HasIndex("AreaId");

                    b.ToTable("Iterations");
                });

            modelBuilder.Entity("DAL.Entites.Priorities", b =>
                {
                    b.Property<int>("PriorityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PriorityId"));

                    b.Property<string>("PritoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PriorityId");

                    b.ToTable("Priorities");
                });

            modelBuilder.Entity("DAL.Entites.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("StatusId");

                    b.HasIndex("TypeId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("DAL.Entites.Types", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeId"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeId");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("DAL.Entites.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DAL.Entites.WorkItem", b =>
                {
                    b.Property<string>("WorkItemId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ActualEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ActualStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpectedEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpectedStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IterationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriorityId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("WorkItemId");

                    b.HasIndex("AreaId");

                    b.HasIndex("IterationId");

                    b.HasIndex("PriorityId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.ToTable("WorkItems");
                });

            modelBuilder.Entity("DAL.Entites.WorkitemLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LinkType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceWorkItemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TargetWorkItemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SourceWorkItemId");

                    b.HasIndex("TargetWorkItemId");

                    b.ToTable("WorkitemLinks");
                });

            modelBuilder.Entity("DAL.Entites.Comments", b =>
                {
                    b.HasOne("DAL.Entites.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DAL.Entites.WorkItem", "WorkItem")
                        .WithMany("Comments")
                        .HasForeignKey("WorkItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("WorkItem");
                });

            modelBuilder.Entity("DAL.Entites.FileUploads", b =>
                {
                    b.HasOne("DAL.Entites.WorkItem", "WorkItem")
                        .WithMany("FileUploads")
                        .HasForeignKey("WorkItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkItem");
                });

            modelBuilder.Entity("DAL.Entites.Iterations", b =>
                {
                    b.HasOne("DAL.Entites.Areas", "Area")
                        .WithMany("Iterations")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("DAL.Entites.Status", b =>
                {
                    b.HasOne("DAL.Entites.Types", "Type")
                        .WithMany("statuses")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("DAL.Entites.WorkItem", b =>
                {
                    b.HasOne("DAL.Entites.Areas", "Area")
                        .WithMany("WorkItems")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DAL.Entites.Iterations", "Iteration")
                        .WithMany("WorkItems")
                        .HasForeignKey("IterationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DAL.Entites.Priorities", "Priority")
                        .WithMany("WorkItems")
                        .HasForeignKey("PriorityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DAL.Entites.Status", "Status")
                        .WithMany("WorkItems")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DAL.Entites.Types", "Type")
                        .WithMany("WorkItems")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DAL.Entites.User", "User")
                        .WithMany("WorkItems")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("Iteration");

                    b.Navigation("Priority");

                    b.Navigation("Status");

                    b.Navigation("Type");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entites.WorkitemLink", b =>
                {
                    b.HasOne("DAL.Entites.WorkItem", "SourceWorkItem")
                        .WithMany("SourceLinks")
                        .HasForeignKey("SourceWorkItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DAL.Entites.WorkItem", "TargetWorkItem")
                        .WithMany("TargetLinks")
                        .HasForeignKey("TargetWorkItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("SourceWorkItem");

                    b.Navigation("TargetWorkItem");
                });

            modelBuilder.Entity("DAL.Entites.Areas", b =>
                {
                    b.Navigation("Iterations");

                    b.Navigation("WorkItems");
                });

            modelBuilder.Entity("DAL.Entites.Iterations", b =>
                {
                    b.Navigation("WorkItems");
                });

            modelBuilder.Entity("DAL.Entites.Priorities", b =>
                {
                    b.Navigation("WorkItems");
                });

            modelBuilder.Entity("DAL.Entites.Status", b =>
                {
                    b.Navigation("WorkItems");
                });

            modelBuilder.Entity("DAL.Entites.Types", b =>
                {
                    b.Navigation("WorkItems");

                    b.Navigation("statuses");
                });

            modelBuilder.Entity("DAL.Entites.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("WorkItems");
                });

            modelBuilder.Entity("DAL.Entites.WorkItem", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("FileUploads");

                    b.Navigation("SourceLinks");

                    b.Navigation("TargetLinks");
                });
#pragma warning restore 612, 618
        }
    }
}