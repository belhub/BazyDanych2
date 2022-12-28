using System;
using System.Collections.Generic;

namespace DbApp2.Models.Database
{
    public partial class Section
    {
        public Section()
        {
            Products = new HashSet<Product>();
        }

        public string Name { get; set; } = null!;
        public int? ManagerId { get; set; }

        public virtual Worker? Manager { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
