using MyWeChatService.QYService;
using Senparc.Weixin;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin.MP;
using Senparc.Weixin.QY.AdvancedAPIs;
using Senparc.Weixin.QY.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeChatWeb.Controllers
{
    public class QYOAuth2Controller : Controller
    {
        public static readonly string Token = "TJWPWeChat";//与微信企业账号后台的Token设置保持一致，区分大小写。
        public static readonly string EncodingAESKey = "OQQERidhGDIaTjEj2YgVdswu51V2xOFOL8rDrSuyy2u";//与微信企业账号后台的EncodingAESKey设置保持一致，区分大小写。
        public static readonly string CorpId = "wxe8074ed784fc094b";                                //与微信企业账号后台的EncodingAESKey设置保持一致，区分大小写。
        public static readonly string CorpSecret = "3mMigRYCXzg_sjvtyVTnJR6XW7b_TklxpPANz-jl6bEosHEuLLczPcJ8lHg5uTZN";
        Senparc.Weixin.QY.AdvancedAPIs.OAuth2.GetUserInfoResult userInfo = null;
        // GET: QYOAuth2
        public ActionResult Index()
        {
            var state = "Wangkai-" + DateTime.Now.Millisecond;//随机数，用于识别请求可靠性
            Session["State"] = state;//储存随机数到Session
            string code = OAuth2Api.GetCode(CorpId, "http://1p623v6690.iok.la/QYOAuth2/ShowContent", state, "code", "snsapi_base");
            ViewData["UrlBase"] = code;
            return View(); //https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx140262311b599a34&redirect_uri=http://mpwechatserver.chinacloudsites.cn/oauth2/QYBaseCallback&response_type=code&scope=snsapi_base&state=TJMicroPower#wechat_redirect
        }
        public ActionResult ShowContent(string code, string state)
        {
            #region 获取用户code
            if (string.IsNullOrEmpty(code))
            {
                return Content("您拒绝了授权！");
            }

            if (state != Session["State"] as string)
            {
                //这里的state其实是会暴露给客户端的，验证能力很弱，这里只是演示一下
                //实际上可以存任何想传递的数据，比如用户ID，并且需要结合例如下面的Session["OAuthAccessToken"]进行验证
                return Content("验证失败！请从正规途径进入！");
            }

            //企业号：通过验证，获取access_token
            var accessToken = Senparc.Weixin.QY.CommonAPIs.CommonApi.GetToken(CorpId, CorpSecret);
            if (accessToken.errcode != ReturnCode_QY.请求成功)
            {
                return Content("错误：" + accessToken.errmsg);
            }
            //下面2个数据也可以自己封装成一个类，储存在数据库中（建议结合缓存）
            //如果可以确保安全，可以将access_token存入用户的cookie中，每一个人的access_token是不一样的
            //Session["OAuthAccessTokenStartTime"] = DateTime.Now;
            //Session["OAuthAccessToken"] = accessToken;

            //因为这里还不确定用户是否关注本微信，所以只能试探性地获取一下            
            try
            {
                //已关注，可以得到详细信息
                userInfo = Senparc.Weixin.QY.AdvancedAPIs.OAuth2Api.GetUserId(accessToken.access_token, code);
                ViewData["ByBase"] = true;
                ViewData["UserId"] = userInfo.UserId;
                ViewData["DeviceId"] = userInfo.DeviceId;
                string NickName = MailListApi.GetMember(accessToken.access_token, userInfo.UserId).name;
                Session["NickName"] = NickName;
            }
            catch (ErrorJsonResultException ex)
            {
                //未关注，只能授权，无法得到详细信息
                //这里的 ex.JsonResult 可能为："{\"errcode\":40003,\"errmsg\":\"invalid openid\"}"
                return Content("用户已授权，授权Token：" + accessToken.access_token + "ex:" + ex.Message);
            }
            #endregion
            #region 
            //获取时间戳
            var timestamp = Senparc.Weixin.QY.Helpers.JSSDKHelper.GetTimestamp();
            //获取随机码
            var nonceStr = Senparc.Weixin.QY.Helpers.JSSDKHelper.GetNoncestr();
            string ticket = JsApiTicketContainer.TryGetTicket(CorpId, CorpSecret, false);
            //获取签名
            var signature = Senparc.Weixin.QY.Helpers.JSSDKHelper.GetSignature(ticket, nonceStr, timestamp, Request.Url.AbsoluteUri);
            #endregion            
            var jssdkUiPackage = new Senparc.Weixin.QY.Helpers.JsSdkUiPackage(CorpId, timestamp.ToString(), nonceStr, signature);
            return View(jssdkUiPackage);

        }
        [HttpPost]
        public ActionResult QueryCode(string barCode)
        {
            QueryFromWebService qf = new QueryFromWebService();
            string NickName = "未知用户";
            if (Session["NickName"] != null)
            {
                NickName = Session["NickName"].ToString();
            }
            string queryresult = qf.QueryContractFromFangHu(barCode, NickName);
            string result = NickName + "您好！\r\n查询结果：" + queryresult;
            return Json(result);
        }
    }
}