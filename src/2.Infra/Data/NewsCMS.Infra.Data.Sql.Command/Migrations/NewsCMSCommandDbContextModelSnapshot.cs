﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewsCMS.Infra.Data.Sql.Command.Contexts;

#nullable disable

namespace NewsCMS.Infra.Data.Sql.Command.Migrations
{
    [DbContext(typeof(NewsCMSCommandDbContext))]
    partial class NewsCMSCommandDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NewsCMS.Core.Domain.Aggregates.References.NewsKeyword", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<Guid>("Code")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByUserId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("KeywordCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("NewsId")
                        .HasColumnType("bigint");

                    b.Property<string>("UpdatedByUserId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasAlternateKey("Code");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("NewsId");

                    b.ToTable("NewsKeywords", (string)null);
                });

            modelBuilder.Entity("NewsCMS.Core.Domain.Aggregates.Source.News", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Code")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByUserId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UpdatedByUserId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasAlternateKey("Code");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("News", (string)null);
                });

            modelBuilder.Entity("Sky.App.Core.Contract.Infra.Command.OutboxEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("AccuredOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("AggregateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AggregateName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("AggregateTypeName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("EventTypeName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsProccessd")
                        .HasColumnType("bit");

                    b.Property<string>("Payload")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpanId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TraceId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("OutboxEvents");
                });

            modelBuilder.Entity("NewsCMS.Core.Domain.Aggregates.References.NewsKeyword", b =>
                {
                    b.HasOne("NewsCMS.Core.Domain.Aggregates.Source.News", null)
                        .WithMany("Keywords")
                        .HasForeignKey("NewsId");
                });

            modelBuilder.Entity("NewsCMS.Core.Domain.Aggregates.Source.News", b =>
                {
                    b.Navigation("Keywords");
                });
#pragma warning restore 612, 618
        }
    }
}
