using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Core.Entity.CloudLink.SMS
{
    public class SMSContext
    {
        /// <summary>
        /// 短信API产品名称（短信产品名固定，无需修改）
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// 短信API产品域名（接口地址固定，无需修改）
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// 短信区域Id（固定，无需修改）
        /// </summary>
        public string RegionId { get; set; }

        public string AccessKeyId { get; set; }
        public string AccessKeySecret { get; set; }

        /// <summary>
        /// 短信签名-可在短信控制台中找到
        /// </summary>
        public string SignName { get; set; }

        /// <summary>
        /// 短信模板-可在短信控制台中找到
        /// </summary>
        public string TemplateCode { get; set; }
    }
}
