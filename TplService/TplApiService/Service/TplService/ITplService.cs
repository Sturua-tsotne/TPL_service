using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tpl.Api.Models.view_Models;
using Tpl.Api.Models.view_Models.requestViewmodels;
using Tpl.Api.Models.view_Models.responseViewModel;

namespace TplApiService.Service.TplService
{
  public  interface ITplService
    {
        public Task<List<TplRequestModel>> GetTpl(int clientid);

        public Task<TplRequestModel> GetTpl(int id, int clientid);

        public Task<bool> SetTpl(TplInfoResponseModel tplinfo,int clientid);

        public Task<List<TolLimitViewModel>> GatLimit(int clientid);
    }
}
