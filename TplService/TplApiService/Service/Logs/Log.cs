using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
namespace TplApiService.log.Service
{
    public class Log : ILog
    {
        internal static Logger Logger;

        public void LogError(Exception exception)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("Log\\LogError.txt")
            .CreateLogger();
            Logger.Information("Error Log ------------------------------------------------------------------------------ --" + DateTime.Now.ToString("yyyy - MM - dd HH:mm:ss"));
          
            
            Log.Logger.Error(exception, exception.Message);
        }
    }
}
