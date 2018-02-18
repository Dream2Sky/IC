using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Core.Entity.Http
{
    public class HttpResult<T>
    {
        /// <summary>
        /// 请求成功与否
        /// </summary>
        public string Success { get; set; }

        /// <summary>
        /// 请求结果返回代码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 请求数据
        /// </summary>
        public T Data { get; set; }
    }
}
