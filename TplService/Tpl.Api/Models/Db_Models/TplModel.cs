using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tpl.Api.Models.Db_Models
{
    public partial class TplModel
    {

        public TplModel()
        {
            CarFeatures = new HashSet<CarFeature>();
            PersonalInformations= new HashSet<PersonalInformation>();
            TplImits = new HashSet<TplLimit>();
        }


        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public int CarFeatureId { get; set; }
        [Required]
        public int PersonalInformationid { get; set; }
        [Required]
        public int TplImitId { get; set; }

        public virtual ICollection<CarFeature> CarFeatures { get; set; }
        public virtual ICollection<PersonalInformation> PersonalInformations { get; set; }
        public virtual ICollection<TplLimit> TplImits { get; set; }
    }
}
