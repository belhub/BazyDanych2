using System;
using System.Collections.Generic;

namespace DbApp2.Models.Database
{
    public partial class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public double? Price { get; set; }
        public string? Series { get; set; }
        public string? Place { get; set; }

        public virtual Series? NameNavigation { get; set; }
        public virtual Section? PlaceNavigation { get; set; }
    }
}
