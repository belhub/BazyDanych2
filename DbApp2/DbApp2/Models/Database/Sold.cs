using System;
using System.Collections.Generic;

namespace DbApp2.Models.Database
{
    public partial class Sold
    {
        public string? ProductName { get; set; }
        public int? Count { get; set; }
        public double? Value { get; set; }

        public virtual Series? ProductNameNavigation { get; set; }
    }
}
