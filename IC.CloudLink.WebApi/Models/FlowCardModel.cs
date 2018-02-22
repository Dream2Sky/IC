namespace IC.CloudLink.WebApi.Models
{
    public class FlowCardModel
    {
        /// <summary>
        /// 用户openId
        /// </summary>
        /// <returns></returns>
        public string OpenId { get; set; }
        
        /// <summary>
        /// 卡号
        /// </summary>
        public string ICCId { get; set; }

        /// <summary>
        /// 总流量
        /// </summary>
        public decimal TotalFlow { get; set; }

        /// <summary>
        /// 已使用流量
        /// </summary>
        public decimal UsagedFlow { get; set; }
    }
}