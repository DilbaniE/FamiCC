using famiCCV1.Server.Models;
using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;

namespace famiCCV1.Server.Servicios
{
    public class RepresentativeService : IRepresentativeService
    {
        private readonly famiCC_v1Context _dbContext;

        public RepresentativeService(famiCC_v1Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveRepresentativeAsync(RepresentativeViewModel representativeViewModel)
        {
            var representative = new Representative
            {
                Email = representativeViewModel.Email,
                NumDocument = representativeViewModel.NumDocument,
                FirstName = representativeViewModel.FirstName,
                LastName = representativeViewModel.LastName,
                Phone = representativeViewModel.Phone,
                FkTdocumentId = representativeViewModel.FkTdocumentId
            };

            _dbContext.Representatives.Add(representative);
            await _dbContext.SaveChangesAsync();

            return representative.Id;
        }
    }

}
