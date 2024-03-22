using famiCCV1.Server.Models;
using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace famiCCV1.Server.Servicios
{
    public class AdjuntDocumentService : IAdjuntDocumentService
    {
        private readonly famiCC_v1Context _dbContext;

        public AdjuntDocumentService(famiCC_v1Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveAdjuntDocumentAsync(AdjuntDocumentViewModel adjuntDocumentViewModel)
        {
            var adjuntDocument = new AdjuntDocument
            {
                Urls = adjuntDocumentViewModel.Urls,
                NameDocument = adjuntDocumentViewModel.NameDocument
            };

            _dbContext.AdjuntDocuments.Add(adjuntDocument);
            await _dbContext.SaveChangesAsync();

            return adjuntDocument.Id;
        }

        public async Task<List<AdjuntDocument>> GetAdjuntDocumentsAsync()
        {
            return await _dbContext.AdjuntDocuments.ToListAsync();
        }

        public async Task<bool> UpdateAdjuntDocumentAsync(int id, AdjuntDocumentViewModel adjuntDocumentViewModel)
        {
            var adjuntDocument = await _dbContext.AdjuntDocuments.FindAsync(id);

            if (adjuntDocument == null)
                return false;

            adjuntDocument.Urls = adjuntDocumentViewModel.Urls;
            adjuntDocument.NameDocument = adjuntDocumentViewModel.NameDocument;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAdjuntDocumentAsync(int id)
        {
            var adjuntDocument = await _dbContext.AdjuntDocuments.FindAsync(id);

            if (adjuntDocument == null)
                return false;

            _dbContext.AdjuntDocuments.Remove(adjuntDocument);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }

}
