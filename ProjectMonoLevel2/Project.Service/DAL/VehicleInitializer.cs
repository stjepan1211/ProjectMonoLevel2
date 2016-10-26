using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Project.Service.Models;

namespace Project.Service.DAL
{
    class VehicleInitializer : DropCreateDatabaseIfModelChanges<VehicleContext>
    {
        protected override void Seed(VehicleContext context)
        {
            var vehicleMakes = new List<VehicleMake>()
            {
                new VehicleMake{VehicleMakeId = Guid.NewGuid(), Name="Volkswagen", Abrv="VW"},
                new VehicleMake{VehicleMakeId = Guid.NewGuid(), Name="Bayerische Motoren Werke", Abrv="BMW"},
                new VehicleMake{VehicleMakeId = Guid.NewGuid(), Name="Chevrolet",Abrv="Unknown"},
                new VehicleMake{VehicleMakeId = Guid.NewGuid(), Name="Rimac",Abrv="Unknown"},
                new VehicleMake{VehicleMakeId = Guid.NewGuid(), Name="Audi", Abrv="Unknown"},
                new VehicleMake{VehicleMakeId = Guid.NewGuid(), Name="Nissan", Abrv="Unknown"}
            };
            vehicleMakes.ForEach(vmk => context.VehicleMakes.Add(vmk));
            context.SaveChanges();

            //var vehicleModels = new List<VehicleModel>
            //{
            //    new VehicleModel{VehicleMakeId=1,Name="Passat CC", Abrv="Unknown"},
            //    new VehicleModel{VehicleMakeId=1,Name="Golf V", Abrv="Unknown"},
            //    new VehicleModel{VehicleMakeId=2,Name="X6", Abrv="Unknown"},
            //    new VehicleModel{VehicleMakeId=3,Name="Camaro", Abrv="Unknown"},
            //    new VehicleModel{VehicleMakeId=4,Name="Concept One", Abrv="Unknown"},
            //    new VehicleModel{VehicleMakeId=5,Name="A4", Abrv="Unknown"},
            //    new VehicleModel{VehicleMakeId=5,Name="Q7", Abrv="Unknown"}
            //};
            //vehicleModels.ForEach(vmd => context.VehicleModels.Add(vmd));
            //context.SaveChanges();
            base.Seed(context);
        }
    }
}
