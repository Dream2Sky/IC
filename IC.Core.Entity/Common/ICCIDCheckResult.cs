using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Core.Entity.Common
{
    public class ICCIDCheckResult
    {
        /// <summary>
        /// state == 200 时表示合法
        /// </summary>
        public int State { get; set; }
        public string Company { get; set; }
        public string Number { get; set; }
        public string Area { get; set; }
        public string Year { get; set; }
        public string Factory { get; set; }
        public string ICCID { get; set; }
        public string M { get; set; }

    }
}
