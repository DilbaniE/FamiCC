using System;
using System.Collections.Generic;

namespace famiCCV1.Server.Models
{
    public partial class ProponentType
    {
        public ProponentType()
        {
            Proponents = new HashSet<Proponent>();
        }

        public int Id { get; set; }
        public string? ProponentType1 { get; set; }

        public virtual ICollection<Proponent> Proponents { get; set; }
    }
}
