using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tpl.Api.Models.view_Models;
using Tpl.Api.Models.view_Models.responseViewModel;

namespace TplApiService.Service.TplService
{
   public interface ITplAdminService
    {
        public Task<bool> TplEdit(TplInfoResponseModel Tpl, int clientid);
        public Task<bool> TplChangeStatus(int id, bool status, int clientid);
        public Task<bool> TplDelete(int id, int clientid);
        public Task<bool> TplSetLimit(TolLimitViewModel tpl, int clientid);
        public Task<bool> TplEditLimit(TolLimitViewModel tpl, int clientid);
        public Task<bool> TplDeleteLimit(int id, int clientid);
        public Task<bool> TplSetManufacturer(TplCarManufacturerResponseModel tpl);
        public Task<bool> TplSetCarModels(CarModelsResponseModel tpl);
    }
}
