using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tpl.Api.Models.Db_Models
{
    public class CarManufacturer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Manufacturer { get; set; }
    }
}
