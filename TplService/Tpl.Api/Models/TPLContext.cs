using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tpl.Api.Models.Db_Models;

namespace Tpl.Api.Models
{
    public class TPLContext : DbContext
    {
        public TPLContext()
        {
        }

        public TPLContext(DbContextOptions<TPLContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CarFeatureConfiguration());
            //modelBuilder.ApplyConfiguration(new CarManufacturerConfiguration());
            //modelBuilder.ApplyConfiguration(new CarModelConfiguration());
            //modelBuilder.ApplyConfiguration(new PersonalInformationConfiguration());
            //modelBuilder.ApplyConfiguration(new TplConditionConfiguration());
        }



       
         public virtual DbSet<CarManufacturer> CarManufacturers { get; set; }
         public virtual DbSet<CarModel> CarModels { get; set; }
         public virtual DbSet<CarFeature> CarFeatures { get; set; }
         public virtual DbSet<PersonalInformation> PersonalInformations { get; set; }
         public virtual DbSet<TplImit> TplConditions { get; set; }

    }
}
