using famiCCV1.Server.ViewModels;

namespace famiCCV1.Server.Servicios.IServices
{
    public interface IProponentDocumentService
    {
        //save
        Task<int> SaveProponentDocumentAsync(ProponentDocumentViewModel proponentDocumentViewModel);

        //GetAll
        Task<List<ProponentDocumentViewModel>> GetAllProponentDocumentsAsync();
    }
}
