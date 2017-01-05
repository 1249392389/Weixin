using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeChatService.QYService
{
    public class QueryFromWebService
    {
        #region 向webServicer提交查询请求
        //江西防护
        public string QueryContractFromFangHu(string contractNo, string userName)
        {
            ServiceReferenceFromJXFHu.Service1SoapClient svc = new ServiceReferenceFromJXFHu.Service1SoapClient();
            string result = "";
            result = svc.QueryContractLog("jwysoft20122012,", contractNo, userName);
            if (result.Contains("合同不存在") || result.Contains("非法查询请求"))//如果查询合同编号时没有得到结果
            {
                //看看是不是设备上的二维码
                result = svc.JXRFCheckLog(contractNo, userName);
                if (result.Contains("该身份号码不存在") || result.Contains("非法查询请求"))
                {
                    result = "该二维码编号在防护系统中不存在！如果是防化合同或设备上的二维码，请点击“扫防化码”扫描！";
                }
            }
            return result;
        }
       
        #endregion

    }
}
