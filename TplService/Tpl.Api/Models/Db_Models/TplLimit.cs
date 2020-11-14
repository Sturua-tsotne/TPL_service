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
        public string Limit { get; set; }
        public string Bonus { get; set; }
        public int TplModelId { get; set; }

        public virtual TplModel TplModel { get; set; }


    }
}
