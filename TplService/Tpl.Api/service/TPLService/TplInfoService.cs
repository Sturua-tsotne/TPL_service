using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tpl.Api.Models;
using Tpl.Api.Models.Db_Models;
using Tpl.Api.Models.view_Models.requestViewmodels;
using Tpl.Api.Models.view_Models.responseViewModel;
using Tpl.Api.service.ITPLService;

namespace Tpl.Api.service.TPLService
{
    public class TplInfoService : BaseService, ITplInfoService
    {
        private ILogService _LogService;
        public TplInfoService(TPLContext Context, ILogService LogService)
         : base(Context)
        {
            _LogService = LogService;
        }

        public bool TplChangeStatus(int id, bool status)
        {
            try
            {
                var tpl = _Context.TplModels.FirstOrDefault(x => x.Id == id);
                if (tpl != null)
                {
                    tpl.Status = status;
                    _Context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _LogService.LogError(ex);
                return false;
            }
        }

        public bool TplDeleteInfo(int id)
        {
            try
            {
                var tpl = _Context.TplModels.FirstOrDefault(x => x.Id == id);
                if (tpl != null)
                {
                    if (tpl.Status == false)
                    {

                        var persinfo = _Context.PersonalInformations.FirstOrDefault(p => p.TplModelId == tpl.Id);
                        var CarFeat = _Context.CarFeatures.FirstOrDefault(c => c.TplModelId == tpl.Id);

                        _Context.PersonalInformations.Remove(persinfo);
                        _Context.CarFeatures.Remove(CarFeat);
                        _Context.TplModels.Remove(tpl);

                        return true;
                    }

                }
                return false;
            }
            catch (Exception ex)
            {
                _LogService.LogError(ex);
                return false;
            }
        }

        public bool TplEditInfo(TplInfoResponseModel Tpl)
        {
            try
            {
                var tpl = _Context.TplModels.FirstOrDefault(x => x.Id == Tpl.Id);
                if (tpl != null)
                {
                    var personinfo = _Context.PersonalInformations.FirstOrDefault(p => p.TplModelId == tpl.Id);
                    var carinfo = _Context.CarFeatures.FirstOrDefault(c => c.TplModelId == tpl.Id);

                    tpl.Status = Tpl.Status;
                    tpl.TplImitId = Tpl.TplImitId;

                    if (personinfo.PersonalNumber != Tpl.PersonalNumber)
                    {
                        var personid = _Context.PersonalInformations.FirstOrDefault(p => p.PersonalNumber == Tpl.PersonalNumber);
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
                        var RegistrationNum = _Context.CarFeatures.FirstOrDefault(c => c.RegistrationNumber == Tpl.RegistrationNumber);
                        if (RegistrationNum != null)
                        {
                            return false;
                        }
                        carinfo.RegistrationNumber = Tpl.RegistrationNumber;
                    }
                    carinfo.ReleaseTime = Tpl.ReleaseTime;
                    carinfo.CarModelId = Tpl.CarModelId;

                    _Context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _LogService.LogError(ex);
                return false;
            }

        }

        public List<TplRequestModel> TplGetInfo()
        {
            try
            {
                return _Context.TplModels.Select(x => new TplRequestModel()
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
                _LogService.LogError(ex);
                return null;
            }

        }

        public TplRequestModel TplGetInfo(int id)
        {
            try
            {
                var tpl = _Context.TplModels.FirstOrDefault(x => x.Id == id);
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
                _LogService.LogError(ex);
                return null;
            }
        }

        public bool TplSetInfo(TplInfoResponseModel Tpl)
        {
            try
            {
                var tplnew = new TplModel()
                {
                    Status = Tpl.Status,
                    TplImitId = Tpl.TplImitId

                };
                var personid = _Context.PersonalInformations.FirstOrDefault(p => p.PersonalNumber == Tpl.PersonalNumber);
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
                    PersonalNumber = Tpl.PersonalNumber

                };
                var RegistrationNum = _Context.CarFeatures.FirstOrDefault(c => c.RegistrationNumber == Tpl.RegistrationNumber);
                if (RegistrationNum != null)
                {
                    return false;
                }
                var carinfonew = new CarFeature()
                {
                    ReleaseTime = Tpl.ReleaseTime,
                    CarModelId = Tpl.CarModelId,
                    RegistrationNumber=Tpl.RegistrationNumber,

                };

                _Context.TplModels.Add(tplnew);
                _Context.PersonalInformations.Add(personinfonew);
                _Context.CarFeatures.Add(carinfonew);
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
