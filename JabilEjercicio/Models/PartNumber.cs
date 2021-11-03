using System;
using System.Collections.Generic;

#nullable disable

namespace JabilEjercicio.Models
{
    public partial class PartNumber
    {
        public int PkpartNumber { get; set; }
        public string PartNumber1 { get; set; }
        public bool Available { get; set; }
        public int? Fkcustomer { get; set; }

        public virtual Customer FkcustomerNavigation { get; set; }
    }
}
