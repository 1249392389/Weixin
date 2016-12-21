using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.MP.Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MyWeChatWeb.Controllers
{
    public class HomeController : Controller
    {
        public static readonly string Token = "MyWeChat";//与微信公众账号后台的Token设置保持一致，区分大小写。
        public static readonly string EncodingAESKey = "0ArtEUtQDYSVTudCqg1mSt61pqdJPHOG4csPWYZUTCB ";//与微信公众账号后台的EncodingAESKey设置保持一致，区分大小写。
        public static readonly string AppId = "wx739b4a998d710f0b";//与微信公众账号后台的AppId设置保持一致，区分大小写。
        public static readonly string AppSecret = "96c92d012934a873820d97084c18d93d";
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Content(PostModel postModel, string echostr)
        {
            string string1 = "jsapi_ticket=kgt8ON7yVITDhtdwci0qedbtX1Uj0AuL9VIXOfX4Q_-LS8dfy3tafegzCxKVHYO6iBuWVzkhGYR_qtnJH4YQvA&noncestr=Wm3WZYTPz0wzccnW&timestamp=1414587457&url=http://1p623v6690.iok.la/Home/Content";
            byte[] cleanBytes = Encoding.Default.GetBytes(string1);
            byte[] hashedBytes = System.Security.Cryptography.SHA1.Create().ComputeHash(cleanBytes);
            ViewBag.signature = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();



            //var accessToken = AccessTokenContainer.TryGetAccessToken(AppId, AppSecret);
            //var jsticket = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi";
            ViewBag.appid = AppId;
            ViewBag.timestamp = 1414587457;
            ViewBag.noncestr = "Wm3WZYTPz0wzccnW";
            return View();
        }
    }
}