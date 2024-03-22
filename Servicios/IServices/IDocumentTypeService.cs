using famiCCV1.Server.Models;
using famiCCV1.Server.ViewModels;

namespace famiCCV1.Server.Servicios.IServices
{
    public interface IDocumentTypeService
    {
        //SAVE
        Task<int> SaveDocumentTypeAsync(DocumentTypeViewModel documentTypeViewModel);

        //GEALL
        Task<List<DocumentTypeViewModel>> GetAllDocumentTypesAsync();

        //GetId
        Task<DocumentTypeViewModel> GetDocumentTypeByIdAsync(int id);

        //UPDATE
        Task<bool> UpdateDocumentTypeAsync(DocumentTypeViewModel documentTypeViewModel);

        //DELETE 
        Task<bool> DeleteDocumentTypeAsync(int id);


    }
}
