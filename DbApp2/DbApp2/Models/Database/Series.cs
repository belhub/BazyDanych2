using System;
using System.Collections.Generic;

namespace DbApp2.Models.Database
{
    public partial class Series
    {
        public Series()
        {
            Products = new HashSet<Product>();
        }

        public string Name { get; set; } = null!;
        public int? Code { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
