using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tpl.Api.Models;

namespace Tpl.Api.service
{
    public class BaseService
    {
        protected TPLContext _Context;

        public BaseService(TPLContext Context)
        {
            _Context = Context;
        }
    }
}
