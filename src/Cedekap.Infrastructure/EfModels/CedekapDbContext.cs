﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Cedekap.Core.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Cedekap.Infrastructure.EfModels
{
    public partial class CedekapDbContext : IdentityDbContext<CedekapWebUser>
    {
        public CedekapDbContext(DbContextOptions<CedekapDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Store> Store { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

                entity.Property(e => e.CodeSupplier)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Demand).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Exit).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Month).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pay)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Rebate).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("IX_Article_ArticleId");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store", "Stores");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}