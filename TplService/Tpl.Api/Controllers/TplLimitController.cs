using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tpl.Api.Models.view_Models;

namespace Tpl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TplLimitController : ControllerBase
    {
        [HttpGet]
        [Route("TplGetLimit")]
        public IEnumerable<TolLimitViewModel> TplGetLimit()
        {
            return null;
        }


        [HttpGet]
        [Route("TplGetLimit/{id}")]
        public TolLimitViewModel TplGetLimit(int id)
        {
            return null;
        }

        [HttpPost("TplSetLimit")]
        public bool TplSetLimit(TolLimitViewModel tpl)
        {

            return true;
        }

        [HttpPost("TplEditLimit")]
        public bool TplEditLimit(TolLimitViewModel tpl)
        {

            return true;
        }

        [HttpDelete]
        [Route("TplDeleteLimit/{id}")]
        public bool TplDeleteLimit(int id)
        {
            return true;
        }

    }
}
