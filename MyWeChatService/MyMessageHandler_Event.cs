using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.MP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyWeChatService
{
    public partial class MyMessageHandler
    {
        private string GetWelcomeInfo()
        {
            string WelcomeStr = @"欢迎关注王凯的微信公众平台测试账号！
                                在此账号下，你可以发送文字消息、图片、
                                语音、当前位置等信息查看不用格式的回复。
                                您也可以点击下方的菜单栏按钮使用微信扫一扫";
            return WelcomeStr;
        }
        /// <summary>
        /// 订阅、关注事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_SubscribeRequest(RequestMessageEvent_Subscribe requestMessage)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            responseMessage.Content = GetWelcomeInfo();
            return responseMessage;
        }
        /// <summary>
        /// 退订、不再关注事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_UnsubscribeRequest(RequestMessageEvent_Unsubscribe requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "我们下次会做的更好！";
            return responseMessage;
        }
        /// <summary>
        /// 文字或事件类型请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnTextOrEventRequest(RequestMessageText requestMessage)
        {
            if (requestMessage.Content == "OneClick")
            {
                var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                strongResponseMessage.Content = "来自开发者的消息：您点击了底部菜单按钮！";
                return strongResponseMessage;
            }
            return null;//返回null，则继续执行OnTextRequest或OnEventRequest
        }
        /// <summary>
        /// 事件请求（Click）
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_ClickRequest(RequestMessageEvent_Click requestMessage)
        {
            IResponseMessageBase reponseMessage = null;
            //菜单点击，需要跟创建菜单时的Key匹配
            switch (requestMessage.EventKey)
            {
                case "OneClick":
                    {
                        //这个过程实际已经在OnTextOrEventRequest中完成，这里不会执行到。
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = "来自开发者的消息：您点击了底部菜单按钮！";
                    }
                    break;
                case "FANGHU":
                    {
                        string pwd = "jwysoft20122012,";
                        string msg = requestMessage.ConvertToRequestMessageText().Content;
                        WebReference.Service1 method = new WebReference.Service1();
                        string result = method.QueryContract(pwd, msg);
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = result;
                    }
                    break;
                case "SubClickRoot_Text":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = "来自开发者的消息：您点击了子菜单按钮！";
                    }
                    break;
                case "SubClickRoot_News":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageNews>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Articles.Add(new Article()
                        {
                            Title = "来自开发者的消息：您点击了子菜单按钮！",
                            Description = "这是一条图文信息。",
                            PicUrl = "http://1p623v6690.iok.la/Images/1.jpg",
                            Url = "http://1p623v6690.iok.la/Home"
                        });
                    }
                    break;
                //case "SubClickRoot_Music":
                //    {
                //        //上传缩略图
                //        var accessToken = Containers.AccessTokenContainer.TryGetAccessToken(appId, appSecret);
                //        var uploadResult = AdvancedAPIs.MediaApi.UploadTemporaryMedia(accessToken, UploadMediaFileType.thumb,
                //                                                     Server.GetMapPath("~/Images/Logo.jpg"));
                //        //设置音乐信息
                //        var strongResponseMessage = CreateResponseMessage<ResponseMessageMusic>();
                //        reponseMessage = strongResponseMessage;
                //        strongResponseMessage.Music.Title = "天籁之音";
                //        strongResponseMessage.Music.Description = "真的是天籁之音";
                //        strongResponseMessage.Music.MusicUrl = "http://sdk.weixin.senparc.com/Content/music1.mp3";
                //        strongResponseMessage.Music.HQMusicUrl = "http://sdk.weixin.senparc.com/Content/music1.mp3";
                //        strongResponseMessage.Music.ThumbMediaId = uploadResult.thumb_media_id;
                //    }
                //    break;
                //case "SubClickRoot_Image":
                //    {
                //        //上传图片
                //        var accessToken = Containers.AccessTokenContainer.TryGetAccessToken(appId, appSecret);
                //        var uploadResult = AdvancedAPIs.MediaApi.UploadTemporaryMedia(accessToken, UploadMediaFileType.image,
                //                                                     Server.GetMapPath("~/Images/Logo.jpg"));
                //        //设置图片信息
                //        var strongResponseMessage = CreateResponseMessage<ResponseMessageImage>();
                //        reponseMessage = strongResponseMessage;
                //        strongResponseMessage.Image.MediaId = uploadResult.media_id;
                //    }
                //    break;
                case "SubClickRoot_PicPhotoOrAlbum":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = "您点击了【微信拍照】按钮。系统将会弹出拍照或者相册发图。";
                    }
                    break;
                case "Description":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        strongResponseMessage.Content = GetWelcomeInfo();
                        reponseMessage = strongResponseMessage;
                    }
                    break;
                case "SubClickRoot_ScancodePush":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = "您点击了【微信扫码】按钮。";
                    }
                    break;
                default:
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        strongResponseMessage.Content = "您点击了按钮，EventKey：" + requestMessage.EventKey;
                        reponseMessage = strongResponseMessage;
                    }
                    break;
            }

            return reponseMessage;
        }
        /// <summary>
        /// 扫码推事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_ScancodePushRequest(RequestMessageEvent_Scancode_Push requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "您刚才扫描了二维码，并且要向您推送一条消息";
            return responseMessage;
        }
        /// <summary>
        /// 扫码推事件，并且弹出“消息获取中”提示框
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_ScancodeWaitmsgRequest(RequestMessageEvent_Scancode_Waitmsg requestMessage)
        {
            string AppId = "wx739b4a998d710f0b";//与微信公众账号后台的AppId设置保持一致，区分大小写。
            string AppSecret = "96c92d012934a873820d97084c18d93d";
            string pwd = "jwysoft20122012,";
            string msg = requestMessage.ScanCodeInfo.ScanResult;
            WebReference.Service1 method = new WebReference.Service1();
            string result = method.QueryContract(pwd, msg);
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            var accessToken = AccessTokenContainer.TryGetAccessToken(AppId, AppSecret);
            string UserName = UserApi.Info(accessToken, responseMessage.ToUserName).nickname;
            responseMessage.Content = "您好" + UserName + "\r\n查询结果是：\r\n" + result;
            return responseMessage;
        }
    }
}
