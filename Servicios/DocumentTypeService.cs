using famiCCV1.Server.Models;
using famiCCV1.Server.Servicios.IServices;
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

        public async Task<int> SaveDocumentTypeAsync(DocumentType documentType)
        {
            _dbContext.DocumentTypes.Add(documentType);
            await _dbContext.SaveChangesAsync();
            return documentType.Id;
        }

        public async Task<List<DocumentType>> GetDocumentTypesAsync()
        {
            return await _dbContext.DocumentTypes.ToListAsync();
        }
    }

}
