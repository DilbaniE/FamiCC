using famiCCV1.Server.Models;
using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace famiCCV1.Server.Servicios
{
    public class ProponentDocumentService : IProponentDocumentService
    {
        private readonly famiCC_v1Context _dbContext;

        public ProponentDocumentService(famiCC_v1Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveProponentDocumentAsync(ProponentDocumentViewModel proponentDocumentViewModel)
        {
            var proponentDocument = new ProponentDocument
            {
                FkAdjuntdocumentId = proponentDocumentViewModel.FkAdjuntdocumentId,
                FkProposedId = proponentDocumentViewModel.FkProposedId
            };

            _dbContext.ProponentDocuments.Add(proponentDocument);
            await _dbContext.SaveChangesAsync();

            return proponentDocument.Id;
        }

        //METOD GETALL
        public async Task<List<ProponentDocumentViewModel>> GetAllProponentDocumentsAsync()
        {
            var proponentDocuments = await _dbContext.ProponentDocuments
                .Select(pd => new ProponentDocumentViewModel
                {
                    FkAdjuntdocumentId = pd.FkAdjuntdocumentId,
                    FkProposedId = pd.FkProposedId
                })
                .ToListAsync();

            return proponentDocuments;
        }
    }

}
