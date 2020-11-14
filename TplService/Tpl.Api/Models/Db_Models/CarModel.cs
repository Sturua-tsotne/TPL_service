using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tpl.Api.Models.Db_Models
{
    public class CarModel
    {
        public CarModel()
        {
            CarManufacturers = new HashSet<CarManufacturer>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Model { get; set; }
        [Required]
        public int CarManufacturerId { get; set; }

        public virtual ICollection<CarManufacturer> CarManufacturers  { get; set; }
    }
}
