using log4net;
using log4net.Config;
using System.IO;
using static FatalAnalyzerAttribute;
using System.Text;

namespace LoggerConfig
{
    public static class LogConfig
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static LogConfig()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var configFile = new FileInfo(@".\config\log4net.config");
            XmlConfigurator.ConfigureAndWatch(configFile);
            log.Info("Log4net 配置已加载");
        }

        public static ILog GetLogger()
        {
            return log;
        }
    }
}
