using System;
using System.Collections.Generic;

namespace DbApp2.Models.Database
{
    public partial class Manager
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public double? Salary { get; set; }




        public string NameManager
        {
            get
            {
                return this.LastName +"---"+this.FirstName+"---"+this.Id.ToString();
            }
        }
    }
}
