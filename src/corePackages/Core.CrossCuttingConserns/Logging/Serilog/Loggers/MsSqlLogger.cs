using Core.CrossCuttingConserns.Logging.Serilog.ConfigurationModels;
using Core.CrossCuttingConserns.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConserns.Logging.Serilog.Loggers
{
    public class MsSqlLogger : LoggerServiceBase
    {
        IConfiguration _configuration;
        public MsSqlLogger(IConfiguration configuration)
        {
            _configuration = configuration;

            var logConfig = configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration")
                                .Get<MsSqlConfiguration>() ??
                            throw new Exception(SerilogMessages.NullOptionsMessage);
            var sinkOpts = new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true };
            var columnOpts = new ColumnOptions();
            columnOpts.Store.Remove(StandardColumn.Message);
            columnOpts.Store.Remove(StandardColumn.Properties);

            var seriLogConfig = new LoggerConfiguration()
                .WriteTo.MSSqlServer(connectionString: logConfig.ConnectionString, sinkOptions: sinkOpts, columnOptions: columnOpts)
                .CreateLogger();

            Logger = seriLogConfig;
        }
    }
    
    
}
