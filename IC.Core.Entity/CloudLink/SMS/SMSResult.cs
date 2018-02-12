using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Core.Entity.CloudLink.SMS
{
    public class SMSResult
    {
        /// <summary>
        /// 请求ID
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// 状态码-返回OK代表请求成功,其他错误码详见错误码列表
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 状态码的描述
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 发送回执ID,可根据该ID查询具体的发送状态
        /// </summary>
        public string BizId { get; set; }
    }
}
