using famiCCV1.Server.Models;
using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace famiCCV1.Server.Servicios
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly famiCC_v1Context _dbContext;

        public DocumentTypeService(famiCC_v1Context dbContext)
        {
            _dbContext = dbContext;
        }

        //METOD SAVE 
        public async Task<int> SaveDocumentTypeAsync(DocumentTypeViewModel documentTypeViewModel)
        {
            var documentType = new DocumentType
            {
                DocumentType1 = documentTypeViewModel.DocumentType1
            };

            _dbContext.DocumentTypes.Add(documentType);
            await _dbContext.SaveChangesAsync();

            return documentType.Id;
        }

        //Metod GETALL
        public async Task<List<DocumentTypeViewModel>> GetAllDocumentTypesAsync()
        {
            var documentTypes = await _dbContext.DocumentTypes.ToListAsync();

            return documentTypes.Select(dt => new DocumentTypeViewModel
            {
                Id = dt.Id,
                DocumentType1 = dt.DocumentType1
            }).ToList();
        }

        //GETID METOD
        public async Task<DocumentTypeViewModel> GetDocumentTypeByIdAsync(int id)
        {
            var documentType = await _dbContext.DocumentTypes.FindAsync(id);

            if (documentType == null)
                return null;

            return new DocumentTypeViewModel
            {
                Id = documentType.Id,
                DocumentType1 = documentType.DocumentType1
            };
        }

        //METOD UPDATE
        public async Task<bool> UpdateDocumentTypeAsync(DocumentTypeViewModel documentTypeViewModel)
        {
            var existingDocumentType = await _dbContext.DocumentTypes.FindAsync(documentTypeViewModel.Id);

            if (existingDocumentType == null)
                return false;

            existingDocumentType.DocumentType1 = documentTypeViewModel.DocumentType1;

            _dbContext.DocumentTypes.Update(existingDocumentType);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        //DELETE
        public async Task<bool> DeleteDocumentTypeAsync(int id)
        {
            var existingDocumentType = await _dbContext.DocumentTypes.FindAsync(id);

            if (existingDocumentType == null)
                return false;

            _dbContext.DocumentTypes.Remove(existingDocumentType);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }

}
