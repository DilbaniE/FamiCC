using famiCCV1.Server.Models;
using famiCCV1.Server.ViewModels;

namespace famiCCV1.Server.Servicios.IServices
{
    public interface IAdjuntDocumentService
    {
        Task<int> SaveAdjuntDocumentAsync(AdjuntDocumentViewModel adjuntDocumentViewModel);

        Task<List<AdjuntDocument>> GetAdjuntDocumentsAsync();

        Task<bool> UpdateAdjuntDocumentAsync(int id, AdjuntDocumentViewModel adjuntDocumentViewModel);

        Task<bool> DeleteAdjuntDocumentAsync(int id);
    }
}
