using MyWeChatService;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.Helpers;
using Senparc.Weixin.MP.MvcExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public string timestamp = string.Empty;
        public string nonceStr = string.Empty;
        public string signature = string.Empty;
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Content(PostModel postModel, string echostr)
        {
            string ticket = string.Empty;
            timestamp = JSSDKHelper.GetTimestamp();
            nonceStr = JSSDKHelper.GetNoncestr();
            JSSDKHelper jssdkhelper = new JSSDKHelper();
            ticket = JsApiTicketContainer.TryGetJsApiTicket(AppId, AppSecret);
            signature = JSSDKHelper.GetSignature(ticket, nonceStr, timestamp, Request.Url.AbsoluteUri.ToString());
            ViewBag.signature = signature;
            ViewBag.appid = AppId;
            ViewBag.timestamp = timestamp;
            ViewBag.noncestr = nonceStr;
            return View();
        }
        [HttpPost]
        public ActionResult Post(string scanQRCode)
        {
            string pwd = "jwysoft20122012,";
            WebReference.Service1 method = new WebReference.Service1();
            string result = method.QueryContract(pwd, scanQRCode);
            return Json(result);
        }
    }
}