using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tpl.Api.Models.view_Models;
using Tpl.Api.Models.view_Models.requestViewmodels;
using Tpl.Api.Models.view_Models.responseViewModel;
using TplApiService.Service.TplService;

namespace TplApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TplCallApiController : BaseController
    {
        private ITplService _tplService;
        public TplCallApiController(ITplService tplService)
        {
          
            _tplService = tplService;
        }   
        [HttpGet]
        [Route("GetTpl")]
        public async Task<IEnumerable<TplRequestModel>> GetTpl()
        {
            return await _tplService.GetTpl(UserId());
        }

        [HttpGet]
        [Route("GetTpl/{id}")]
        public async Task<TplRequestModel> GetTpl(int id)
        {
            return await _tplService.GetTpl(id, UserId());
        }

        [HttpPost("SetTpl")]
        public async Task<bool> SetTpl(TplInfoResponseModel tplinfo)
        {
            return await _tplService.SetTpl(tplinfo, UserId());
        }

        [HttpGet]
        [Route("GatLimit")]
        public async Task<IEnumerable<TolLimitViewModel>> GatLimit()
        {
            return await _tplService.GatLimit(UserId());
        }
    }
}
