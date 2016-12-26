using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.GoogleMap;
using Senparc.Weixin.MP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeChatService
{
    public class LocaltionService
    {
        public ResponseMessageNews GetResponseMessage(RequestMessageLocation requestMessage)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageNews>(requestMessage);
            var markerList = new List<GoogleMapMarkers>();
            markerList.Add(new GoogleMapMarkers()
            {
                X = requestMessage.Location_X,
                Y = requestMessage.Location_Y,
                Color = "red",
                Label = "s",
                Size = GoogleMapMarkerSize.Default,
            });
            var mapSize = "480x600";
            var mapUrl = GoogleMapHelper.GetGoogleStaticMap(19, markerList, mapSize);
            responseMessage.Articles.Add(new Article()
            {
                Description = string.Format("你的地理位置处于：Localtion_X:{0}，Location_Y：{1}，Scale：{2}，标签：{3}",
                              requestMessage.Location_X, requestMessage.Location_Y,
                              requestMessage.Scale, requestMessage.Label),
                PicUrl = "http://1p623v6690.iok.la/2.jpg",
                Url = "http://baidu.com"
            });
            return responseMessage;
        }
    }
}
