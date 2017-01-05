using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.MessageHandlers;
using System.IO;
using Senparc.Weixin.Context;
using Senparc.Weixin.MP.Entities.Request;
using System.Web.Configuration;

namespace MyWeChatService
{
    /// <summary>
    /// 自定义MessageHandler
    /// 将MessageHandler作为基类，重写其方法
    /// </summary>
    public partial class MyMessageHandler : MessageHandler<MyMessageContext>
    {
        public MyMessageHandler(Stream inputStream, PostModel postModel)
            : base(inputStream)
        {

        }
        /// <summary>
        /// 处理默认请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "您的OpenID为：" + requestMessage.FromUserName +
                                    "。\r\n发送时间为：" + requestMessage.CreateTime +
                                    "。\r\n来自开发者的消息：这条消息为默认消息处理！";
            return responseMessage;
        }
        /// <summary>
        /// 处理文字请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            if (requestMessage.Content.ToLower().Contains("xlh"))
            {
                //QueryFromWebService qf = new QueryFromWebService();
                string barCode = requestMessage.Content.Substring(3);//截取用户输入的文本内容
                string result = "AAAA";
                //result = qf.QueryContractFromFangHu(barCode, requestMessage.FromUserName);
                responseMessage.Content = requestMessage.FromUserName + "您好！\r\n查询结果是：\r\n" + result;
            }
            else
            {
                //var responseMessage = CreateResponseMessage<ResponseMessageText>();
                responseMessage.Content = "您的OpenID为：" + requestMessage.FromUserName +
                                        "。\r\n发送时间为：" + requestMessage.CreateTime +
                                        "。\r\n来自开发者的消息：您发送的是文字消息！";
            }
            return responseMessage;
        }
        /// <summary>
        /// 处理语音请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnVoiceRequest(RequestMessageVoice requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "您的OpenID为：" + requestMessage.FromUserName +
                                    "。\r\n发送时间为：" + requestMessage.CreateTime +
                                    "。\r\n来自开发者的消息：您发送的是语音消息！";
            return responseMessage;
        }
        /// <summary>
        /// 统一处理事件请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEventRequest(IRequestMessageEventBase requestMessage)
        {
            var eventResponseMessage = base.OnEventRequest(requestMessage);//对于Event下属分类的重写方法，见：CustomerMessageHandler_Events.cs
            //TODO: 对Event信息进行统一操作
            return eventResponseMessage;
        }
        public override void OnExecuting()
        {
            if (RequestMessage.FromUserName == "gh_db10832e40be")
            {
                CancelExcute = true;//终止此用户对话
                var responseMessage = CreateResponseMessage<ResponseMessageText>();
                responseMessage.Content = "我给你讲，你已经被长者拉黑了！";
                ResponseMessage = responseMessage;
            }
        }

    }
}
