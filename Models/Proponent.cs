using System;
using System.Collections.Generic;

namespace famiCCV1.Server.Models
{
    public partial class Proponent
    {
        public Proponent()
        {
            Proposeds = new HashSet<Proposed>();
        }

        public int Id { get; set; }
        public string? NProponent { get; set; }
        public string? Trajectory { get; set; }
        public int? FkRepresentativeId { get; set; }
        public int? FkTproponentId { get; set; }

        public virtual Representative? FkRepresentative { get; set; }
        public virtual ProponentType? FkTproponent { get; set; }
        public virtual ICollection<Proposed> Proposeds { get; set; }
    }
}
