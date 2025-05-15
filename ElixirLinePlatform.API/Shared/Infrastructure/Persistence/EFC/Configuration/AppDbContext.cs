using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using ElixirLinePlatform.API.SupplyInventory.Domain.Model.Entities;



namespace ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
   protected override void OnConfiguring(DbContextOptionsBuilder builder)
   {
      //Para campos de auditor (CreatedDate, UpdatedDate)
      builder.AddCreatedUpdatedInterceptor();
      base.OnConfiguring(builder);
   }
   
   // Definir DbSets para las entidades
   public DbSet<Supply> Supplies { get; set; } = null!;
   public DbSet<SupplyUsage> SupplyUsages { get; set; } = null!;
   
   protected override void OnModelCreating(ModelBuilder builder)
   {
      base.OnModelCreating(builder);
      
      
      //=================================================================================================
      //||                                    CONFIGURATION OF THE TABLES                              ||                              
      //=================================================================================================
      
      //=================================================================================================
      //===================================== 1. GONZALO BOUNDED CONTEXT ================================
      
      //=================================================================================================
      //===================================== 2. FERNANDO - SUPPLY INVENTORY BOUNDED CONTEXT =======================
      
      // Configuración de la entidad Supply
      builder.Entity<Supply>().ToTable("Supplies");
      builder.Entity<Supply>().HasKey(s => s.Id);
      builder.Entity<Supply>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<Supply>().Property(s => s.Name).IsRequired().HasMaxLength(100);
      builder.Entity<Supply>().Property(s => s.Category).IsRequired().HasMaxLength(50);
      builder.Entity<Supply>().Property(s => s.Quantity).IsRequired().HasPrecision(18, 2);
      builder.Entity<Supply>().Property(s => s.Unit).IsRequired().HasMaxLength(20);
      
      // Configuración de la entidad SupplyUsage
      builder.Entity<SupplyUsage>().ToTable("SupplyUsages");
      builder.Entity<SupplyUsage>().HasKey(su => su.Id);
      builder.Entity<SupplyUsage>().Property(su => su.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<SupplyUsage>().Property(su => su.QuantityUsed).IsRequired().HasPrecision(18, 2);
      builder.Entity<SupplyUsage>().Property(su => su.Notes).HasMaxLength(500);
      
      // Relación entre Supply y SupplyUsage
      builder.Entity<SupplyUsage>()
         .HasOne(su => su.Supply)
         .WithMany(s => s.SupplyUsages)
         .HasForeignKey(su => su.SupplyId)
         .OnDelete(DeleteBehavior.Restrict);
      
      //=================================================================================================

      
      //Regals de mapped object relational (ORM)
      builder.UseSnakeCaseNamingConvention();
   }
}