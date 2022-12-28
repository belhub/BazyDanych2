using System;
using System.Collections.Generic;

namespace DbApp2.Models.Database
{
    public partial class Reservation
    {
        public int? Id { get; set; }
        public string? LastName { get; set; }
        public int? ProductId { get; set; }
        public int? Amount { get; set; }
        public double? Price { get; set; }
        public DateTime? ReceptionDate { get; set; }
        public string? Status { get; set; }

        public virtual Product? Product { get; set; }
    }
}
