﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ItemTransactionsAPI.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Balance> Balance { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemTransactions> ItemTransactions { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<Warhouse> Warhouse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Balance>(entity =>
            {
                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Balance)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Balance_Balance");

                entity.HasOne(d => d.WarHouse)
                    .WithMany(p => p.Balance)
                    .HasForeignKey(d => d.WarHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Balance_Warhouse1");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_Category");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_Category1");
            });

            modelBuilder.Entity<ItemTransactions>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TransType).HasMaxLength(50);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemTransactions)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemTransactions_Item");

                entity.HasOne(d => d.WarHouse)
                    .WithMany(p => p.ItemTransactions)
                    .HasForeignKey(d => d.WarHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemTransactions_Warhouse1");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.UnitName).HasMaxLength(50);
            });

            modelBuilder.Entity<Warhouse>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.WarHouseName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}