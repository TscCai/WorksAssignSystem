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
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=WorksAssignEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DayOff> DayOff { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<ExWorkdays> ExWorkdays { get; set; }
        public virtual DbSet<MaintenceRecord> MaintenceRecord { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Substations> Substations { get; set; }
        public virtual DbSet<WorkBonus> WorkBonus { get; set; }
        public virtual DbSet<WorkContent> WorkContent { get; set; }
        public virtual DbSet<WorkInvolve> WorkInvolve { get; set; }
        public virtual DbSet<WorkType> WorkType { get; set; }
        public virtual DbSet<V_AllPoints> V_AllPoints { get; set; }
    }
}
