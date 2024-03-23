namespace famiCCV1.Server.ViewModels.ViewModelDetails
{
    public class RepresentativeViewModelDetail
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string NumDocument { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int FkTdocumentId { get; set; }
        public DocumentTypeViewModelDetail DocumentType { get; set; }
    }
}
