using IC.Core.Entity.CloudLink.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace IC.CloudLink.Services.Contracts
{
    public interface IDBService
    {
        #region Users
        IEnumerable<User> GetUserByOpenId(string openId);
        bool IsRegister(string openId);
        bool IsExistedUser(string openId, ref User user);
        void Register(string phone, string openId);
        bool ReCharge(string openId, decimal amount);
        void AddReChargeRecord(User user, decimal amount);
        #endregion

        #region FlowCards
        FlowCard GetFlowCard(string iccId);
        IEnumerable<FlowCard> GetFlowCards(string openId, bool isDel = false);
        bool IsExistedFlowCard(string iccId);
        bool AddFlowCards(string openId, string iccId);

        #endregion

        #region FlowCardPackage
        bool IsExistedFlowPackage(string flowPackageId);
        bool BuyFlowPackage(string iccId, string flowPackageId);
        FlowPackage GetFlowPackage(string flowPackageId);
        #endregion
    }
}
