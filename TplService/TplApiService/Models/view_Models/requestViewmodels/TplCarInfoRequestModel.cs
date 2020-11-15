using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tpl.Api.Models.Db_Models;

namespace Tpl.Api.Models.view_Models.requestViewmodels
{
    public class TplCarInfoRequestModel
    {

        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public List<CarModel> CarModels { get; set; }

    }
}
