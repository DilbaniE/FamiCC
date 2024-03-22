using famiCCV1.Server.ViewModels;

namespace famiCCV1.Server.Servicios.IServices
{
    public interface IProposedValueService
    {
        Task<int> SaveProposedValueAsync(ProposedValueViewModel proposedValueViewModel);
    }
}
