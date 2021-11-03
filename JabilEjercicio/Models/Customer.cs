using System;
using System.Collections.Generic;

#nullable disable

namespace JabilEjercicio.Models
{
    public partial class Customer
    {
        public Customer()
        {
            PartNumbers = new HashSet<PartNumber>();
        }

        public int Pkcustomer { get; set; }
        public string Customer1 { get; set; }
        public string Prefix { get; set; }
        public int? Fkbuilding { get; set; }

        public virtual Building FkbuildingNavigation { get; set; }
        public virtual ICollection<PartNumber> PartNumbers { get; set; }
    }
}
