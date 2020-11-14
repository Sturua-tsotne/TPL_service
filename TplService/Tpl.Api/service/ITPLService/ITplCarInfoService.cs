using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tpl.Api.Models.view_Models.requestViewmodels;
using Tpl.Api.Models.view_Models.responseViewModel;

namespace Tpl.Api.service.ITPLService
{
    interface ITplCarInfoService
    {
        public IEnumerable<TplCarInfoRequestModel> TplGetCarInf();
        public TplCarInfoRequestModel  TplGetCarInf(int id);
        public bool TplSetManufacturer(TplCarManufacturerResponseModel tpi);
        public bool TplSetCarModels(CarModelsResponseModel tpi);
    }
}
