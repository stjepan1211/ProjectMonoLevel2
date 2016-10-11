using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Models;
namespace Project.Service.DAL
{
    public class VehicleMakeBusinessLayer
    {
        VehicleContext db = new VehicleContext();
        public List<VehicleMake> GetVehicleMakes()
        {
            return db.VehicleMakes.ToList();
        }
    }
}
