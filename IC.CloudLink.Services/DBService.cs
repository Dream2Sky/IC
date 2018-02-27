﻿using IC.CloudLink.Services.Contracts;
using IC.Core.Entity.CloudLink.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IC.CloudLink.Services
{
    public partial class DBService : IDBService
    {
        protected CloudLinkDBContext cloudLinkDBContext;
        public DBService(CloudLinkDBContext _cloudLinkDBContext)
        {
            this.cloudLinkDBContext = _cloudLinkDBContext;
        }

    }
}
