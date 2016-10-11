using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Models;

namespace Project.Service.Interfaces
{
    public interface IVehicle
    {
        void CreateVehicleMake(VehicleMake vehicleMake);
        void UpdateVehicleMake(VehicleMake vehicleMake);
        VehicleMake FindVehicleMakeById(int id);
        void DeleteVehicleMake(int id);
        void CreateVehicleModel(VehicleModel vehicleModel);
        VehicleModel FindVehicleModelById(int id);
        void UpdateVehicleModel(VehicleModel vehicleModel);
        void DeleteVehicleModel(int id);
    }
}
