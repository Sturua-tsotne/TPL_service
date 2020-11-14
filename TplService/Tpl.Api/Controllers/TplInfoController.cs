using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tpl.Api.Models.view_Models.requestViewmodels;
using Tpl.Api.Models.view_Models.responseViewModel;
using Tpl.Api.service.ITPLService;

namespace Tpl.Api.Controllers
{
    [Authorize]
    
    [Route("api/[controller]")]
    [ApiController]
    public class TplInfoController : ControllerBase
    {
        private ITplInfoService _tplInfoService;
        public TplInfoController(ITplInfoService tplInfoService)
        {
            _tplInfoService= tplInfoService;
        }


        [HttpGet]
        [Route("TplGetInfo")]
        public IEnumerable<TplRequestModel> TplGetInfo()
        {
            return _tplInfoService.TplGetInfo();
        }

        [HttpGet]
        [Route("TplGetInfo/{id}")]
        public TplRequestModel TplGetInfo(int id)
        {
            return _tplInfoService.TplGetInfo(id);
        }

        [HttpPost("TplSetInfo")]
        public bool TplSetInfo(TplInfoResponseModel Tpl)
        {
            return _tplInfoService.TplSetInfo(Tpl);
        }
        [HttpPost("TpEditInfo")]
        public bool TplEditInfo(TplInfoResponseModel Tpl)
        {
            return _tplInfoService.TplEditInfo(Tpl);
        }


        [HttpPost("TplChangeStatus")]
        public bool TplChangeStatus(int id, bool status)
        {
            return _tplInfoService.TplChangeStatus(id, status);
        }

        [HttpDelete]
        [Route("TplDeleteInfo/{id}")]
        public bool TplDeleteInfo(int id)
        {
            return _tplInfoService.TplDeleteInfo(id);
        }
    }
}
