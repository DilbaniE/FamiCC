using famiCCV1.Server.Models;
using famiCCV1.Server.Servicios.IServices;
using famiCCV1.Server.ViewModels;

namespace famiCCV1.Server.Servicios
{
    public class ProposedService : IProposedService
    {
        private readonly famiCC_v1Context _dbContext;

        public ProposedService(famiCC_v1Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveProposedAsync(ProposedViewModel proposedViewModel)
        {
            var proposed = new Proposed
            {
                DescriptionActivities = proposedViewModel.DescriptionActivities,
                DescripcionProposed = proposedViewModel.DescripcionProposed,
                AlliedCompany = proposedViewModel.AlliedCompany,
                ProposedState = proposedViewModel.ProposedState,
                DateStart = proposedViewModel.DateStart,
                PresentationDate = proposedViewModel.PresentationDate,
                NameProponen = proposedViewModel.NameProponen,
                BenefitedPublic = proposedViewModel.BenefitedPublic,
                FkProponentId = proposedViewModel.FkProponentId,
                FkProposedvalueId = proposedViewModel.FkProposedvalueId
            };

            _dbContext.Proposeds.Add(proposed);
            await _dbContext.SaveChangesAsync();

            return proposed.Id;
        }
    }

}
