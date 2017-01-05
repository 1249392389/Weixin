using Senparc.Weixin.HttpUtility;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.QY.AdvancedAPIs;
using Senparc.Weixin.QY.CommonAPIs;
using Senparc.Weixin.QY.Containers;
using Senparc.Weixin.QY.Entities;
using Senparc.Weixin.QY.MessageHandlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeChatService.QYService
{
    public class QyCustomMessageHandler : QyMessageHandler<QyCustomMessageContext>
    {
        public QyCustomMessageHandler(Stream inputStream, PostModel postModel, int maxRecordCount = 0)
            : base(inputStream, postModel, maxRecordCount)
        {

        }
        public static readonly string CorpId = "wxe8074ed784fc094b";                                //与微信企业账号后台的EncodingAESKey设置保持一致，区分大小写。
        public static readonly string CorpSecret = "3mMigRYCXzg_sjvtyVTnJR6XW7b_TklxpPANz-jl6bEosHEuLLczPcJ8lHg5uTZN";
        private string GetWelcomeInfo()
        {
            string WelcomeStr = "欢迎关注天津市微派科技发展有限公司企业号！\r\n在此应用下，您可以扫描合同或设备上的二维码，验证备案信息、识别假冒设备、识别设备所在工程位置等信息";
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
        /// 扫码推事件（显示消息接受中）
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_ScancodeWaitmsgRequest(RequestMessageEvent_Scancode_Waitmsg requestMessage)
        {
            QueryFromWebService qf = new QueryFromWebService();
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            string barCode = requestMessage.ScanCodeInfo.ScanResult;
            string eventKey = requestMessage.EventKey;
            string result = "";
            switch (eventKey)
            {
                case "saoFangHu":
                    {
                        result = qf.QueryContractFromFangHu(barCode, requestMessage.FromUserName);

                    }
                    break;
            }
            //var accessToken = AccessTokenContainer.TryGetToken(CorpId, CorpSecret);
            //string UserName = UserApi.Info(accessToken, responseMessage.ToUserName).nickname;
            responseMessage.Content = responseMessage.ToUserName + "您好！\r\n查询结果是：\r\n" + result;
            return responseMessage;
        }
        /// <summary>
        /// 扫码推事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_ScancodePushRequest(RequestMessageEvent_Scancode_Push requestMessage)
        {
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "您的扫描结果是：" + requestMessage.ScanCodeInfo.ScanResult + ";您的微信号是：" + requestMessage.FromUserName;
            return responseMessage;
        }
        /// <summary>
        /// 文本消息接收事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            if (requestMessage.Content.ToLower().StartsWith("xlh"))//判断用户输入的内容初始是否含有xlh字段
            {
                string barCode = requestMessage.Content.Substring(3);//截取用户输入的文本内容
                string result = "设备A\r\n信息：AAAAAAAAAAAAAAAAAAAAA";
                //QueryFromWebService qf = new QueryFromWebService();//调用WebService获取查询内容
                //result = qf.QueryContractFromFangHu(barCode, requestMessage.FromUserName);
                responseMessage.Content = responseMessage.ToUserName + "您好！\r\n查询结果是：\r\n" + result;
            }
            else
            {
                var accessToken = AccessTokenContainer.TryGetToken(CorpId, CorpSecret);
                string NickName = MailListApi.GetMember(accessToken, responseMessage.ToUserName).name;
                responseMessage.Content = NickName + ",您发送了消息：" + requestMessage.Content + "您的微信号是：" + requestMessage.FromUserName;
            }
            return responseMessage;
        }
        /// <summary>
        /// 图片接收事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnImageRequest(RequestMessageImage requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageImage>();
            responseMessage.Image.MediaId = requestMessage.MediaId;
            return responseMessage;
        }
        /// <summary>
        /// 发送图片事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_PicPhotoOrAlbumRequest(RequestMessageEvent_Pic_Photo_Or_Album requestMessage)
        {
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "您刚发送的图片如下：";
            return responseMessage;
        }
        /// <summary>
        /// 发送位置事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_LocationRequest(RequestMessageEvent_Location requestMessage)
        {
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = string.Format("位置坐标 {0} - {1}", requestMessage.Latitude, requestMessage.Longitude);
            return responseMessage;
        }
        /// <summary>
        /// 默认消息回复
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override Senparc.Weixin.QY.Entities.IResponseMessageBase DefaultResponseMessage(Senparc.Weixin.QY.Entities.IRequestMessageBase requestMessage)
        {
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "这是一条没有找到合适回复信息的默认消息。";
            return responseMessage;
        }
        public override IResponseMessageBase OnEvent_ClickRequest(RequestMessageEvent_Click requestMessage)
        {
            IResponseMessageBase reponseMessage = null;
            switch (requestMessage.EventKey)
            {
                case "QuerySerialNumber":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        strongResponseMessage.Content = "提示：\r\n若想要查询序列号，请输入“XLH”+您想要查询的序列号即可。\r\n如：输入“XLH0000000”即可查询序列号为“0000000”的设备";
                        reponseMessage = strongResponseMessage;
                    }
                    break;
            }
            return reponseMessage;
        }
    }
}
