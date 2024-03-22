using famiCCV1.Server.ViewModels;

namespace famiCCV1.Server.Servicios.IServices
{
    public interface IProponentDocumentService
    {
        Task<int> SaveProponentDocumentAsync(ProponentDocumentViewModel proponentDocumentViewModel);
    }
}
