using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.ViewModels
{
    public class VehicleModelViewModel
    {
        public int VehicleModelId { get; set; }
        public int VehicleMakeId { get; set; }
        public string VehicleMakeName { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
