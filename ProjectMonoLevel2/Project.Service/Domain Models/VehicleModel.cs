using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Domain_Models
{
    class VehicleModel
    {
        public string Name { get; set; }
        public string Abrv { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
    }
}
