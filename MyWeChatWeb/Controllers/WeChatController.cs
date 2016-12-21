using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.MvcExtension;
using MyWeChatService;
using Senparc.Weixin.MP.Entities.Menu;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.MP.CommonAPIs;

namespace MyWeChatWeb.Controllers
{
    public class WeChatController : Controller
    {
        public static readonly string Token = "MyWeChat";//与微信公众账号后台的Token设置保持一致，区分大小写。
        public static readonly string EncodingAESKey = "0ArtEUtQDYSVTudCqg1mSt61pqdJPHOG4csPWYZUTCB ";//与微信公众账号后台的EncodingAESKey设置保持一致，区分大小写。
        public static readonly string AppId = "wx739b4a998d710f0b";//与微信公众账号后台的AppId设置保持一致，区分大小写。
        public static readonly string AppSecret = "96c92d012934a873820d97084c18d93d";
        /// <summary>
        /// 微信后台验证的地址
        /// </summary>
        /// <param name="postModel">多个参数组成的Model（Signature:身份密钥,Timestamp:时间戳,Nonce:随机字符串）</param>
        /// <param name="echostr">返回的随机字符串</param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Index")]
        // GET: WeChat
        public ActionResult Get(PostModel postModel, string echostr)
        {
            var accessToken = AccessTokenContainer.TryGetAccessToken(AppId, AppSecret);
            ButtonGroup bg = new ButtonGroup();
            //单击
            bg.button.Add(new SingleClickButton()
            {
                type = "scancode_waitmsg",
                name = "扫防护码",
                key = "FANGHU",
            });
            bg.button.Add(new SingleClickButton()
            {
                type = "scancode_push",
                name = "扫防化码",
                key = "OneClick",
            });
            bg.button.Add(new SingleViewButton()
            {
                url = "http://1p623v6690.iok.la/Home",
                name = "离线存储"
            });
            var result = CommonApi.CreateMenu(accessToken, bg);
            if (CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, Token))
            {
                return Content(echostr);
            }
            else
            {
                return Content("连接失败！");
            }
        }
        [HttpPost]
        [ActionName("Index")]
        public ActionResult Post(PostModel postModel)
        {
            if (CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, Token))
            {
                postModel.Token = Token;//根据自己后台的设置保持一致
                postModel.EncodingAESKey = EncodingAESKey;//根据自己后台的设置保持一致
                postModel.AppId = AppId;//根据自己后台的设置保持一致

                //自定义MyMessageHandler，对微信请求的详细判断操作都在这里面。
                var messageHandler = new MyMessageHandler(Request.InputStream, postModel);//接收消息
                messageHandler.Execute();//执行微信处理过程
                return new FixWeixinBugWeixinResult(messageHandler);//返回结果
            }
            else
            {
                return Content("参数错误！");
            }
        }
    }
}