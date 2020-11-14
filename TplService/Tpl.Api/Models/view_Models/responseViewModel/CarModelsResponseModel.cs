using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tpl.Api.Models.view_Models.responseViewModel
{
    public class CarModelsResponseModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Model { get; set; }
        [Required]
        public int CarManufacturerId { get; set; }
    }
}
