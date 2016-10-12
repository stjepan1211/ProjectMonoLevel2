using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Models;
using PagedList;

namespace Project.Service.Interfaces
{
    public interface IVehicleMakeBusinessLayer
    {
        IPagedList<VehicleMake> GetVehicleMakesPagedSorted(int? page, int pageSize, string sortBy);
        List<VehicleMake> GetVehicleMakes();
    }
}
