using famiCCV1.Server.Models;
using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace famiCCV1.Server.Servicios
{
    public class ProposedValueService : IProposedValueService
    {
        private readonly famiCC_v1Context _dbContext;

        public ProposedValueService(famiCC_v1Context dbContext)
        {
            _dbContext = dbContext;
        }

        //METOD SAVE
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

        //METOD GETALL
        public async Task<List<ProposedValueViewModel>> GetAllProposedValuesAsync()
        {
            return await _dbContext.ProposedValues
                .Select(pv => new ProposedValueViewModel
                {
                    ContributionConfama = pv.ContributionConfama ?? 0,
                    TotalAmount = pv.TotalAmount ?? 0
                })
                .ToListAsync();
        }

        //METOD UPDATE 
        public async Task<bool> UpdateProposedValueAsync(int id, ProposedValueViewModel proposedValueViewModel)
        {
            var existingProposedValue = await _dbContext.ProposedValues.FindAsync(id);

            if (existingProposedValue == null)
                return false;

            existingProposedValue.ContributionConfama = proposedValueViewModel.ContributionConfama;
            existingProposedValue.TotalAmount = proposedValueViewModel.TotalAmount;

            _dbContext.ProposedValues.Update(existingProposedValue);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        //METOD DELETE
        public async Task<bool> DeleteProposedValueAsync(int id)
        {
            var proposedValue = await _dbContext.ProposedValues.FindAsync(id);

            if (proposedValue == null)
                return false;

            _dbContext.ProposedValues.Remove(proposedValue);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }

}
