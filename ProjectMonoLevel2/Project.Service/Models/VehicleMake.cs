using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service.Models
{
    public class VehicleMake
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
