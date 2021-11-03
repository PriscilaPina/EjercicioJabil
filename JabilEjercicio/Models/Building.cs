using System;
using System.Collections.Generic;

#nullable disable

namespace JabilEjercicio.Models
{
    public partial class Building
    {
        public Building()
        {
            Customers = new HashSet<Customer>();
        }

        public int Pkbuilding { get; set; }
        public string Building1 { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
