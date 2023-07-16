using System;
using System.Collections.Generic;
using EasyMenu.Application.Data.MySql.Entities;
using EasyMenu.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyMenu.Application.Data.SqlServer;
public partial class SqlServerContext : DbContext
{
    public SqlServerContext(DbContextOptions<SqlServerContext> options)
       : base(options)
    {
    }

    public virtual DbSet<DisheTypeEntity> DisheType { get; set; }

    public virtual DbSet<DishesEntity> Dishes { get; set; }

    public virtual DbSet<MenuEntity> Menu { get; set; }

    public virtual DbSet<MenuOptionEntity> MenuOption { get; set; }

    public virtual DbSet<RestaurantEntity> Restaurant { get; set; }

    public virtual DbSet<UserEntity> User { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>(entity => {
            entity.HasKey(e => e.Id).HasName("PK__user__3213E83F5E5009F4");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DisheTypeEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__disheTyp__3213E83F5A8706B9");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DishesEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__dishes__3213E83FC9B4C8B4");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Portion).HasDefaultValueSql("((1))");
            entity.Property(e => e.PromotionPrice).HasDefaultValueSql("((0))");
            });

        modelBuilder.Entity<MenuEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__menu__3213E83F4FF48E17");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<MenuOptionEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__menuOpti__3213E83F71D20290");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<RestaurantEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__restaura__3213E83FB8BEB33B");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}