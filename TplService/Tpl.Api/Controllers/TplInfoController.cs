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
        public IEnumerable<TplInfoRequestModel> TplGetInfo()
        {
            return null;
        }

        [HttpGet]
        [Route("TplGetInfo/{id}")]
        public TplInfoRequestModel  TplGetInfo(int id)
        {
            return null;
        }

        [HttpPost("TplSetInfo")]
        public bool TplSetInfo(TplInfoResponseModel Tpl)
        {
            return true;
        }
        [HttpPost("TpEditInfo")]
        public bool TplEditInfo(TplInfoResponseModel Tpl)
        {
            return true;
        }


        [HttpPost("TplChangeStatus")]
        public bool TplChangeStatus(int id, bool status)
        {
            return true;
        }

        [HttpDelete]
        [Route("TplDeleteInfo/{id}")]
        public bool TplDeleteInfo(int id)
        {
            return true;
        }
    }
}
