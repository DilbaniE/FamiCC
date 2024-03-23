using famiCCV1.Server.ViewModels;
using famiCCV1.Server.ViewModels.ViewModelUpdate;

namespace famiCCV1.Server.Servicios.IServices
{
    public interface IProposedService
    {
        //Guardar
        Task<int> SaveProposedAsync(ProposedViewModel proposedViewModel);

        //GETALL
        Task<List<ProposedViewModel>> GetAllProposedAsync();

        //GETALLDETAIL

        Task<List<ProposedViewModelDetail>> GetAllProposedWithDetailsAsync();

        //UPDATE

        //Task UpdateProposedWithDetailsAsync(ProposedViewModelDetail proposedViewModel);
        Task UpdateProposedAsync(int id, UpdateProposedViewModel updateProposedViewModel);

        //DELETE

        Task DeleteProposedAsync(int id);
    }
}
