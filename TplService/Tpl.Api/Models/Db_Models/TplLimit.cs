using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tpl.Api.Models.Db_Models
{
    public partial class TplLimit
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
