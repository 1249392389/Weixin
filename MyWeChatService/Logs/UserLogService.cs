using MyWeChatModel;
using MyWeChatRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeChatService.Logs
{
    public class UserLogService
    {
        public static void AddUserLog(UserLog entity)
        {
            if (entity!=null)
            {
                UserLogHandler.AddSysUserLogs(entity);
            }
        }
    }
}
