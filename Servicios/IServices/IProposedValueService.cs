using famiCCV1.Server.ViewModels;

namespace famiCCV1.Server.Servicios.IServices
{
    public interface IProposedValueService
    {
        //SAVE
        Task<int> SaveProposedValueAsync(ProposedValueViewModel proposedValueViewModel);

        //GETALL
        Task<List<ProposedValueViewModel>> GetAllProposedValuesAsync();

        //UPDATE
        Task<bool> UpdateProposedValueAsync(int id, ProposedValueViewModel proposedValueViewModel);

        //DELETE
        Task<bool> DeleteProposedValueAsync(int id);

    }
}
