using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tpl.Api.Models.view_Models.requestViewmodels;
using Tpl.Api.Models.view_Models.responseViewModel;

namespace Tpl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TplCarInfoController : ControllerBase
    {
        [HttpGet]
        [Route("TplGetCarInf")]
        public IEnumerable<TplCarInfoRequestModel> TplGetCarInf()
        {
            return null;
        }
        [HttpGet]
        [Route("TplGetCarInf/{id}")]
        public TplCarInfoRequestModel TplGetCarInf(int id)
        {
            return null;
        }
        [HttpPost("TplSetManufacturer")]
        public bool TplSetManufacturer(TplCarManufacturerResponseModel tpi)
        {
            return true;
        }

        [HttpPost("TplSetCarModels")]
        public bool TplSetCarModels(CarModelsResponseModel tpi)
        {
            return true;
        }

    }
} 
