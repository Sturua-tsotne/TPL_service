using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tpl.Api.Models.view_Models;
using Tpl.Api.Models.view_Models.responseViewModel;
using TplApiService.Service.TplService;

namespace TplApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TplAdminController : BaseController
    {
        private ITplAdminService _tplAdminService;
        public TplAdminController(ITplAdminService tplAdminService)
        {
            _tplAdminService = tplAdminService;
        }

        [HttpPost("TplChangeStatus")]
        public async Task<bool> TplChangeStatus(int id, bool status)
        {
            return  await _tplAdminService.TplChangeStatus(id, status, UserId());
        }
       
        [HttpPost("TplEdit")]
        public  async Task<bool> TplEdit(TplInfoResponseModel Tpl)
        {
            return await _tplAdminService.TplEdit(Tpl, UserId());
        }
        [HttpPost("TplEditLimit")]
        public async Task<bool> TplEditLimit(TolLimitViewModel tpl)
        {
            return await _tplAdminService.TplEditLimit(tpl, UserId());
        }
        [HttpPost("TplSetCarModels")]
        public async Task<bool> TplSetCarModels(CarModelsResponseModel tpl)
        {
           return await _tplAdminService.TplSetCarModels(tpl);
        }
        [HttpPost("TplSetLimit")]
        public async Task<bool> TplSetLimit(TolLimitViewModel tpl)
        {
            return await _tplAdminService.TplSetLimit(tpl, UserId());
        }
        [HttpPost("TplSetManufacturer")]
        public async Task<bool> TplSetManufacturer(TplCarManufacturerResponseModel tpl)
        {
            return await _tplAdminService.TplSetManufacturer(tpl);
        }
        [HttpDelete]
        [Route("TplDelete/{id}")]
        public async Task<bool> TplDelete(int id)
        {
            return await _tplAdminService.TplDelete(id, UserId());
        }
        [HttpDelete]
        [Route("TplDeleteLimit/{id}")]
        public async Task<bool> TplDeleteLimit(int id)
        {
            return await _tplAdminService.TplDeleteLimit(id, UserId());
        }
    }
}
