﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorksAssign.Util.Adapter
{
    public class WorkAbstractDataRow
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Substation { get; set; }
        public string Location { get; set; }
        public string WorkType { get; set; }
        public string Content { get; set; }
        public string Leader { get; set; }
        public string Member { get; set; }
        public string Manager { get; set; }
        public string ExMember { get; set; }
    }
}
