using famiCCV1.Server.Models;
using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;

namespace famiCCV1.Server.Servicios
{
    public class ProposedValueService : IProposedValueService
    {
        private readonly famiCC_v1Context _dbContext;

        public ProposedValueService(famiCC_v1Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveProposedValueAsync(ProposedValueViewModel proposedValueViewModel)
        {
            var proposedValue = new ProposedValue
            {
                ContributionConfama = proposedValueViewModel.ContributionConfama,
                TotalAmount = proposedValueViewModel.TotalAmount
            };

            _dbContext.ProposedValues.Add(proposedValue);
            await _dbContext.SaveChangesAsync();

            return proposedValue.Id;
        }
    }

}
