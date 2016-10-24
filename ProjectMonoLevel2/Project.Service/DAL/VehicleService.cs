using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Project.Service.Models;
using Project.Service.Interfaces;
using PagedList.Mvc;
using PagedList;
using AutoMapper;

namespace Project.Service.DAL
{
    public class VehicleService : IVehicleService
    {
        private readonly VehicleContext db;

        public VehicleService()
        {
             db = new VehicleContext();
        }

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
        public IPagedList<VehicleMake> GetSearchSortVehicleMake(string searchBy, string searchString, int? page, int pageSize, string sortBy)
        {
            switch (searchBy)
            {
                case "Name":
                    switch (sortBy)
                    {
                        case "Name desc":
                            return db.VehicleMakes.Where(vmk => vmk.Name.Contains(searchString))
                            .OrderByDescending(vmk => vmk.Name).ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return db.VehicleMakes.Where(vmk => vmk.Name.Contains(searchString))
                            .OrderByDescending(vmk => vmk.Abrv).ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return db.VehicleMakes.Where(vmk => vmk.Name.Contains(searchString))
                            .OrderBy(vmk => vmk.Abrv).ToPagedList(page ?? 1, pageSize);
                        default:
                            return db.VehicleMakes.Where(vmk => vmk.Name.Contains(searchString))
                            .OrderBy(vmk => vmk.Name).ToPagedList(page ?? 1, pageSize);
                    }
                case "Abrv":
                    switch (sortBy)
                    {
                        case "Name desc":
                            return db.VehicleMakes.Where(vmk => vmk.Abrv.Contains(searchString))
                            .OrderByDescending(vmk => vmk.Name).ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return db.VehicleMakes.Where(vmk => vmk.Abrv.Contains(searchString))
                            .OrderByDescending(vmk => vmk.Abrv).ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return db.VehicleMakes.Where(vmk => vmk.Abrv.Contains(searchString))
                            .OrderBy(vmk => vmk.Abrv).ToPagedList(page ?? 1, pageSize);
                        default:
                            return db.VehicleMakes.Where(vmk => vmk.Abrv.Contains(searchString))
                            .OrderBy(vmk => vmk.Name).ToPagedList(page ?? 1, pageSize);
                    }
                default:
                    //dohvacanje entity-a ako korisnik nije upisao nista u textbox
                    switch (sortBy)
                    {
                        case "Name desc":
                            return db.VehicleMakes
                            .OrderByDescending(vmk => vmk.Name).ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return db.VehicleMakes
                            .OrderByDescending(vmk => vmk.Abrv).ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return db.VehicleMakes
                            .OrderBy(vmk => vmk.Abrv).ToPagedList(page ?? 1, pageSize);
                        default:
                            return db.VehicleMakes
                            .OrderBy(vmk => vmk.Name).ToPagedList(page ?? 1, pageSize);
                    }
            }
            
        }
        public IPagedList<VehicleModel> GetSearchSortVehicleModel(string searchBy, string searchString, int? page, int pageSize, string sortBy)
        {
            switch (searchBy)
            {
                case "Maker":
                    switch (sortBy)
                    {
                        case "Maker desc":
                            return db.VehicleModels.Where(vml => vml.VehicleMake.Name.Contains(searchString))
                                .OrderByDescending(vml => vml.VehicleMake.Name).ToPagedList(page ?? 1, pageSize);
                        case "Model desc":
                            return db.VehicleModels.Where(vml => vml.VehicleMake.Name.Contains(searchString))
                                .OrderByDescending(vml => vml.Name).ToPagedList(page ?? 1, pageSize);
                        case "Model":
                            return db.VehicleModels.Where(vml => vml.VehicleMake.Name.Contains(searchString))
                                .OrderBy(vml => vml.Name).ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return db.VehicleModels.Where(vml => vml.VehicleMake.Name.Contains(searchString))
                                .OrderByDescending(vml => vml.Abrv).ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return db.VehicleModels.Where(vml => vml.VehicleMake.Name.Contains(searchString))
                                .OrderBy(vml => vml.Abrv).ToPagedList(page ?? 1, pageSize);
                        default:
                            return db.VehicleModels.Where(vml => vml.VehicleMake.Name.Contains(searchString))
                                .OrderBy(vml => vml.VehicleMake.Name).ToPagedList(page ?? 1, pageSize);
                    }
                case "Name":
                    switch(sortBy)
                    {
                        case "Maker desc":
                            return db.VehicleModels.Where(vml => vml.Name.Contains(searchString))
                                .OrderByDescending(vml => vml.VehicleMake.Name).ToPagedList(page ?? 1, pageSize);
                        case "Model desc":
                            return db.VehicleModels.Where(vml => vml.Name.Contains(searchString))
                                .OrderByDescending(vml => vml.Name).ToPagedList(page ?? 1, pageSize);
                        case "Model":
                            return db.VehicleModels.Where(vml => vml.Name.Contains(searchString))
                                .OrderBy(vml => vml.Name).ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return db.VehicleModels.Where(vml => vml.Name.Contains(searchString))
                                .OrderByDescending(vml => vml.Abrv).ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return db.VehicleModels.Where(vml => vml.Name.Contains(searchString))
                                .OrderBy(vml => vml.Abrv).ToPagedList(page ?? 1, pageSize);
                        default:
                            return db.VehicleModels.Where(vml => vml.Name.Contains(searchString))
                                .OrderBy(vml => vml.VehicleMake.Name).ToPagedList(page ?? 1, pageSize);
                    }
                case "Abrv":
                    switch (sortBy)
                    {
                        case "Maker desc":
                            return db.VehicleModels.Where(vml => vml.Abrv.Contains(searchString))
                                .OrderByDescending(vml => vml.VehicleMake.Name).ToPagedList(page ?? 1, pageSize);
                        case "Model desc":
                            return db.VehicleModels.Where(vml => vml.Abrv.Contains(searchString))
                                .OrderByDescending(vml => vml.Name).ToPagedList(page ?? 1, pageSize);
                        case "Model":
                            return db.VehicleModels.Where(vml => vml.Abrv.Contains(searchString))
                                .OrderBy(vml => vml.Name).ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return db.VehicleModels.Where(vml => vml.Abrv.Contains(searchString))
                                .OrderByDescending(vml => vml.Abrv).ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return db.VehicleModels.Where(vml => vml.Abrv.Contains(searchString))
                                .OrderBy(vml => vml.Abrv).ToPagedList(page ?? 1, pageSize);
                        default:
                            return db.VehicleModels.Where(vml => vml.Abrv.Contains(searchString))
                                .OrderBy(vml => vml.VehicleMake.Name).ToPagedList(page ?? 1, pageSize);
                    }
                default:
                    //dohvacanje entity-a ako korisnik nije upisao nista u textbox
                    switch (sortBy)
                    {
                        case "Maker desc":
                            return db.VehicleModels
                                .OrderByDescending(vml => vml.VehicleMake.Name).ToPagedList(page ?? 1, pageSize);
                        case "Model desc":
                            return db.VehicleModels
                                .OrderByDescending(vml => vml.Name).ToPagedList(page ?? 1, pageSize);
                        case "Model":
                            return db.VehicleModels
                                .OrderBy(vml => vml.Name).ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return db.VehicleModels
                                .OrderByDescending(vml => vml.Abrv).ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return db.VehicleModels
                                .OrderBy(vml => vml.Abrv).ToPagedList(page ?? 1, pageSize);
                        default:
                            return db.VehicleModels
                                .OrderBy(vml => vml.VehicleMake.Name).ToPagedList(page ?? 1, pageSize);
                    }
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
