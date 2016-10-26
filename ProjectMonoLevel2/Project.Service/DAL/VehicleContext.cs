using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Project.Service.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Project.Service.DAL
{
    public class VehicleContext : DbContext
    {
        private static VehicleContext Instance;
        private VehicleContext() : base("VehicleContext")
        {
        }
        public static VehicleContext GetInstance()
        {
            if (Instance == null)
                Instance = new VehicleContext();
            return Instance;
        }
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
