using MyWeChatModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeChatRepository
{
    public class UserLogHandler
    {
        public static void AddSysUserLogs(UserLog item)
        {
            Log ContextDb = new Log();
            ContextDb.userlog.Add(item);
            ContextDb.SaveChanges();
        }
    }
}
