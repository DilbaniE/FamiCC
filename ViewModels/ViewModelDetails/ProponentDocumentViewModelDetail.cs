namespace famiCCV1.Server.ViewModels.ViewModelDetails
{
    public class ProponentDocumentViewModelDetail
    {
        public int Id { get; set; }
        public int FkAdjuntdocumentId { get; set; }
        public int FkProposedId { get; set; }
        public AdjuntDocumentViewModelDetail AdjuntDocument { get; set; }
    }
}
