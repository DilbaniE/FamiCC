using famiCCV1.Server.Models;
using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;

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
    }

}
