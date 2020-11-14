using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tpl.Api.Models.Db_Models
{
    public class CarFeature
    {
        public CarFeature()
        {
            CarModels= new HashSet<CarModel>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string RegistrationNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseTime { get; set; }
        [Required]
        public int CarModelId { get; set; }

        public virtual ICollection<CarModel> CarModels { get; set; }

    }
}
