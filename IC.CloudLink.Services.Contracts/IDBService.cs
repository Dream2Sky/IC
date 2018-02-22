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
        void Register(string phone, string openId);
        #endregion

        #region FlowCards
        IEnumerable<FlowCard> GetFlowCards(string openId);
        
        #endregion
    }
}
