using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tpl.Api.Models;
using Tpl.Api.Models.Db_Models;
using Tpl.Api.Models.view_Models;
using Tpl.Api.Models.view_Models.responseViewModel;
using TplApiService.log.Service;

namespace TplApiService.Service.TplService
{
    public class TplAdminService : BaseService, ITplAdminService
    {
        private ILog _Log;
        public TplAdminService(TPLContext Context, ILog log)
        : base(Context)
        {
            _Log = log;
        }

        public async Task<bool> TplChangeStatus(int id, bool status, int clientid)
        {
            try
            {
                var tpl = await _Context.TplModels.FirstOrDefaultAsync(x => x.Id == id && x.ClientId==clientid);
                if (tpl != null)
                {
                    tpl.Status = status;
                  await   _Context.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _Log.LogError(ex);
                return false;
            }
        }

        public async Task<bool> TplDelete(int id, int clientid)
        {
            try
            {
                var tpl = await _Context.TplModels.FirstOrDefaultAsync(x => x.Id == id&& x.ClientId== clientid);
                if (tpl != null)
                {
                    if (tpl.Status == false)
                    {

                        var persinfo = await _Context.PersonalInformations.FirstOrDefaultAsync(p => p.TplModelId == tpl.Id);
                        var CarFeat = await _Context.CarFeatures.FirstOrDefaultAsync(c => c.TplModelId == tpl.Id);

                        _Context.PersonalInformations.Remove(persinfo);
                        _Context.CarFeatures.Remove(CarFeat);
                        _Context.TplModels.Remove(tpl);

                        await _Context.SaveChangesAsync();
                        return true;
                    }

                }
                return false;
            }
            catch (Exception ex)
            {
                _Log.LogError(ex);
                return false;
            }
        }


        public async Task<bool> TplEdit(TplInfoResponseModel Tpl, int clientid)
        {
            try
            {
                var tpl = await _Context.TplModels.FirstOrDefaultAsync(x => x.Id == Tpl.Id &&x.ClientId==clientid);
                if (tpl != null)
                {
                    var personinfo = await _Context.PersonalInformations.FirstOrDefaultAsync(p => p.TplModelId == tpl.Id);
                    var carinfo = await _Context.CarFeatures.FirstOrDefaultAsync(c => c.TplModelId == tpl.Id);

                    tpl.Status = Tpl.Status;
                    tpl.TplImitId = Tpl.TplImitId;

                    if (personinfo.PersonalNumber != Tpl.PersonalNumber)
                    {
                        var personid = await _Context.PersonalInformations.FirstOrDefaultAsync(p => p.PersonalNumber == Tpl.PersonalNumber);
                        if (personid != null)
                        {
                            return false;
                        }
                        personinfo.PersonalNumber = Tpl.PersonalNumber;
                    }

                    personinfo.Name = Tpl.Name;
                    personinfo.LastName = Tpl.LastName;
                    personinfo.IdentityImg = Tpl.IdentityImg;
                    personinfo.MobileNumber = Tpl.MobileNumber;
                    personinfo.DateBirth = Tpl.DateBirth;
                    personinfo.Email = Tpl.Email;

                    if (carinfo.RegistrationNumber != Tpl.RegistrationNumber)
                    {
                        var RegistrationNum = await _Context.CarFeatures.FirstOrDefaultAsync(c => c.RegistrationNumber == Tpl.RegistrationNumber);
                        if (RegistrationNum != null)
                        {
                            return false;
                        }
                        carinfo.RegistrationNumber = Tpl.RegistrationNumber;
                    }
                    carinfo.ReleaseTime = Tpl.ReleaseTime;
                    carinfo.CarModelId = Tpl.CarModelId;

                   await _Context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _Log.LogError(ex);
                return false;
            }
        }



        public async Task<bool> TplDeleteLimit(int id, int clientid)
        {
            try
            {
                var tpl = await _Context.TplModels.FirstOrDefaultAsync(x => x.TplImitId == id&& x.ClientId==clientid);
                if (tpl != null)
                {
                    return false;
                }
                var limit = await _Context.TplLimits.FirstOrDefaultAsync(x => x.Id == id && x.ClientId == clientid);

                if (limit == null)
                {
                    return false;
                }
                _Context.TplLimits.Remove(limit);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Log.LogError(ex);
                return false;
            }
        }
        public async Task<bool> TplEditLimit(TolLimitViewModel tpl, int clientid)
        {
            try
            {
                var _limit = await _Context.TplLimits.FirstOrDefaultAsync(x => x.Id == tpl.Id && x.ClientId == clientid);
                if (_limit != null)
                {
                    _limit.Limit = tpl.Limit;
                    _limit.Bonus = tpl.Bonus;
                    await _Context.SaveChangesAsync();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                _Log.LogError(ex);
                return false;
            }
        }
        public async Task<bool> TplSetLimit(TolLimitViewModel tpl, int clientid)
        {

            try
            {
                await _Context.TplLimits.AddAsync(new TplLimit()
                {
                    Bonus = tpl.Bonus,
                    Limit = tpl.Limit,
                    ClientId= clientid
                });
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Log.LogError(ex);
                return false;
            }
        }


        public async Task<bool> TplSetCarModels(CarModelsResponseModel tpl)
        {
            try
            {

               await _Context.CarModels.AddAsync(new CarModel()
                {
                    CarManufacturerId = tpl.CarManufacturerId,
                    Model = tpl.Model
                });
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Log.LogError(ex);
                return false;
            }
        }

      

        public async Task<bool> TplSetManufacturer(TplCarManufacturerResponseModel tpl)
        {
            try
            {

               await _Context.CarManufacturers.AddAsync(new CarManufacturer()
                {
                    Manufacturer = tpl.Manufacturer,

                });
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _Log.LogError(ex);
                return false;
            }
        }
    }
}
