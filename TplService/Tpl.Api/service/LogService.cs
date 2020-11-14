using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tpl.Api.service.ITPLService;

namespace Tpl.Api.service
{
    public class LogService : ILogService
    {
      
            public void LogError(Exception exception)
            {
                Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("Log\\LogError.txt")
                .CreateLogger();
                Log.Information("Error Log ------------------------------------------------------------------------------ --" + DateTime.Now.ToString("yyyy - MM - dd HH:mm:ss"));
                Log.Logger.Error(exception, exception.Message);
            }
        
    }
}
