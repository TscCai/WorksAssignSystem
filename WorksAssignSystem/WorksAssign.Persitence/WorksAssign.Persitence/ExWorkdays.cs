//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class ExWorkdays
    {
        public long ID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<bool> IsHoliday { get; set; }
        public Nullable<bool> IsWorkday { get; set; }
        public string Comments { get; set; }
    }
}
