using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Core.Entity.CloudLink.DB
{
    public class CloudLinkDBContext : DbContext
    {
        public CloudLinkDBContext(DbContextOptions<CloudLinkDBContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<FlowCard> FlowCards { get; set; }
        public DbSet<FlowPackage> FlowPackages { get; set; }
        public DbSet<FlowPackageRecord> FlowPackageRecords { get; set; }
        public DbSet<ReChargeRecord> ReChargeRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
