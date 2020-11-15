using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tpl.Api.Models.view_Models
{
    public class TolLimitViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Limit { get; set; }
        [Required]
        [StringLength(50)]
        public string Bonus { get; set; }
    }
}
