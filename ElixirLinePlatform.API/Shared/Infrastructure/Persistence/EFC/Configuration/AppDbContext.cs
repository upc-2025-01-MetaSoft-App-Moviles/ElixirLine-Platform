using ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;


namespace ElixirLinePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
   protected override void OnConfiguring(DbContextOptionsBuilder builder)
   {
      //Para campos de auditor (CreatedDate, UpdatedDate)
      builder.AddCreatedUpdatedInterceptor();
      base.OnConfiguring(builder);
   }
   
   protected override void OnModelCreating(ModelBuilder builder)
   {
      base.OnModelCreating(builder);
      
      
      //=================================================================================================
      //||                                    CONFIGURATION OF THE TABLES                              ||                              
      //=================================================================================================
      
      //=================================================================================================
      //===================================== 1. GONZALO BOUNDED CONTEXT ================================
      
   
      
      //Regals de mapped object relational (ORM)
      builder.UseSnakeCaseNamingConvention();
   }
}