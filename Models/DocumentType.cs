using System;
using System.Collections.Generic;

namespace famiCCV1.Server.Models
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Representatives = new HashSet<Representative>();
        }

        public int Id { get; set; }
        public string? DocumentType1 { get; set; }

        public virtual ICollection<Representative> Representatives { get; set; }
    }
}
