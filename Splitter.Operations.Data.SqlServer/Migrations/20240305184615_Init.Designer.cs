﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Splitter.Operations.Data.SqlServer;

#nullable disable

namespace Splitter.Operations.Data.SqlServer.Migrations
{
    [DbContext(typeof(SplitterDbContext))]
    [Migration("20240305184615_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Commensality")
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Splitter.Operations.Models.Commensality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FinishedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Commensalitys", "Commensality");
                });

            modelBuilder.Entity("Splitter.Operations.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ClosedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CommensalityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PaidAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("TotalPaid")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("CommensalityId")
                        .IsUnique();

                    b.ToTable("Orders", "Commensality");
                });

            modelBuilder.Entity("Splitter.Operations.Models.OrderProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<Guid?>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("TagId");

                    b.ToTable("OrderProducts", "Commensality");
                });

            modelBuilder.Entity("Splitter.Operations.Models.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags", "Commensality");
                });

            modelBuilder.Entity("Splitter.Operations.Models.Voucher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Vouchers", "Commensality");
                });

            modelBuilder.Entity("Splitter.Operations.Models.Order", b =>
                {
                    b.HasOne("Splitter.Operations.Models.Commensality", "Commensality")
                        .WithOne("Order")
                        .HasForeignKey("Splitter.Operations.Models.Order", "CommensalityId");

                    b.Navigation("Commensality");
                });

            modelBuilder.Entity("Splitter.Operations.Models.OrderProduct", b =>
                {
                    b.HasOne("Splitter.Operations.Models.Order", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Splitter.Operations.Models.Tag", null)
                        .WithMany("Products")
                        .HasForeignKey("TagId");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Splitter.Operations.Models.Voucher", b =>
                {
                    b.HasOne("Splitter.Operations.Models.Order", "Order")
                        .WithMany("Vouchers")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Splitter.Operations.Models.Commensality", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("Splitter.Operations.Models.Order", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Vouchers");
                });

            modelBuilder.Entity("Splitter.Operations.Models.Tag", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
