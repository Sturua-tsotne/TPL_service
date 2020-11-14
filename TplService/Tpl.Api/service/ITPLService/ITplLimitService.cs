using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tpl.Api.Models.view_Models;

namespace Tpl.Api.service.ITPLService
{
    public interface ITplLimitService
    {
        public List<TolLimitViewModel> TplGetLimit();
        public TolLimitViewModel TplGetLimit(int id);
        public bool TplSetLimit(TolLimitViewModel tpl);
        public bool TplEditLimit(TolLimitViewModel tpl);
        public bool TplDeleteLimit(int id);
    }
}
