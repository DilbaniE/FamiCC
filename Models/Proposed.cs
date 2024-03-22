using System;
using System.Collections.Generic;

namespace famiCCV1.Server.Models
{
    public partial class Proposed
    {
        public Proposed()
        {
            ProponentDocuments = new HashSet<ProponentDocument>();
        }

        public int Id { get; set; }
        public string? DescriptionActivities { get; set; }
        public string? DescripcionProposed { get; set; }
        public string? AlliedCompany { get; set; }
        public string? ProposedState { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? PresentationDate { get; set; }
        public string? NameProponen { get; set; }
        public string? BenefitedPublic { get; set; }
        public int? FkProponentId { get; set; }
        public int? FkProposedvalueId { get; set; }

        public virtual Proponent? FkProponent { get; set; }
        public virtual ProposedValue? FkProposedvalue { get; set; }
        public virtual ICollection<ProponentDocument> ProponentDocuments { get; set; }
    }
}
