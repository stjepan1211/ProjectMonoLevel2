using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Service.DAL;
using Project.Service.Models;
using Project.Service.ViewModels;

namespace Project.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly VehicleService vehicleService;
        private const int PageSize = 4;

        public VehicleModelController()
        {
            vehicleService = VehicleService.GetInstance();
        }

        // GET: VehicleModel
        public ActionResult Index(string searchBy, string searchString, int? page, string sortBy)
        {
            ViewBag.SortMaker = string.IsNullOrEmpty(sortBy) ? "Maker desc" : "";
            ViewBag.SortModel = sortBy == "Model" ? "Model desc" : "Model";
            ViewBag.SortAbrv = sortBy == "Abrv" ? "Abrv desc" : "Abrv";
            
            if (searchString == null)
            {
                return View(vehicleService.GetSearchSortVehicleModel("","",page, PageSize, sortBy));
            }
            else
            {  
                return View(vehicleService.GetSearchSortVehicleModel(searchBy, searchString, page, PageSize, sortBy));
            }
        }

        // GET: VehicleModel/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModelViewModel vehicleModel = vehicleService.FindVehicleModelById((Guid)id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // GET: VehicleModel/Create
        public ActionResult Create()
        {         
            ViewBag.VehicleMakeId = new SelectList(vehicleService.GetVehicleMakes(), "VehicleMakeId", "Name");
            return View();
        }

        // POST: VehicleModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleModelId,VehicleMakeId,Name,Abrv")] VehicleModelViewModel vehicleModelView)
        {
            if (ModelState.IsValid)
            {
                vehicleService.CreateVehicleModel(vehicleModelView);
                return RedirectToAction("Index");
            }

            ViewBag.VehicleMakeId = new SelectList(vehicleService.GetVehicleMakes(), "VehicleMakeId", "Name", vehicleModelView.VehicleMakeId);
            return View(vehicleModelView);
        }

        // GET: VehicleModel/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModelViewModel vehicleModelView = vehicleService.FindVehicleModelById((Guid)id);
            if (vehicleModelView == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleMakeId = new SelectList(vehicleService.GetVehicleMakes(), "VehicleMakeId", "Name", vehicleModelView.VehicleMakeId);
            return View(vehicleModelView);
        }

        // POST: VehicleModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleModelId,VehicleMakeId,Name,Abrv")] VehicleModelViewModel vehicleModelView)
        {
            if (ModelState.IsValid)
            {
                vehicleService.UpdateVehicleModel(vehicleModelView);
                return RedirectToAction("Index");
            }
            ViewBag.VehicleMakeId = new SelectList(vehicleService.GetVehicleMakes(), "VehicleMakeId", "Name", vehicleModelView.VehicleMakeId);
            return View(vehicleModelView);
        }

        // GET: VehicleModel/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModelViewModel vehicleModelView = vehicleService.FindVehicleModelById((Guid)id);
            if (vehicleModelView == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModelView);
        }

        // POST: VehicleModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            vehicleService.DeleteVehicleModel((Guid)id);
            return RedirectToAction("Index");
        }

    }
}
