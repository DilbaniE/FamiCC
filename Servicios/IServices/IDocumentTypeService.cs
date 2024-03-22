using famiCCV1.Server.Models;

namespace famiCCV1.Server.Servicios.IServices
{
    public interface IDocumentTypeService
    {
        Task<int> SaveDocumentTypeAsync(DocumentType documentType);
        Task<List<DocumentType>> GetDocumentTypesAsync();
    }
}
