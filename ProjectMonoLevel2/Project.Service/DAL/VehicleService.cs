using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Project.Service.Models;
using Project.Service.Interfaces;

namespace Project.Service.DAL
{
    public class VehicleService : IVehicle
    {
        VehicleContext db = new VehicleContext();

        public void CreateVehicleMake(VehicleMake vehicleMake)
        {
            db.VehicleMakes.Add(vehicleMake);
            db.SaveChanges();
        }
        public void UpdateVehicleMake(VehicleMake vehicleMake)
        {
            db.Entry(vehicleMake).State = EntityState.Modified;
            db.SaveChanges();
        }
        public VehicleMake FindVehicleMakeById(int id)
        {
            var vehicleMake = (from vmk in db.VehicleMakes where vmk.VehicleMakeId == id select vmk).FirstOrDefault();
            return vehicleMake;
        }
        public void DeleteVehicleMake(int id)
        {
            VehicleMake vehicleMake = db.VehicleMakes.Find(id);
            db.VehicleMakes.Remove(vehicleMake);
            db.SaveChanges();
        }
        public void CreateVehicleModel(VehicleModel vehicleModel)
        {
            db.VehicleModels.Add(vehicleModel);
            db.SaveChanges();
        }
        public void UpdateVehicleModel(VehicleModel vehicleModel)
        {
            db.Entry(vehicleModel).State = EntityState.Modified;
            db.SaveChanges();
        }
        public VehicleModel FindVehicleModelById(int id)
        {
            var vehicleModel = (from vmd in db.VehicleModels where vmd.VehicleModelId == id select vmd).FirstOrDefault();
            return vehicleModel;
        }
        public void DeleteVehicleModel(int id)
        {
            VehicleModel vehicleModel = db.VehicleModels.Find(id);
            db.VehicleModels.Remove(vehicleModel);
            db.SaveChanges();
        }
    }
}
