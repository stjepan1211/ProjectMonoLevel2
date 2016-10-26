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
using System.Data.Entity.Migrations;

namespace Project.Service.DAL
{
    public class VehicleService : IVehicleService
    {
        private readonly VehicleContext db;
        private static VehicleService Instance;
        private VehicleService()
        {
             db = VehicleContext.GetInstance();
        }
        public static VehicleService GetInstance()
        {
            if (Instance == null)
                Instance = new VehicleService();
            return Instance;
        }

        public void CreateVehicleMake(VehicleMakeViewModel vehicleMakeView)
        {
            db.VehicleMakes.Add(Mapper.Map<VehicleMake>(vehicleMakeView));
            db.SaveChanges();
        }
        public void UpdateVehicleMake(VehicleMakeViewModel vehicleMakeView)
        {
            //db.Entry(Mapper.Map<VehicleMake>(vehicleMakeView)).State = EntityState.Modified;
            //exception: Attaching an entity of type 'Model' failed because another entity of the same 
            //type already has the same primary key value
            db.Set<VehicleMake>().AddOrUpdate(Mapper.Map<VehicleMake>(vehicleMakeView));
            db.SaveChanges();
        }
        public VehicleMakeViewModel FindVehicleMakeById(Guid id)
        {
            VehicleMake vehicleMake = db.VehicleMakes.Find(id);
            return Mapper.Map<VehicleMakeViewModel>(vehicleMake);
        }
        public void DeleteVehicleMake(Guid id)
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
            //db.Entry(Mapper.Map<VehicleModel>(vehicleModelView)).State = EntityState.Modified;
            db.Set<VehicleModel>().AddOrUpdate(Mapper.Map<VehicleModel>(vehicleModelView));
            db.SaveChanges();
        }
        public VehicleModelViewModel FindVehicleModelById(Guid id)
        {
            VehicleModel vehicleModel = db.VehicleModels.Find(id);
            return Mapper.Map<VehicleModelViewModel>(vehicleModel);
        }
        public void DeleteVehicleModel(Guid id)
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
                            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.Where(vmk => vmk.Name.Contains(searchString))
                            .OrderByDescending(vmk => vmk.Name)).ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.Where(vmk => vmk.Name.Contains(searchString))
                            .OrderByDescending(vmk => vmk.Abrv)).ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.Where(vmk => vmk.Name.Contains(searchString))
                            .OrderBy(vmk => vmk.Abrv)).ToPagedList(page ?? 1, pageSize);
                        default:
                            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.Where(vmk => vmk.Name.Contains(searchString))
                            .OrderBy(vmk => vmk.Name)).ToPagedList(page ?? 1, pageSize);

                    }
                case "Abrv":
                    switch (sortBy)
                    {
                        case "Name desc":
                            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.Where(vmk => vmk.Abrv.Contains(searchString))
                            .OrderByDescending(vmk => vmk.Name)).ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.Where(vmk => vmk.Abrv.Contains(searchString))
                            .OrderByDescending(vmk => vmk.Abrv)).ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.Where(vmk => vmk.Abrv.Contains(searchString))
                            .OrderBy(vmk => vmk.Abrv)).ToPagedList(page ?? 1, pageSize);
                        default:
                            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.Where(vmk => vmk.Abrv.Contains(searchString))
                            .OrderBy(vmk => vmk.Name)).ToPagedList(page ?? 1, pageSize);
                    }
                default:
                    //dohvacanje entity-a ako korisnik nije upisao nista u textbox
                    switch (sortBy)
                    {
                        case "Name desc":
                            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.OrderByDescending(vmk => vmk.Name))
                                .ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.OrderByDescending(vmk => vmk.Abrv))
                                .ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.OrderBy(vmk => vmk.Abrv))
                                .ToPagedList(page ?? 1, pageSize);
                        default:
                            return Mapper.Map<IEnumerable<VehicleMakeViewModel>>(db.VehicleMakes.OrderBy(vmk => vmk.Name))
                                .ToPagedList(page ?? 1, pageSize);
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
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(vml => vml.VehicleMake.Name.Contains(searchString))
                                .OrderByDescending(vml => vml.VehicleMake.Name)).ToPagedList(page ?? 1, pageSize);
                        case "Model desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(vml => vml.Name.Contains(searchString))
                                .OrderByDescending(vml => vml.Name)).ToPagedList(page ?? 1, pageSize);
                        case "Model":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(vml => vml.VehicleMake.Name.Contains(searchString))
                                .OrderBy(vml => vml.Name)).ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(vml => vml.VehicleMake.Name.Contains(searchString))
                                .OrderByDescending(vml => vml.Abrv)).ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(vml => vml.VehicleMake.Name.Contains(searchString))
                                .OrderBy(vml => vml.Abrv)).ToPagedList(page ?? 1, pageSize);
                        default:
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(vml => vml.VehicleMake.Name.Contains(searchString))
                                .OrderBy(vml => vml.VehicleMake.Name)).ToPagedList(page ?? 1, pageSize);
                    }
                case "Name":
                    switch(sortBy)
                    {
                        case "Maker desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(vml => vml.Name.Contains(searchString))
                                .OrderByDescending(vml => vml.VehicleMake.Name)).ToPagedList(page ?? 1, pageSize);
                        case "Model desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(vml => vml.Name.Contains(searchString))
                                .OrderByDescending(vml => vml.Name)).ToPagedList(page ?? 1, pageSize);
                        case "Model":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(vml => vml.Name.Contains(searchString))
                                .OrderBy(vml => vml.Name)).ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(vml => vml.Name.Contains(searchString))
                                .OrderByDescending(vml => vml.Abrv)).ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(vml => vml.Name.Contains(searchString))
                                .OrderBy(vml => vml.Abrv)).ToPagedList(page ?? 1, pageSize);
                        default:
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(vml => vml.Name.Contains(searchString))
                                .OrderBy(vml => vml.VehicleMake.Name)).ToPagedList(page ?? 1, pageSize);
                    }
                case "Abrv":
                    switch (sortBy)
                    {
                        case "Maker desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(vml => vml.Abrv.Contains(searchString))
                                .OrderByDescending(vml => vml.VehicleMake.Name)).ToPagedList(page ?? 1, pageSize);
                        case "Model desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(vml => vml.Abrv.Contains(searchString))
                                .OrderByDescending(vml => vml.Name)).ToPagedList(page ?? 1, pageSize);
                        case "Model":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>> (db.VehicleModels.Where(vml => vml.Abrv.Contains(searchString))
                                .OrderBy(vml => vml.Name)).ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(vml => vml.Abrv.Contains(searchString))
                                .OrderByDescending(vml => vml.Abrv)).ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(vml => vml.Abrv.Contains(searchString))
                                .OrderBy(vml => vml.Abrv)).ToPagedList(page ?? 1, pageSize);
                        default:
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels.Where(vml => vml.Abrv.Contains(searchString))
                                .OrderBy(vml => vml.VehicleMake.Name)).ToPagedList(page ?? 1, pageSize);
                    }
                default:
                    //dohvacanje entity-a ako korisnik nije upisao nista u textbox
                    switch (sortBy)
                    {
                        case "Maker desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels
                                .OrderByDescending(vml => vml.VehicleMake.Name)).ToPagedList(page ?? 1, pageSize);
                        case "Model desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels
                                .OrderByDescending(vml => vml.Name)).ToPagedList(page ?? 1, pageSize);
                        case "Model":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels
                                .OrderBy(vml => vml.Name)).ToPagedList(page ?? 1, pageSize);
                        case "Abrv desc":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels
                                .OrderByDescending(vml => vml.Abrv)).ToPagedList(page ?? 1, pageSize);
                        case "Abrv":
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels
                                .OrderBy(vml => vml.Abrv)).ToPagedList(page ?? 1, pageSize);
                        default:
                            return Mapper.Map<IEnumerable<VehicleModelViewModel>>(db.VehicleModels
                                .OrderBy(vml => vml.VehicleMake.Name)).ToPagedList(page ?? 1, pageSize);
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
