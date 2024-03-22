using System;
using System.Collections.Generic;

namespace famiCCV1.Server.Models
{
    public partial class AdjuntDocument
    {
        public AdjuntDocument()
        {
            ProponentDocuments = new HashSet<ProponentDocument>();
        }

        public int Id { get; set; }
        public string? Urls { get; set; }
        public string? NameDocument { get; set; }

        public virtual ICollection<ProponentDocument> ProponentDocuments { get; set; }
    }
}
