using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tpl.Api.Models.Db_Models
{
    public  partial class TplModel
    {

        public TplModel()
        {

            TplImits = new HashSet<TplLimit>();
        }


        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public bool Status { get; set; }
       
        [Required]
        public int TplImitId { get; set; }

        public virtual ICollection<TplLimit> TplImits { get; set; }
    }
}
