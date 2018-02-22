using IC.Core.Entity.CloudLink.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IC.CloudLink.Extensions
{
    public static class DBContextExtensions
    {
        public static void EnsureSeedDataForContext(this CloudLinkDBContext dBContext)
        {
            if (dBContext.FlowCards.Any())
            {
                return;
            }
            else
            {
                var flowCards = new List<FlowCard>
                {
                    new FlowCard{
                         Id = Guid.NewGuid().ToString(),
                         CreateTime = DateTime.Now,
                         DelTime = DateTime.MinValue,
                         IsDel = false,
                         OpenId = "oy5Ik0rEnNKCHiulYdkIMyF7NFrA",
                         ICCId = "12345678923456789",
                         TotalFlow = 1024,
                         UpdateTime = DateTime.Now,
                         UsagedFlow = 100,
                         UserId = "5440a53d-13aa-4ff7-aee0-33b6433291c0"
                    }
                };

                dBContext.FlowCards.AddRange(flowCards);
                dBContext.SaveChangesAsync();
            }

        }
    }
}
