using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeChatModel
{
    public class UserLog
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string AccountName { get; set; }
        public DateTime CreateDate { get; set; }
        public string QueryCode { get; set; }
        public string QueryContent { get; set; }
    }
}
