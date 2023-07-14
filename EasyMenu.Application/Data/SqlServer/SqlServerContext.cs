using System;
using System.Collections.Generic;
using EasyMenu.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyMenu.Application.Data.SqlServer;

public partial class SqlServerContext : DbContext
{
    public SqlServerContext(DbContextOptions<SqlServerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DisheType> DisheType { get; set; }

    public virtual DbSet<Dishes> Dishes { get; set; }

    public virtual DbSet<Menu> Menu { get; set; }

    public virtual DbSet<MenuOption> MenuOption { get; set; }

    public virtual DbSet<Restaurant> Restaurant { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DisheType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__disheTyp__3213E83F5A8706B9");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Dishes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__dishes__3213E83FC9B4C8B4");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Portion).HasDefaultValueSql("((1))");
            entity.Property(e => e.PromotionPrice).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.DisheType).WithMany(p => p.Dishes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_disheTypeId");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__menu__3213E83F4FF48E17");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<MenuOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__menuOpti__3213E83F71D20290");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Dishe).WithMany(p => p.MenuOption)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_disheId");

            entity.HasOne(d => d.Menu).WithMany(p => p.MenuOption)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_menuId");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__restaura__3213E83FB8BEB33B");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Menu).WithMany(p => p.Restaurant)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_menuId_restaurant");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}