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
using Project.Service.ViewModels;
using AutoMapper.QueryableExtensions;

namespace Project.Service.DAL
{
    public class VehicleService : IVehicleService
    {
        private readonly VehicleContext db;

        public VehicleService()
        {
             db = new VehicleContext();
        }

        public void CreateVehicleMake(VehicleMakeViewModel vehicleMakeView)
        {
            db.VehicleMakes.Add(Mapper.Map<VehicleMake>(vehicleMakeView));
            db.SaveChanges();
        }
        public void UpdateVehicleMake(VehicleMakeViewModel vehicleMakeView)
        {
            db.Entry(Mapper.Map<VehicleMake>(vehicleMakeView)).State = EntityState.Modified;
            db.SaveChanges();
        }
        public VehicleMakeViewModel FindVehicleMakeById(int id)
        {
            var vehicleMake = (from vmk in db.VehicleMakes where vmk.VehicleMakeId == id select vmk).ProjectTo<VehicleMakeViewModel>().FirstOrDefault();
            return vehicleMake;
        }
        public void DeleteVehicleMake(int id)
        {
            VehicleMake vehicleMake = db.VehicleMakes.Find(id);
            db.VehicleMakes.Remove(vehicleMake);
            db.SaveChanges();
        }
        public void CreateVehicleModel(VehicleModelViewModel vehicleModelView)
        {
            db.VehicleModels.Add(Mapper.Map<VehicleModel>(vehicleModelView));
            db.SaveChanges();
        }
        public void UpdateVehicleModel(VehicleModelViewModel vehicleModelView)
        {
            db.Entry(Mapper.Map<VehicleModel>(vehicleModelView)).State = EntityState.Modified;
            db.SaveChanges();
        }
        public VehicleModelViewModel FindVehicleModelById(int id)
        {
            var vehicleModel = (from vmd in db.VehicleModels where vmd.VehicleModelId == id select vmd).ProjectTo<VehicleModelViewModel>().FirstOrDefault();
            return vehicleModel;
        }
        public void DeleteVehicleModel(int id)
        {
            VehicleModel vehicleModel = db.VehicleModels.Find(id);
            db.VehicleModels.Remove(vehicleModel);
            db.SaveChanges();
        }
        public IPagedList<VehicleMakeViewModel> GetSearchSortVehicleMake(string searchBy, string searchString, int? page, int pageSize, string sortBy)
        {
            switch (searchBy)
            {
                case "Name":
                    switch (sortBy)
                    {
                        case "Name desc":
                            return db.VehicleMakes.Where(vmk => vmk.Name.Contains(searchString))
                            .OrderByDescending(vmk => vmk.Name).ProjectTo<VehicleMakeViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return db.VehicleMakes.Where(vmk => vmk.Name.Contains(searchString))
                            .OrderByDescending(vmk => vmk.Abrv).ProjectTo<VehicleMakeViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return db.VehicleMakes.Where(vmk => vmk.Name.Contains(searchString))
                            .OrderBy(vmk => vmk.Abrv).ProjectTo<VehicleMakeViewModel>().ToPagedList(page ?? 1, pageSize);
                        default:
                            return db.VehicleMakes.Where(vmk => vmk.Name.Contains(searchString))
                            .OrderBy(vmk => vmk.Name).ProjectTo<VehicleMakeViewModel>().ToPagedList(page ?? 1, pageSize);
                    }
                case "Abrv":
                    switch (sortBy)
                    {
                        case "Name desc":
                            return db.VehicleMakes.Where(vmk => vmk.Abrv.Contains(searchString))
                            .OrderByDescending(vmk => vmk.Name).ProjectTo<VehicleMakeViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return db.VehicleMakes.Where(vmk => vmk.Abrv.Contains(searchString))
                            .OrderByDescending(vmk => vmk.Abrv).ProjectTo<VehicleMakeViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return db.VehicleMakes.Where(vmk => vmk.Abrv.Contains(searchString))
                            .OrderBy(vmk => vmk.Abrv).ProjectTo<VehicleMakeViewModel>().ToPagedList(page ?? 1, pageSize);
                        default:
                            return db.VehicleMakes.Where(vmk => vmk.Abrv.Contains(searchString))
                            .OrderBy(vmk => vmk.Name).ProjectTo<VehicleMakeViewModel>().ToPagedList(page ?? 1, pageSize);
                    }
                default:
                    //dohvacanje entity-a ako korisnik nije upisao nista u textbox
                    switch (sortBy)
                    {
                        case "Name desc":
                            return db.VehicleMakes
                            .OrderByDescending(vmk => vmk.Name).ProjectTo<VehicleMakeViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return db.VehicleMakes
                            .OrderByDescending(vmk => vmk.Abrv).ProjectTo<VehicleMakeViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return db.VehicleMakes
                            .OrderBy(vmk => vmk.Abrv).ProjectTo<VehicleMakeViewModel>().ToPagedList(page ?? 1, pageSize);
                        default:
                            return db.VehicleMakes
                            .OrderBy(vmk => vmk.Name).ProjectTo<VehicleMakeViewModel>().ToPagedList(page ?? 1, pageSize);
                    }
            }

        }
        public IPagedList<VehicleModelViewModel> GetSearchSortVehicleModel(string searchBy, string searchString, int? page, int pageSize, string sortBy)
        {
            switch (searchBy)
            {
                case "Maker":
                    switch (sortBy)
                    {
                        case "Maker desc":
                            return db.VehicleModels.Where(vml => vml.VehicleMake.Name.Contains(searchString))
                                .OrderByDescending(vml => vml.VehicleMake.Name).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Model desc":
                            return db.VehicleModels.Where(vml => vml.VehicleMake.Name.Contains(searchString))
                                .OrderByDescending(vml => vml.Name).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Model":
                            return db.VehicleModels.Where(vml => vml.VehicleMake.Name.Contains(searchString))
                                .OrderBy(vml => vml.Name).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return db.VehicleModels.Where(vml => vml.VehicleMake.Name.Contains(searchString))
                                .OrderByDescending(vml => vml.Abrv).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return db.VehicleModels.Where(vml => vml.VehicleMake.Name.Contains(searchString))
                                .OrderBy(vml => vml.Abrv).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                        default:
                            return db.VehicleModels.Where(vml => vml.VehicleMake.Name.Contains(searchString))
                                .OrderBy(vml => vml.VehicleMake.Name).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                    }
                case "Name":
                    switch(sortBy)
                    {
                        case "Maker desc":
                            return db.VehicleModels.Where(vml => vml.Name.Contains(searchString))
                                .OrderByDescending(vml => vml.VehicleMake.Name).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Model desc":
                            return db.VehicleModels.Where(vml => vml.Name.Contains(searchString))
                                .OrderByDescending(vml => vml.Name).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Model":
                            return db.VehicleModels.Where(vml => vml.Name.Contains(searchString))
                                .OrderBy(vml => vml.Name).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return db.VehicleModels.Where(vml => vml.Name.Contains(searchString))
                                .OrderByDescending(vml => vml.Abrv).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return db.VehicleModels.Where(vml => vml.Name.Contains(searchString))
                                .OrderBy(vml => vml.Abrv).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                        default:
                            return db.VehicleModels.Where(vml => vml.Name.Contains(searchString))
                                .OrderBy(vml => vml.VehicleMake.Name).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                    }
                case "Abrv":
                    switch (sortBy)
                    {
                        case "Maker desc":
                            return db.VehicleModels.Where(vml => vml.Abrv.Contains(searchString))
                                .OrderByDescending(vml => vml.VehicleMake.Name).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Model desc":
                            return db.VehicleModels.Where(vml => vml.Abrv.Contains(searchString))
                                .OrderByDescending(vml => vml.Name).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Model":
                            return db.VehicleModels.Where(vml => vml.Abrv.Contains(searchString))
                                .OrderBy(vml => vml.Name).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return db.VehicleModels.Where(vml => vml.Abrv.Contains(searchString))
                                .OrderByDescending(vml => vml.Abrv).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return db.VehicleModels.Where(vml => vml.Abrv.Contains(searchString))
                                .OrderBy(vml => vml.Abrv).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                        default:
                            return db.VehicleModels.Where(vml => vml.Abrv.Contains(searchString))
                                .OrderBy(vml => vml.VehicleMake.Name).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                    }
                default:
                    //dohvacanje entity-a ako korisnik nije upisao nista u textbox
                    switch (sortBy)
                    {
                        case "Maker desc":
                            return db.VehicleModels
                                .OrderByDescending(vml => vml.VehicleMake.Name).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Model desc":
                            return db.VehicleModels
                                .OrderByDescending(vml => vml.Name).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Model":
                            return db.VehicleModels
                                .OrderBy(vml => vml.Name).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return db.VehicleModels
                                .OrderByDescending(vml => vml.Abrv).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return db.VehicleModels
                                .OrderBy(vml => vml.Abrv).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
                        default:
                            return db.VehicleModels
                                .OrderBy(vml => vml.VehicleMake.Name).ProjectTo<VehicleModelViewModel>().ToPagedList(page ?? 1, pageSize);
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
