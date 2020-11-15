using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Tpl.Api.Models;

namespace TplApiService.Service
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
