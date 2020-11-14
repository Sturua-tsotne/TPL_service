using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tpl.Api.Models.view_Models.requestViewmodels
{
    public class TplInfoRequestViewModel
    {
        public int Id { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public int CarFeatureId { get; set; }
        [Required]
        public int TplImitId { get; set; }
        public string RegistrationNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseTime { get; set; }
        [Required]
        public int CarModelId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string PersonalNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateBirth { get; set; }
        [Required]
        [StringLength(12)]
        public string MobileNumber { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string IdentityImg { get; set; }
    }
}
