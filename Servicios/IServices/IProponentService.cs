using famiCCV1.Server.ViewModels;

namespace famiCCV1.Server.Servicios.IServices
{
    public interface IProponentService
    {
        Task<int> SaveProponentAsync(ProponentViewModel proponentViewModel);
    }
}
