using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tpl.Api.Models.Db_Models
{
    public partial class PersonalInformation
    {

        public PersonalInformation()
        {
            TplModels = new HashSet<TplModel>();
        }

        public int Id { get; set; }
        public int TplModelId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime DateBirth { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string IdentityImg { get; set; }

        public virtual ICollection<TplModel> TplModels { get; set; }

    }
}
