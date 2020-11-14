using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tpl.Api.Models.view_Models.requestViewmodels;
using Tpl.Api.Models.view_Models.responseViewModel;

namespace Tpl.Api.service.ITPLService
{
   public interface ITplInfoService
    {
        public IEnumerable<TplInfoRequestModel> TplGetInfo();
        public TplInfoRequestModel TplGetInfo(int id);
        public bool TplSetInfo(TplInfoResponseModel Tpl);
        public bool TplEditInfo(TplInfoResponseModel Tpl);
        public bool TplChangeStatus(int id, bool status);
        public bool TplDeleteInfo(int id);
    }
}
