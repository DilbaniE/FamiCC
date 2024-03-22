using famiCCV1.Server.ViewModels;

namespace famiCCV1.Server.Servicios.IServices
{
    public interface IProposedService
    {
        //Guardar
        Task<int> SaveProposedAsync(ProposedViewModel proposedViewModel);
    }
}
