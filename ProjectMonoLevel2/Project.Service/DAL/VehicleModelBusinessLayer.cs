using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Models;
using Project.Service.Interfaces;
using PagedList;

namespace Project.Service.DAL
{
    public class VehicleModelBusinessLayer : IVehicleModelBusinessLayer
    {
        VehicleContext db = new VehicleContext();
        //funkcija se koristi kod prvog user requesta VehicleModel/Index
        //lista se popunjava sa svim redovima iz tablice
        public IPagedList<VehicleModel> GetVehicleModelsPagedSorted(int? page, int pageSize, string sortBy)
        {
            switch (sortBy)
            {
                case "Maker desc":
                    return db.VehicleModels.OrderByDescending(vml => vml.VehicleMake.Name).ToList()
                        .ToPagedList(page ?? 1, pageSize);
                case "Model desc":
                    return db.VehicleModels.OrderByDescending(vml => vml.Name).ToList()
                        .ToPagedList(page ?? 1, pageSize);
                case "Model":
                    return db.VehicleModels.OrderBy(vml => vml.Name).ToList()
                        .ToPagedList(page ?? 1, pageSize);
                case "Abrv desc":
                    return db.VehicleModels.OrderByDescending(vml => vml.Abrv).ToList()
                        .ToPagedList(page ?? 1, pageSize);
                case "Abrv":
                    return db.VehicleModels.OrderBy(vml => vml.Abrv).ToList()
                        .ToPagedList(page ?? 1, pageSize);
                default:
                    return db.VehicleModels.OrderBy(vml => vml.VehicleMake.Name).ToList()
                        .ToPagedList(page ?? 1, pageSize);
            }
        }
        public List<VehicleModel> GetVehicleModels()
        {
            return db.VehicleModels.ToList();
        }
    }
}
