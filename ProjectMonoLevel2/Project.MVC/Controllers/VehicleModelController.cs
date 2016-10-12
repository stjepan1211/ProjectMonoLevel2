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


namespace Project.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        VehicleService db = new VehicleService();
        VehicleModelBusinessLayer vmdbl = new VehicleModelBusinessLayer();
        VehicleMakeBusinessLayer vmkbl = new VehicleMakeBusinessLayer();
        private const int PageSize = 4;
        // GET: VehicleModel
        public ActionResult Index(string searchBy, string searchString, int? page, string sortBy)
        {
            ViewBag.SortMaker = string.IsNullOrEmpty(sortBy) ? "Maker desc" : "";
            ViewBag.SortModel = sortBy == "Model" ? "Model desc" : "Model";
            ViewBag.SortAbrv = sortBy == "Abrv" ? "Abrv desc" : "Abrv";
            
            if (searchBy == null)
            {
                return View(vmdbl.GetVehicleModelsPagedSorted(page, PageSize, sortBy));
            }
            else
            {  
                return View(db.GetSearchSortVehicleModel(searchBy, searchString, page, PageSize, sortBy));
            }
        }

        // GET: VehicleModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = db.FindVehicleModelById(Convert.ToInt32(id));
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // GET: VehicleModel/Create
        public ActionResult Create()
        {         
            ViewBag.VehicleMakeId = new SelectList(vmkbl.GetVehicleMakes(), "VehicleMakeId", "Name");
            return View();
        }

        // POST: VehicleModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleModelId,VehicleMakeId,Name,Abrv")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                db.CreateVehicleModel(vehicleModel);
                return RedirectToAction("Index");
            }

            ViewBag.VehicleMakeId = new SelectList(vmkbl.GetVehicleMakes(), "VehicleMakeId", "Name", vehicleModel.VehicleMakeId);
            return View(vehicleModel);
        }

        // GET: VehicleModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = db.FindVehicleModelById(Convert.ToInt32(id));
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleMakeId = new SelectList(vmkbl.GetVehicleMakes(), "VehicleMakeId", "Name", vehicleModel.VehicleMakeId);
            return View(vehicleModel);
        }

        // POST: VehicleModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleModelId,VehicleMakeId,Name,Abrv")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                db.UpdateVehicleModel(vehicleModel);
                return RedirectToAction("Index");
            }
            ViewBag.VehicleMakeId = new SelectList(vmkbl.GetVehicleMakes(), "VehicleMakeId", "Name", vehicleModel.VehicleMakeId);
            return View(vehicleModel);
        }

        // GET: VehicleModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = db.FindVehicleModelById(Convert.ToInt32(id));
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // POST: VehicleModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.DeleteVehicleModel(id);
            return RedirectToAction("Index");
        }

    }
}
