using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tpl.Api.Models.Db_Models
{
    public partial class CarModel
    {
       
     
            public CarModel()
            {
                CarManufacturerCarModels = new HashSet<CarManufacturerCarModel>();
            }

            public int Id { get; set; }
            public string Model { get; set; }
            public int CarManufacturerId { get; set; }
            public int CarFeatureId { get; set; }

            public virtual CarFeature CarFeature { get; set; }
            public virtual ICollection<CarManufacturerCarModel> CarManufacturerCarModels { get; set; }
        }
}
