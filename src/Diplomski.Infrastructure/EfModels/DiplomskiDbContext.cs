﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Diplomski.Core.Models.Entities;

#nullable disable

namespace Diplomski.Infrastructure.EfModels
{
    public partial class DiplomskiDbContext : DbContext
    {
        public DiplomskiDbContext()
        {
        }

        public DiplomskiDbContext(DbContextOptions<DiplomskiDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Store> Store { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("Article", "Stores");

                entity.HasIndex(e => e.StoreId, "IXFK_Article_StoreId");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BuyPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodeDob)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Demand).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Entry).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Exit).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Op).HasColumnName("OP");

                entity.Property(e => e.Owe).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Pla)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("PLA");

                entity.Property(e => e.Rebate).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SingularPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Tariff).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Tax).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Week).HasColumnType("date");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("IX_Article_ArticleId");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store", "Stores");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}