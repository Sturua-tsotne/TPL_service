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
            CarModels = new HashSet<CarModel>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; }

        public virtual ICollection<CarModel> CarModels { get; set; }
    }
}
