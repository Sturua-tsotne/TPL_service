using System;
using System.Collections.Generic;
using System.Linq;

using TplApiService.log.Service;
using Tpl.Api.Models;
using TplApiService.Service;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tpl.Api.Models.view_Models.requestViewmodels;
using Tpl.Api.Models.view_Models.responseViewModel;
using Tpl.Api.Models.Db_Models;
using Tpl.Api.Models.view_Models;

namespace TplApiService.Service.TplService
{
    public class TplService : BaseService, ITplService
    {
       private ILog _Log;
        public TplService(TPLContext Context, ILog log)
      : base(Context)
        {
            _Log = log;
        }

        public async Task<List<TolLimitViewModel>> GatLimit(int clientid)
        {
            try
            {
                var Limit = await _Context.TplLimits.Where(x => x.ClientId == clientid).ToArrayAsync();
                return  Limit.Select(x => new TolLimitViewModel()
                {
                    Id = x.Id,
                    Bonus = x.Bonus,
                    Limit = x.Limit

                }).ToList();

            }
            catch (Exception ex)
            {
                _Log.LogError(ex);
                return null;
            }
        }

        public async Task<List<TplRequestModel>> GetTpl(int clientid)
        {
            try
            {
                var Tpl = await _Context.TplModels.Where(x => x.ClientId == clientid).ToArrayAsync();
                return Tpl.Select(x => new TplRequestModel()
                {
                    Id = x.Id,
                    Status = x.Status,
                    TplLimits = _Context.TplLimits.FirstOrDefault(t => t.Id == x.TplImitId),
                    Personinfo = _Context.PersonalInformations.FirstOrDefault(p => p.TplModelId == x.Id),
                    CarFeature = _Context.CarFeatures.FirstOrDefault(c => c.TplModelId == x.Id)

                }).ToList();
            }
            catch (Exception ex)
            {
                _Log.LogError(ex);
                return null;
            }
        }

        public async Task<TplRequestModel> GetTpl(int id, int clientid)
        {
            try
            {
               
                var tpl = await _Context.TplModels.FirstOrDefaultAsync(x => x.Id == id && x.ClientId==clientid);
                if (tpl != null)
                {

                    return new TplRequestModel()
                    {
                        Id = tpl.Id,
                        Status = tpl.Status,
                        TplLimits = _Context.TplLimits.FirstOrDefault(t => t.Id == tpl.TplImitId),
                        Personinfo = _Context.PersonalInformations.FirstOrDefault(p => p.TplModelId == tpl.Id),
                        CarFeature = _Context.CarFeatures.FirstOrDefault(c => c.TplModelId == tpl.Id)
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                _Log.LogError(ex);
                return null;
            }
        }

        public async Task<bool> SetTpl(TplInfoResponseModel Tpl, int clientid)
        {
            try
            {
                var tplnew = new TplModel()
                {
                    Status = Tpl.Status,
                    TplImitId = Tpl.TplImitId,
                    ClientId= clientid

                };
                var personid =await _Context.PersonalInformations.FirstOrDefaultAsync(p => p.PersonalNumber == Tpl.PersonalNumber);
                if (personid != null)
                {
                    return false;
                }
                var personinfonew = new PersonalInformation()
                {
                    Name = Tpl.Name,
                    LastName = Tpl.LastName,
                    IdentityImg = Tpl.IdentityImg,
                    MobileNumber = Tpl.MobileNumber,
                    DateBirth = Tpl.DateBirth,
                    Email = Tpl.Email,
                    PersonalNumber = Tpl.PersonalNumber,
                    


                };
                var RegistrationNum = await _Context.CarFeatures.FirstOrDefaultAsync(c => c.RegistrationNumber == Tpl.RegistrationNumber);
                if (RegistrationNum != null)
                {
                    return false;
                }
                var carinfonew = new CarFeature()
                {
                    ReleaseTime = Tpl.ReleaseTime,
                    CarModelId = Tpl.CarModelId,
                    RegistrationNumber = Tpl.RegistrationNumber,
                    

                };

                await _Context.TplModels.AddAsync(tplnew);
                await _Context.PersonalInformations.AddAsync(personinfonew);
                await _Context.CarFeatures.AddAsync(carinfonew);
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
