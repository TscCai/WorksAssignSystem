﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorksAssign.Persistence
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DeviceEntities : DbContext
    {
        public DeviceEntities()
            : base("name=DeviceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bay> Bay { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<MaintenanceRecord> MaintenanceRecord { get; set; }
        public virtual DbSet<Substation> Substation { get; set; }
        public virtual DbSet<Vx_AllDevice> Vx_AllDevice { get; set; }
        public virtual DbSet<Vx_AllRecord> Vx_AllRecord { get; set; }
    }
}