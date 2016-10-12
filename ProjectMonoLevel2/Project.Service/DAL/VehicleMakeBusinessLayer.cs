using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Models;
using PagedList.Mvc;
using PagedList;
using Project.Service.Interfaces;

namespace Project.Service.DAL
{
    public class VehicleMakeBusinessLayer : IVehicleMakeBusinessLayer
    {
        VehicleContext db = new VehicleContext();
        //funkcija se koristi kod prvog user requesta VehicleMake/Index
        //lista se popunjava sa svim redovima iz tablice
        public IPagedList<VehicleMake> GetVehicleMakesPagedSorted(int? page, int pageSize, string sortBy)
        {
            switch(sortBy)
            {
                case "Name desc":
                    return db.VehicleMakes.OrderByDescending(vmk => vmk.Name).ToList().ToPagedList(page ?? 1, pageSize);
                case "Abrv desc":
                    return db.VehicleMakes.OrderByDescending(vmk => vmk.Abrv).ToList().ToPagedList(page ?? 1, pageSize);
                case "Abrv":
                    return db.VehicleMakes.OrderBy(vmk => vmk.Abrv).ToList().ToPagedList(page ?? 1, pageSize);
                default:
                    return db.VehicleMakes.OrderBy(vmk => vmk.Name).ToList().ToPagedList(page ?? 1, pageSize);
            }
        }
        //funkcija se koristi kod CRUD-a za VehicleModel
        //kada korisnik bira proizvodaca po VehicleMakeId
        public List<VehicleMake> GetVehicleMakes()
        {
            return db.VehicleMakes.ToList();
        }
    }
}
