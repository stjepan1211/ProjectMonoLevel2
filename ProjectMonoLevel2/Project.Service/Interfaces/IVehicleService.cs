using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Models;
using PagedList;
using Project.Service.ViewModels;

namespace Project.Service.Interfaces
{
    public interface IVehicleService
    {
        void CreateVehicleMake(VehicleMakeViewModel vehicleMakeView);
        void UpdateVehicleMake(VehicleMakeViewModel vehicleMakeView);
        VehicleMakeViewModel FindVehicleMakeById(Guid id);
        void DeleteVehicleMake(Guid id);
        void CreateVehicleModel(VehicleModelViewModel vehicleModel);
        VehicleModelViewModel FindVehicleModelById(Guid id);
        void UpdateVehicleModel(VehicleModelViewModel vehicleModel);
        void DeleteVehicleModel(Guid id);
        IPagedList<VehicleMakeViewModel> GetSearchSortVehicleMake(string searchBy,string searchString, int? page, int pageSize, string sortBy);
        IPagedList<VehicleModelViewModel> GetSearchSortVehicleModel(string searchBy, string searchString, int? page, int pageSize, string sortBy);
        List<VehicleMake> GetVehicleMakes();
    }
}
