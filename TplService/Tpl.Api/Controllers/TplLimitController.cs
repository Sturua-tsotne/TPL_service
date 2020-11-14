using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tpl.Api.Models.view_Models;
using Tpl.Api.service.ITPLService;
using Tpl.Api.service.TPLService;

namespace Tpl.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
  
    public class TplLimitController : ControllerBase
    {
        private ITplLimitService _tplLimitService;

      public TplLimitController(ITplLimitService tplLimitService)
        {
            _tplLimitService = tplLimitService;
        }



        [HttpGet]
        [Route("TplGetLimit")]
        public IEnumerable<TolLimitViewModel> TplGetLimit()
        {
            return _tplLimitService.TplGetLimit();
        }


        [HttpGet]
        [Route("TplGetLimit/{id}")]
        public TolLimitViewModel TplGetLimit(int id)
        {
            return _tplLimitService.TplGetLimit(id);
        }

        [HttpPost("TplSetLimit")]
        public bool TplSetLimit(TolLimitViewModel tpl)
        {

            return _tplLimitService.TplSetLimit(tpl);
        }

        [HttpPost("TplEditLimit")]
        public bool TplEditLimit(TolLimitViewModel tpl)
        {

            return _tplLimitService.TplEditLimit(tpl);
        }

        [HttpDelete]
        [Route("TplDeleteLimit/{id}")]
        public bool TplDeleteLimit(int id)
        {
            return _tplLimitService.TplDeleteLimit(id);
        }

    }
}
