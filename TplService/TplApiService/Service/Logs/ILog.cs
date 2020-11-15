using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TplApiService.log.Service
{
  public  interface ILog
    {
        public void LogError(Exception exception);
    }
}
