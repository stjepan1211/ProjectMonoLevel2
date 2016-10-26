using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service.ViewModels
{
    public class VehicleMakeViewModel
    {
        public Guid VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
