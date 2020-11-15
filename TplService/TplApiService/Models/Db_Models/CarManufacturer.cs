using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tpl.Api.Models.Db_Models
{
    public partial class CarManufacturer
    {
        public CarManufacturer()
        {
            CarManufacturerCarModels = new HashSet<CarManufacturerCarModel>();
        }

        public int Id { get; set; }
        public string Manufacturer { get; set; }

        public virtual ICollection<CarManufacturerCarModel> CarManufacturerCarModels { get; set; }
    }
}
