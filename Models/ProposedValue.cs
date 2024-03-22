using System;
using System.Collections.Generic;

namespace famiCCV1.Server.Models
{
    public partial class ProposedValue
    {
        public ProposedValue()
        {
            Proposeds = new HashSet<Proposed>();
        }

        public int Id { get; set; }
        public decimal? ContributionConfama { get; set; }
        public decimal? TotalAmount { get; set; }

        public virtual ICollection<Proposed> Proposeds { get; set; }
    }
}
