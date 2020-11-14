using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tpl.Api.Models.Db_Models
{
    public class CarManufacturerCarModel
    {
        public int CarManufacturersId { get; set; }
        public int CarModelsId { get; set; }

        public virtual CarManufacturer CarManufacturers { get; set; }
        public virtual CarModel CarModels { get; set; }
    }
}
