using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tpl.Api.Models.Db_Models;

namespace Tpl.Api.Models.view_Models.requestViewmodels
{
    public class TplRequestModel
    {
        public int Id { get; set; }
        [Required]
        public bool Status { get; set; }

        public TplLimit TplLimits { get; set; }

        public PersonalInformation Personinfo { get; set; }
         
        public CarFeature CarFeature { get; set; }

    }
}
