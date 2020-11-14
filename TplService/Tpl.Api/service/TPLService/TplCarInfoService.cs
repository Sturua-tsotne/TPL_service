using System;
using System.Collections.Generic;
using System.Linq;
using Tpl.Api.Models;
using Tpl.Api.Models.Db_Models;
using Tpl.Api.Models.view_Models.requestViewmodels;
using Tpl.Api.Models.view_Models.responseViewModel;
using Tpl.Api.service.ITPLService;

namespace Tpl.Api.service.TPLService
{
    public class TplCarInfoService : BaseService, ITplCarInfoService
    {
        private ILogService _LogService;
        public TplCarInfoService(TPLContext Context, ILogService logService)
         : base(Context)
        {
            _LogService = logService;
        }

        public IEnumerable<TplCarInfoRequestModel> TplGetCarInf()
        {
            try
            {
                return _Context.CarManufacturers.Select(x => new TplCarInfoRequestModel()
                {
                    Manufacturer = x.Manufacturer,
                    Id = x.Id,
                    //CarModels = x.CarModels.Where(a => a.CarManufacturerId == x.Id).ToList()

                }).ToList();



            }
            catch (Exception ex)
            {
                _LogService.LogError(ex);
                return null;
            }
        }

        public TplCarInfoRequestModel TplGetCarInf(int id)
        {
            try
            {
                var carinfo = _Context.CarManufacturers.FirstOrDefault(x => x.Id == id);
                if (carinfo != null)
                {
                    return new TplCarInfoRequestModel()
                    {
                        Manufacturer = carinfo.Manufacturer,
                        Id = carinfo.Id,
                       // CarModels = carinfo.CarModels.Where(a => a.CarManufacturerId == carinfo.Id).ToList()

                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                _LogService.LogError(ex);
                return null;
            }
        }

        public bool TplSetCarModels(CarModelsResponseModel tpl)
        {
            try
            {
              
                _Context.CarModels.Add(new CarModel()
                {
                    CarManufacturerId = tpl.CarManufacturerId,
                    Model = tpl.Model
                });
                _Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _LogService.LogError(ex);
                return false;
            }
        }

        public bool TplSetManufacturer(TplCarManufacturerResponseModel tpl)
        {
            try
            {
               
                _Context.CarManufacturers.Add(new CarManufacturer()
                {
                  Manufacturer=tpl.Manufacturer,
                   
                });
                _Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _LogService.LogError(ex);
                return false;
            }
        }
    }
}
