using famiCCV1.Server.ViewModels;

namespace famiCCV1.Server.Servicios.IServices
{
    public interface IProponentService
    {
        Task<int> SaveProponentAsync(ProponentViewModel proponentViewModel);

        // viewAll

        Task<List<ProponentViewModel>> GetAllProponentsAsync();

        // Update

        Task<bool> UpdateProponentAsync(int id, ProponentViewModel proponentViewModel);


    }
}
