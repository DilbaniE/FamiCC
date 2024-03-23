namespace famiCCV1.Server.ViewModels.ViewModelUpdate
{
    public class UpdateProposedViewModel
    {
        public int Id { get; set; }
        public string DescriptionActivities { get; set; }
        public string DescripcionProposed { get; set; }
        public string AlliedCompany { get; set; }
        public string ProposedState { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime PresentationDate { get; set; }
        public string NameProponen { get; set; }
        public string BenefitedPublic { get; set; }
        public ProponentUpdateViewModel Proponent { get; set; }
        public ProposedValueUpdateViewModel ProposedValue { get; set; }
        public List<ProponentDocumentUpdateViewModel> ProponentDocuments { get; set; }
    }
}
