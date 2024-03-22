using System;
using System.Collections.Generic;

namespace famiCCV1.Server.Models
{
    public partial class Representative
    {
        public Representative()
        {
            Proponents = new HashSet<Proponent>();
        }

        public int Id { get; set; }
        public string? Email { get; set; }
        public string? NumDocument { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public int? FkTdocumentId { get; set; }

        public virtual DocumentType? FkTdocument { get; set; }
        public virtual ICollection<Proponent> Proponents { get; set; }
    }
}
