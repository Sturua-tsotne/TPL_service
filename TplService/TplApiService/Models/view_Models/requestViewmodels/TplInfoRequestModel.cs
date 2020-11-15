using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tpl.Api.Models.view_Models.requestViewmodels
{
    public class TplInfoRequestModel
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public int CarFeatureId { get; set; }
        public int TplImitId { get; set; }
        public string RegistrationNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseTime { get; set; }
        public int CarModelId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateBirth { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string IdentityImg { get; set; }
    }
}
