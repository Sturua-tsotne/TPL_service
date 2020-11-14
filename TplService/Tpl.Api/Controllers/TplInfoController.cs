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
    public class TplInfoController : ControllerBase
    {
        [HttpGet]
        [Route("TplGetInfo")]
        public IEnumerable<TplInfoRequestViewModel> TplGetInfo()
        {
            return null;
        }

        [HttpGet]
        [Route("TplGetInfo/{carId}")]
        public IEnumerable<TplInfoRequestViewModel> TplGetInfo(int id)
        {
            return null;
        }

        [HttpPost("TplSetInfo")]
        public bool TplSetInfo(TplInfoResponseModel Tpl)
        {
            return true;
        }

        [HttpDelete]
        [Route("TplDeleteInfo/{carId}")]
        public bool TplDeleteInfo(int id)
        {
            return true;
        }

        [HttpPost("TplChangeStatus")]
        public bool TplChangeStatus(int id, bool status)
        {
            return true;
        }
    }
}
