using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tpl.Api.Models.view_Models.requestViewmodels;
using Tpl.Api.Models.view_Models.responseViewModel;
using Tpl.Api.service.ITPLService;
using Tpl.Api.service.TPLService;

namespace Tpl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TplCarInfoController : ControllerBase
    {
        private ITplCarInfoService _tplCarInfoService;

        public TplCarInfoController(TplCarInfoService tplCarInfoService)
        {
            _tplCarInfoService = tplCarInfoService;
        }

        [HttpGet]
        [Route("TplGetCarInf")]
        public IEnumerable<TplCarInfoRequestModel> TplGetCarInf()
        {
            return _tplCarInfoService.TplGetCarInf();
        }
        [HttpGet]
        [Route("TplGetCarInf/{id}")]
        public TplCarInfoRequestModel TplGetCarInf(int id)
        {
            return _tplCarInfoService.TplGetCarInf(id);
        }
        [HttpPost("TplSetManufacturer")]
        public bool TplSetManufacturer(TplCarManufacturerResponseModel tpi)
        {
            return _tplCarInfoService.TplSetManufacturer(tpi);
        }

        [HttpPost("TplSetCarModels")]
        public bool TplSetCarModels(CarModelsResponseModel tpi)
        {
            return _tplCarInfoService.TplSetCarModels(tpi);
        }

    }
} 
