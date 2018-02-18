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

        public enum HTTP_STATUS_CODE
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
            NOREGISTER = 202
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
