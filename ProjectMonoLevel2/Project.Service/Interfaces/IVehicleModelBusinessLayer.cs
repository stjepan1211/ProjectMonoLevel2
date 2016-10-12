using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Project.Service.Models;

namespace Project.Service.Interfaces
{
    public interface IVehicleModelBusinessLayer
    {
        IPagedList<VehicleModel> GetVehicleModelsPagedSorted(int? page, int pageSize, string sortBy);
    }
}
