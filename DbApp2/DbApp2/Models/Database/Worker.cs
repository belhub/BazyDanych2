using System;
using System.Collections.Generic;

namespace DbApp2.Models.Database
{
    public partial class Worker
    {
        public Worker()
        {
            Sections = new HashSet<Section>();
        }

        public int Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public double? Salary { get; set; }
        public int? ManagerId { get; set; }

        public virtual ICollection<Section> Sections { get; set; }
    }
}
