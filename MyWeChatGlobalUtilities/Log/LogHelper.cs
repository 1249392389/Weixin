using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeChatGlobalUtilities.Log
{
    public class LogHelper
    {
        static readonly ILog loginfo = LogManager.GetLogger("loginfo");
        public static void Init()
        {
            log4net.Config.XmlConfigurator.Configure(
                new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Config\\log4net.config")
                );
        }
        public static void Info(string Msg)
        {
            loginfo.Info(Msg);
        }
    }
}
