using System;
using System.Collections.Generic;
using System.Linq;
using Tpl.Api.Models;
using Tpl.Api.Models.Db_Models;
using Tpl.Api.Models.view_Models;
using Tpl.Api.service.ITPLService;

namespace Tpl.Api.service.TPLService
{
    public class TplLimitService : BaseService, ITplLimitService
    {
        private ILogService _LogService;
        public TplLimitService(TPLContext Context, ILogService LogService)
        : base(Context)
        {
            _LogService = LogService;
        }

        public bool TplDeleteLimit(int id)
        {
            try
            {
                var tpl = _Context.TplModels.FirstOrDefault(x => x.TplImitId == id);
                if (tpl != null)
                {
                    return false;
                }
                var limit = _Context.TplLimits.FirstOrDefault(x => x.Id == id);

                if (limit == null)
                {
                    return false;
                }
                _Context.TplLimits.Remove(limit);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _LogService.LogError(ex);
                return false;
            }

        }

        public bool TplEditLimit(TolLimitViewModel tpl)
        {
            try
            {
                var _limit = _Context.TplLimits.FirstOrDefault(x => x.Id == tpl.Id);
                if (_limit != null)
                {
                    _limit.Limit = tpl.Limit;
                    _limit.Bonus = tpl.Bonus;
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

        public List<TolLimitViewModel> TplGetLimit()
        {
            try
            {
                return _Context.TplLimits.Select(x => new TolLimitViewModel()
                {
                    Id = x.Id,
                    Bonus = x.Bonus,
                    Limit = x.Limit

                }).ToList();

            }
            catch (Exception ex)
            {
                _LogService.LogError(ex);
                return null;
            }
        }
        public TolLimitViewModel TplGetLimit(int id)
        {
            try
            {
                var lim = _Context.TplLimits.FirstOrDefault(x => x.Id == id);
                if (lim == null)
                {
                    return null;
                }

                return new TolLimitViewModel()
                {
                    Bonus=lim.Bonus,
                    Limit=lim.Limit,
                    Id=lim.Id
                };

            }
            catch (Exception ex)
            {
                _LogService.LogError(ex);
                return null;
            }
        }

        public bool TplSetLimit(TolLimitViewModel tpl)
        {
            try
            {
                _Context.TplLimits.Add(new TplLimit()
                {
                    Bonus = tpl.Bonus,
                    Limit=tpl.Limit,
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
