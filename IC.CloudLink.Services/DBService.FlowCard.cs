using IC.CloudLink.Services.Contracts;
using IC.Core.Entity.CloudLink.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IC.CloudLink.Services
{
    public partial class DBService
    {
        /// <summary>
        /// 获取用户流量卡集合
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public FlowCard GetFlowCard(string iccId)
        {
            return cloudLinkDBContext.FlowCards.SingleOrDefault(n => n.ICCId == iccId);
        }

        /// <summary>
        /// 返回指定openid的用户绑定的流量卡
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public IEnumerable<FlowCard> GetFlowCards(string openId, bool isDel = false)
        {
            var users = GetUserByOpenId(openId);
            return users.FirstOrDefault().FlowCards.Where(n=>n.IsDel == isDel);
        }

        /// <summary>
        /// 判断是否已经存在iccid
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="iccId"></param>
        /// <returns></returns>
        public bool IsExistedFlowCard(string iccId)
        {
            var cards = GetFlowCard(iccId);
            if (cards == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 添加新卡
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="iccId"></param>
        /// <returns></returns>
        public bool AddFlowCards(string openId, string iccId)
        {
            var users = GetUserByOpenId(openId);
            if (users != null && users.Count() > 0)
            {
                FlowCard flowCard = new FlowCard()
                {
                    ICCId = iccId,
                    OpenId = openId,
                    TotalFlow = 1024,
                    UsagedFlow = 0
                };
                users.First().FlowCards.Add(flowCard);
                cloudLinkDBContext.SaveChanges();

                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断套餐是否存在
        /// </summary>
        /// <param name="flowPackageId"></param>
        /// <returns></returns>
        public bool IsExistedFlowPackage(string flowPackageId)
        {
            var flowPackages = cloudLinkDBContext.FlowPackages.Where(n => n.Id == flowPackageId);

            if (flowPackages == null && flowPackages.Count() <= 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 删除流量套餐
        /// </summary>
        /// <param name="iccId"></param>
        /// <param name="flowPackageId"></param>
        /// <returns></returns>
        public bool DelFlowPackage(string iccId, string flowPackageId)
        {
            var flowPackageRecord = cloudLinkDBContext.FlowPackageRecords
            .Where(n=>n.Id == flowPackageId && n.CardId == iccId && n.IsDel == false).FirstOrDefault();
            if(flowPackageRecord!= null)
            {
                flowPackageRecord.IsDel = true;
                cloudLinkDBContext.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 购买流量卡
        /// </summary>
        /// <param name="iccId"></param>
        /// <param name="flowPackageId"></param>
        /// <returns></returns>
        public bool BuyFlowPackage(string iccId, string flowPackageId)
        {
            var flowPackage = GetFlowPackage(flowPackageId);
            
            if (flowPackage != null)
            {
                FlowPackageRecord flowPackageRecord = new FlowPackageRecord()
                {
                    CardId = iccId,
                    ExpiryDate = DateTime.Now.AddMonths((int)flowPackage.Type),
                    PackageId = flowPackageId
                };
                var flowCard = cloudLinkDBContext.FlowCards.Include(n => n.FlowPackageRecords).FirstOrDefault(n => n.ICCId == iccId);
                flowCard.FlowPackageRecords.Add(flowPackageRecord);
                cloudLinkDBContext.SaveChanges();

                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取流量卡套餐
        /// </summary>
        /// <param name="flowPackageId"></param>
        /// <returns></returns>
        public FlowPackage GetFlowPackage(string flowPackageId)
        {
            return cloudLinkDBContext.FlowPackages.SingleOrDefault(n => n.Id == flowPackageId);
        }
    }
}
