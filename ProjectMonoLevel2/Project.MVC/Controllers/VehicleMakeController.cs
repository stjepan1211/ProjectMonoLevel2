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
    public class VehicleMakeController : Controller
    {
        private const int PageSize = 4;
        private readonly VehicleService vehicleService = new VehicleService(); 

        // GET: VehicleMake
        public ActionResult Index(string searchBy, string searchString, int? page, string sortBy)
        {
            ViewBag.SortName = string.IsNullOrEmpty(sortBy) ? "Name desc" : "";
            ViewBag.SortAbrv = sortBy == "Abrv" ? "Abrv desc" : "Abrv";

            if (searchString == null)
            {
                return View(vehicleService.GetSearchSortVehicleMake("", "", page, PageSize, sortBy));
            }
            else
            {
                return View(vehicleService.GetSearchSortVehicleMake(searchBy, searchString, page, PageSize, sortBy));
            }   
        }

        // GET: VehicleMake/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMakeViewModel vehicleMake = vehicleService.FindVehicleMakeById(Convert.ToInt32(id));
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // GET: VehicleMake/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleMake/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleMakeId,Name,Abrv")] VehicleMakeViewModel vehicleMakeView)
        {
            if (ModelState.IsValid)
            {
                vehicleService.CreateVehicleMake(vehicleMakeView);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Krivo unesen maker");
            }
            return View(vehicleMakeView);
        }

        // GET: VehicleMake/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMakeViewModel vehicleMake = vehicleService.FindVehicleMakeById(Convert.ToInt32(id));
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMake/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleMakeId,Name,Abrv")] VehicleMakeViewModel vehicleMakeView)
        {
            if (ModelState.IsValid)
            {
                vehicleService.UpdateVehicleMake(vehicleMakeView);
                return RedirectToAction("Index");
            }
            return View(vehicleMakeView);
        }

        // GET: VehicleMake/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMakeViewModel vehicleMake = vehicleService.FindVehicleMakeById(Convert.ToInt32(id));
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vehicleService.DeleteVehicleMake(id);
            return RedirectToAction("Index");
        }
    }
}
