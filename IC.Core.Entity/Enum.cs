using System;
using System.Collections.Generic;
using System.Text;

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
            ERROR = -1,
            SUCCESS = 100,
            DATAEMPTY = 101
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
