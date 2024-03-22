using System;
using System.Collections.Generic;

namespace famiCCV1.Server.Models
{
    public partial class ProponentDocument
    {
        public int Id { get; set; }
        public int? FkAdjuntdocumentId { get; set; }
        public int? FkProposedId { get; set; }

        public virtual AdjuntDocument? FkAdjuntdocument { get; set; }
        public virtual Proposed? FkProposed { get; set; }
    }
}
