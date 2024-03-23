using famiCCV1.Server.ViewModels.ViewModelDetails;

namespace famiCCV1.Server.ViewModels
//namespace famiCCV1.Server.ViewModels.ViewModelsDetails
{
    //public class ProposedViewModelDetail
    //{
    //    public int Id { get; set; }
    //    public string DescriptionActivities { get; set; }
    //    public string DescripcionProposed { get; set; }
    //    public string AlliedCompany { get; set; }
    //    public string ProposedState { get; set; }
    //    public DateTime? DateStart { get; set; }
    //    public DateTime? PresentationDate { get; set; }
    //    public string NameProponen { get; set; }
    //    public string BenefitedPublic { get; set; }
    //    public int FkProponentId { get; set; }
    //    public int FkProposedvalueId { get; set; }

    //    public ProponentViewModelDetail Proponent { get; set; }
    //    public ProposedValueViewModel ProposedValue { get; set; }
    //    public List<ProponentDocumentViewModel> ProponentDocuments { get; set; }
    //}
    public class ProposedViewModelDetail
    {
        public ProposedViewModelDetail()
        {
            ProponentDocuments = new List<ProponentDocumentViewModelDetail>(); // Aquí cambia el tipo de la lista
        }

        public int Id { get; set; }
        public string DescriptionActivities { get; set; }
        public string DescripcionProposed { get; set; }
        public string AlliedCompany { get; set; }
        public string ProposedState { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? PresentationDate { get; set; }
        public string NameProponen { get; set; }
        public string BenefitedPublic { get; set; }
        public int FkProponentId { get; set; }
        public int FkProposedvalueId { get; set; }
        public ProponentViewModelDetail Proponent { get; set; }
        //public ProposedValueViewModel ProposedValue { get; set; }
        public ProposedValueViewModelDetail ProposedValue { get; set; }
        public List<ProponentDocumentViewModelDetail> ProponentDocuments { get; set; } // Aquí cambia el tipo de la lista
    }
}
