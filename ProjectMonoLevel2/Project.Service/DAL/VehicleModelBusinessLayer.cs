using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Models;

namespace Project.Service.DAL
{
    public class VehicleModelBusinessLayer
    {
        VehicleContext db = new VehicleContext();
        public List<VehicleModel> GetVehicleModels()
        {
            return db.VehicleModels.ToList();
        }
    }
}
