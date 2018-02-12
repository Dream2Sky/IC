using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using IC.CloudLink.Services.Contracts;
using IC.Core.Entity.CloudLink.SMS;
using System;
using System.Collections.Generic;
using System.Text;

namespace IC.CloudLink.Services
{
    public class SMSService : ISMSService
    {
        public IAcsClient InitAcsClient(SMSContext smsContext)
        {
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", smsContext.AccessKeyId, smsContext.AccessKeySecret);
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", smsContext.Product, smsContext.Domain);
            IAcsClient acsClient = new DefaultAcsClient(profile);
            return acsClient;
        }

        public SendSmsRequest InitSmsRequest(SMSContext smsContext, string phone, string data)
        {
            SendSmsRequest request = new SendSmsRequest();

            request.PhoneNumbers = phone;
            //必填:短信签名-可在短信控制台中找到
            request.SignName = smsContext.SignName;
            //必填:短信模板-可在短信控制台中找到
            request.TemplateCode = smsContext.TemplateCode;
            //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
            //"{\"name\":\"Tom\"， \"code\":\"123\"}";
            request.TemplateParam = data;

            return request;
        }

        public SendSmsResponse SentMsg(IAcsClient acsClient, SendSmsRequest request)
        {
            SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);
            
            return sendSmsResponse;
        }
    }
}
