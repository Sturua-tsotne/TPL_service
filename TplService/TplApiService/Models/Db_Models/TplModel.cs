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
            TplLimits = new HashSet<TplLimit>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public bool Status { get; set; }
        public int TplImitId { get; set; }
        public int CarFeatureId { get; set; }
        public int PersonalInformationId { get; set; }

        public virtual CarFeature CarFeature { get; set; }
        public virtual PersonalInformation PersonalInformation { get; set; }
        public virtual ICollection<TplLimit> TplLimits { get; set; }
    }
}
