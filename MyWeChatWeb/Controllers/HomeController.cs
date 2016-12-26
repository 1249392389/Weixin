using MyWeChatService;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
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
            var state = "WangKai-" + DateTime.Now.Millisecond;//随机数，用于识别请求可靠性
            Session["State"] = state;//储存随机数到Session
            //此页面引导用户点击授权
            ViewData["UrlUserInfo"] =
                OAuthApi.GetAuthorizeUrl(AppId,
                "http://1p623v6690.iok.la/Home/UserInfoCallback",
                state, OAuthScope.snsapi_userinfo);
            return View();
        }
        public ActionResult UserInfoCallback(string code, string state, string returnUrl)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Content("您拒绝了授权！");
            }

            if (state != Session["State"] as string)
            {
                return Content("验证失败！请从正规途径进入！");
            }
            OAuthAccessTokenResult result = OAuthApi.GetAccessToken(AppId, AppSecret, code);
            OAuthUserInfo userInfo = OAuthApi.GetUserInfo(result.access_token, result.openid);  
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
            return View(userInfo);
        }
        [HttpPost]
        public ActionResult Post(string scanQRCode)
        {
            string pwd = "jwysoft20122012,";
            WebReference.Service1 method = new WebReference.Service1();
            string result = "\r\n查询结果：\r\n" + method.QueryContract(pwd, scanQRCode);
            return Json(result);
        }
    }
}