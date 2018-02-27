using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace IC.Core.Entity
{
    public static class Enum
    {
        public enum HTTP_SUCCESS
        {
            SUCCESS,
            FAIL
        }

        public enum BIZSTATUS
        {
            [Description("获取数据失败")]
            ERROR = -1,

            [Description("获取数据成功")]
            SUCCESS = 100,

            [Description("获取数据成功, 但数据为空")]
            DATAEMPTY = 101,

            [Description("访问超时，请重新访问应用")]
            TIMEOUT = 201,

            [Description("该账号未注册成为会员")]
            NOREGISTER = 202,
            
            [Description("不合法的OpenId")]
            INVALIDOPENID = 203,

            [Description("手机验证码不合法")]
            INVALIDCODE = 204,

            [Description("未获取到任何流量卡信息")]
            NOCARDS = 301,

            [Description("非法的ICCID号")]
            INVALIDICCID = 302
        }

        /// <summary>
        /// 期间
        /// </summary>
        public enum PERID
        {
            /// <summary>
            /// 月
            /// </summary>
            MONTH = 1,

            /// <summary>
            /// 季
            /// </summary>
            QUARTER = 3,

            /// <summary>
            /// 半年
            /// </summary>
            HALFYEAR = 6,

            /// <summary>
            /// 年
            /// </summary>
            YEAR = 12
        }
    }
}
